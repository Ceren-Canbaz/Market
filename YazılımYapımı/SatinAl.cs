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
			double araci = 0;
			araci = alici.Urunfiyat / 100;

			//Satın alma işlemi
			alici.Urunfiyat = alici.Urunfiyat + araci;
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

		}
		public static void BeklenenUrun()
		{
			List<Kullanici> urun = new List<Kullanici>();
			SqlCommand urunler = new SqlCommand("SELECT*FROM UrunDetay WHERE Onay=1", bgl.baglanti());
			SqlDataReader dr1 = urunler.ExecuteReader();
			while (dr1.Read())
			{
				Kullanici urunbilgi = new Kullanici();
				urunbilgi.SaticiID = Convert.ToInt32(dr1["KullaniciID"].ToString());
				urunbilgi.UrunKategoriID = Convert.ToInt32(dr1["UrunKategoriID"].ToString());
				urunbilgi.UrunID = Convert.ToInt32(dr1["UrunID"].ToString());
				urunbilgi.Urunfiyat = Convert.ToDouble(dr1["UrunFiyat"].ToString());
				urunbilgi.Urunadet = Convert.ToInt32(dr1["UrunAdet"]);
				urun.Add(urunbilgi);
			}
			Kullanici istenenurun = new Kullanici();
			SqlCommand komut = new SqlCommand("SELECT*FROM BeklenenUrun", bgl.baglanti());
			SqlDataReader dr = komut.ExecuteReader();
			while (dr.Read())
			{
				istenenurun.AliciID = Convert.ToInt32(dr["AliciID"].ToString());
				istenenurun.UrunKategoriID = Convert.ToInt32(dr["UrunKategoriID"].ToString());
				istenenurun.Urunfiyat = Convert.ToDouble(dr["Fiyat"].ToString());
				var eslesenurun = urun.FirstOrDefault(u => u.Urunfiyat <= istenenurun.Urunfiyat && u.UrunKategoriID == istenenurun.UrunKategoriID && u.Urunadet >= istenenurun.Urunadet);
				if(eslesenurun!=null)
				{
					istenenurun.Urunfiyat = istenenurun.Urunfiyat - eslesenurun.Urunfiyat;
					SatinAl.SatinAlma(istenenurun, eslesenurun);
				}
			}
			//istenen fiyatta ürün var mı karşılaştırılması
			
		}
	}
}