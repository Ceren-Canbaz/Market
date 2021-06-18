using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YazilimYapimi
{
    public partial class UrunDuzenle : System.Web.UI.Page
    {
        Baglanti bgl = new Baglanti();
        string UrunID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            UrunID = Request.QueryString["UrunID"].ToString();
            SqlCommand komut = new SqlCommand("SELECT*FROM UrunDetay WHERE UrunID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", UrunID);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                Txtad.Text = dr["UrunAd"].ToString();
                Txtid.Text = dr["UrunID"].ToString();
                TxtFiyat.Text = dr["UrunFiyat"].ToString();
                
            }
            dr.Close();
            Txtid.Enabled = false;
            Txtad.Enabled = false;
            TxtFiyat.Enabled = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand guncelleme = new SqlCommand("UPDATE UrunDetay set UrunFiyat=@p1 WHERE UrunID=@p2", bgl.baglanti());
            guncelleme.Parameters.AddWithValue("@p1", TextBox1.Text);
            guncelleme.Parameters.AddWithValue("@p2", UrunID);
            guncelleme.ExecuteNonQuery();
            lblrapor.Text = "Güncellendi";
            BeklenenUrun();
        }
        public void BeklenenUrun()
		{
            UrunBilgi istenenurun = new UrunBilgi();
           
            SqlCommand komut = new SqlCommand("SELECT*FROM BeklenenUrun",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
			{
                istenenurun.AliciID = Convert.ToInt32(dr["AliciID"].ToString());
                istenenurun.UrunKategoriID = Convert.ToInt32(dr["UrunKategoriID"].ToString());
                istenenurun.Fiyat = Convert.ToDouble(dr["Fiyat"].ToString());
			}
            List<UrunBilgi> urun = new List<UrunBilgi>();
            SqlCommand urunler = new SqlCommand("SELECT*FROM UrunDetay WHERE Onay=1", bgl.baglanti());
            SqlDataReader dr1 = urunler.ExecuteReader();
            while (dr1.Read())
			{
                UrunBilgi urunbilgi = new UrunBilgi();
                urunbilgi.SaticiID = Convert.ToInt32(dr1["KullaniciID"].ToString());
                urunbilgi.UrunKategoriID = Convert.ToInt32(dr1["UrunKategoriID"].ToString());
                urunbilgi.UrunID = Convert.ToInt32(dr1["UrunID"].ToString());
                urunbilgi.Fiyat = Convert.ToDouble(dr1["UrunFiyat"].ToString());
                urun.Add(urunbilgi);
			}
            var eslesenurun = urun.FirstOrDefault(u=>u.Fiyat==istenenurun.Fiyat&&u.UrunKategoriID==istenenurun.UrunKategoriID&&u.Adet>=istenenurun.Adet);
            
        }
    }
}