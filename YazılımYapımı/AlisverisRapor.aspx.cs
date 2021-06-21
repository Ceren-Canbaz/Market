using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace YazilimYapimi
{
    public partial class AlisverRapor : System.Web.UI.Page
    {
        Baglanti bgl = new Baglanti();
        string kullaniciID = "";
        Kullanici tarih = new Kullanici();
        protected void Page_Load(object sender, EventArgs e)
        {
			kullaniciID = Session["KullaniciID"].ToString();
			SqlCommand alimlar = new SqlCommand("SELECT*FROM KullaniciRapor r inner join UrunKategori u on r.UrunKategoriID=u.UrunKategoriID WHERE AliciID=@p1", bgl.baglanti());
			alimlar.Parameters.AddWithValue("@p1", kullaniciID);
			SqlDataReader dr = alimlar.ExecuteReader();
			Repeater1.DataSource = dr;
			Repeater1.DataBind();

			SqlCommand satislar = new SqlCommand("SELECT*FROM KullaniciRapor r inner join UrunKategori u on r.UrunKategoriID=u.UrunKategoriID WHERE SaticiID=@p1", bgl.baglanti());
			satislar.Parameters.AddWithValue("@p1", kullaniciID);
			SqlDataReader dr1 = satislar.ExecuteReader();
			Repeater2.DataSource = dr1;
			Repeater2.DataBind();
		}

        protected void Button1_Click(object sender, EventArgs e)
        {
			//rapor için istenen zaman aralığını alıp kullanıcının bu süredeki hareketlerini gösteriyoruz
			string baslangic = String.Format("{0}", Request.Form["Text1"]);
			string bitis = String.Format("{0}", Request.Form["Text2"]);
			DateTime baslangic1 = Convert.ToDateTime(baslangic);
			DateTime bitis1 = Convert.ToDateTime(bitis);
			SqlCommand komut = new SqlCommand("SELECT * FROM KullaniciRapor r inner join UrunKategori u on r.UrunKategoriID = u.UrunKategoriID WHERE AliciID = @p1 AND Tarih>=@p2 AND Tarih<=@p3", bgl.baglanti());
			komut.Parameters.AddWithValue("@p1", kullaniciID);
			komut.Parameters.AddWithValue("@p2", baslangic1);
			komut.Parameters.AddWithValue("@p3", bitis1);
			SqlDataReader dr1 = komut.ExecuteReader();
			Repeater1.DataSource = dr1;
			Repeater1.DataBind();
			SqlCommand komut2 = new SqlCommand("SELECT*FROM KullaniciRapor r inner join UrunKategori u on r.UrunKategoriID=u.UrunKategoriID WHERE SaticiID=@p1", bgl.baglanti());
			komut2.Parameters.AddWithValue("@p1", kullaniciID);
			SqlDataReader dr2 = komut2.ExecuteReader();
			Repeater2.DataSource = dr2;
			Repeater2.DataBind();
		}
    }
}