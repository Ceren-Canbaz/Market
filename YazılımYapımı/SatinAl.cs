using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace YazilimYapimi
{
	public static class SatinAl
	{
		static Baglanti bgl = new Baglanti();
		public static void SatinAlma(Kullanici alici,Kullanici satici)
		{
			//Muhasebeye tahsil edilecek ücret işlemleri
			Kullanici muhasebe = new Kullanici();
			muhasebe.Urunfiyat = alici.Urunfiyat / 100;

			//Satın alma işlemi
			alici.Urunfiyat = alici.Urunfiyat + muhasebe.Urunfiyat;
			alici.Kullanicipara = (alici.Kullanicipara) - (alici.Urunfiyat);
			satici.Urunadet = satici.Urunadet - alici.Urunadet;

			SqlCommand stok = new SqlCommand("UPDATE UrunDetay set UrunAdet=@p1 WHERE UrunID=@p2 ", bgl.baglanti());
			stok.Parameters.AddWithValue("@p2", satici.UrunID);
			stok.Parameters.AddWithValue("@p1", satici.Urunadet);
			stok.ExecuteNonQuery();

			SqlCommand para = new SqlCommand("Update KullaniciBilgi set KullaniciPara=@p1 WHERE KullaniciID=@p2", bgl.baglanti());
			para.Parameters.AddWithValue("@p2", alici.KullaniciID);
			para.Parameters.AddWithValue("@p1", alici.Kullanicipara);
			para.ExecuteNonQuery();

			SqlCommand komut = new SqlCommand("SELECT*FROM Muhasebe", bgl.baglanti());
			SqlDataReader oku = komut.ExecuteReader();
			while(oku.Read())
			{
				muhasebe.Kullanicipara = Convert.ToDouble(oku["MuhasebePara"].ToString());
			}
			muhasebe.Kullanicipara = muhasebe.Urunfiyat+muhasebe.Kullanicipara;
			SqlCommand ekle = new SqlCommand("UPDATE Muhasebe set MuhasebePara=@p1 WHERE MuhasebeID=@p2", bgl.baglanti());
			ekle.Parameters.AddWithValue("@p1", muhasebe.Kullanicipara);
			ekle.Parameters.AddWithValue("@p2",1);
			ekle.ExecuteNonQuery();

			SqlCommand rapor = new SqlCommand("insert into KullaniciRapor(AliciID,Tarih,UrunKategoriID,Fiyat,Miktar,SaticiID) values(@p1,@p2,@p3,@p4,@p5,@p6)",bgl.baglanti());
			rapor.Parameters.AddWithValue("@p1", alici.KullaniciID);
			rapor.Parameters.AddWithValue("@p2", DateTime.Now);
			rapor.Parameters.AddWithValue("@p3", satici.UrunKategoriID);
			rapor.Parameters.AddWithValue("@p4", alici.Urunfiyat);
			rapor.Parameters.AddWithValue("@p5", alici.Urunadet);
			rapor.Parameters.AddWithValue("@p6", satici.KullaniciID);
			rapor.ExecuteNonQuery();
		}
		public static void BeklenenUrun()
		{
			List<Kullanici> urun = new List<Kullanici>();
			SqlCommand urunler = new SqlCommand("SELECT*FROM UrunDetay,KullaniciBilgi WHERE Onay=1", bgl.baglanti());
			SqlDataReader dr1 = urunler.ExecuteReader();
			while (dr1.Read())
			{
				Kullanici urunbilgi = new Kullanici();
				urunbilgi.KullaniciID = Convert.ToInt32(dr1["KullaniciID"].ToString());
				urunbilgi.UrunKategoriID = Convert.ToInt32(dr1["UrunKategoriID"].ToString());
				urunbilgi.UrunID = Convert.ToInt32(dr1["UrunID"].ToString());
				urunbilgi.Urunad = dr1["UrunAd"].ToString();
				urunbilgi.Urunfiyat = Convert.ToDouble(dr1["UrunFiyat"].ToString());
				urunbilgi.Urunadet = Convert.ToInt32(dr1["UrunAdet"]);
				urunbilgi.Kullaniciad = dr1["KullaniciAdSoyad"].ToString();
				urunbilgi.Kullanicipara=Convert.ToDouble(dr1["KullaniciPara"].ToString());
				urun.Add(urunbilgi);
			}
			Kullanici istenenurun = new Kullanici();
			SqlCommand komut = new SqlCommand("SELECT*FROM BeklenenUrun b inner join KullaniciBilgi k on b.AliciID=k.KullaniciID", bgl.baglanti());
			SqlDataReader dr = komut.ExecuteReader();
			while (dr.Read())
			{
				double fiyats = 0;
				istenenurun.KullaniciID = Convert.ToInt32(dr["AliciID"].ToString());
				istenenurun.Kullaniciad = dr["KullaniciAdSoyad"].ToString();
				istenenurun.UrunKategoriID = Convert.ToInt32(dr["UrunKategoriID"].ToString());
				istenenurun.Urunadet = Convert.ToInt32(dr["Adet"].ToString());
				istenenurun.Urunfiyat = Convert.ToDouble(dr["Fiyat"].ToString());
				istenenurun.IstekID = Convert.ToInt32(dr["IstekID"].ToString());
				istenenurun.Kullanicipara = Convert.ToDouble(dr["KullaniciPara"]);

				fiyats = istenenurun.Urunfiyat * istenenurun.Urunadet;
				//istenen fiyatta ürün var mı karşılaştırılması
				var eslesenurun = urun.FirstOrDefault(u => u.Urunfiyat <= istenenurun.Urunfiyat && u.UrunKategoriID == istenenurun.UrunKategoriID && u.Urunadet >= istenenurun.Urunadet);
				if(eslesenurun!=null&&istenenurun.Kullanicipara>=fiyats)
				{
					istenenurun.Urunfiyat = eslesenurun.Urunfiyat * istenenurun.Urunadet;
					SatinAl.SatinAlma(istenenurun, eslesenurun);
					SatinAl.Durum(istenenurun);
				}
			}
		}
		public static void Durum(Kullanici kullanici)
		{
			SqlCommand durumguncelle = new SqlCommand("UPDATE BeklenenUrun set Durum=@p1 WHERE IstekID=@p2",bgl.baglanti());
			durumguncelle.Parameters.AddWithValue("@p1","Satın Alındı");
			durumguncelle.Parameters.AddWithValue("@p2",kullanici.IstekID);
			durumguncelle.ExecuteNonQuery();
			bgl.baglanti().Close();
		}
	}
}