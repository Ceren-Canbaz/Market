using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace YazilimYapimi
{
	public partial class Alisveris : System.Web.UI.Page
	{
		Baglanti bgl = new Baglanti();
		Kullanici ent = new Kullanici();
		Kullanici a = new Kullanici();
		protected void Page_Load(object sender, EventArgs e)
		{
			ent.UrunID = Convert.ToInt32(Request.QueryString["UrunID"].ToString());
			SqlCommand urunyazdir = new SqlCommand("SELECT*FROM UrunDetay u inner join KullaniciBilgi k on k.KullaniciID=U.KullaniciID WHERE U.UrunID=@p1", bgl.baglanti());
			urunyazdir.Parameters.AddWithValue("@p1", ent.UrunID);
			SqlDataReader dr = urunyazdir.ExecuteReader();
			while (dr.Read())
			{ 
				ent.Urunad = dr["UrunAd"].ToString();
				ent.Kullaniciad = dr["KullaniciAdSoyad"].ToString();
				ent.Kullanicipara = Convert.ToDouble(dr["KullaniciPara"]);
				ent.Urunadet = Convert.ToInt32(dr["UrunAdet"].ToString());
				ent.Urunfiyat = Convert.ToDouble(dr["UrunFiyat"].ToString());
			}
			dr.Close();

			
			SqlCommand komut = new SqlCommand("Select*From KullaniciBilgi WHERE KullaniciID=@p1", bgl.baglanti());
			a.KullaniciID = Convert.ToInt32(Session["KullaniciID"]);
			komut.Parameters.AddWithValue("@p1", a.KullaniciID);
			SqlDataReader dr1 = komut.ExecuteReader();

			while (dr1.Read())
			{
				a.Kullaniciad = dr1["KullaniciAdSoyad"].ToString();
				a.Kullanicipara =Convert.ToDouble(dr1["KullaniciPara"].ToString());
			}
			dr1.Close();
			Yazdir(ent, a);

		}
		public void Yazdir(Kullanici x, Kullanici y)
		{
			
			Txtid.Text = x.UrunID.ToString();
			Txtad.Text= x.Urunad;
			Txtsatici.Text = x.Kullaniciad;
			Txtmiktar.Text = x.Urunadet.ToString();
			TxtFiyat.Text = x.Urunfiyat.ToString();
			Txtid.Enabled = false;
			Txtad.Enabled = false;
			Txtsatici.Enabled = false;
			Txtmiktar.Enabled = false;
			TxtFiyat.Enabled = false;
		}
		protected void Button1_Click(object sender, EventArgs e)
		{
			a.Urunadet = Convert.ToInt32(Txtadet.Text);
			a.Urunfiyat = (a.Urunadet) * (ent.Urunfiyat);
			
			if (ent.Urunadet >= a.Urunadet && a.Kullanicipara >=a.Urunfiyat)
			{
				SatinAl.SatinAlma(a,ent);
				Button1.Visible = false;
				lblrapor.Text = "Satın Alma işlemi Başarıyla gerçekleşti";
				Yazdir(ent, a);
			}
			else if(ent.Urunadet < a.Urunadet)
			{
				lblrapor.Text = "Yetersiz Stok";
			}
			else if(a.Kullanicipara<a.Urunfiyat)
			{
				lblrapor.Text = "Yetersiz Bakiye";
			}
			
		}

	}
}