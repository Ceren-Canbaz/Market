using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace YazılımYapımı
{
	public partial class Urunler : System.Web.UI.Page
	{
		Baglanti bgl = new Baglanti();
		string UrunKategoriID = "";
		string id = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			UrunKategoriID = Request.QueryString["UrunKategoriID"];
			id = Session["KullaniciID"].ToString();
			SqlCommand komut = new SqlCommand("SELECT*FROM UrunDetay u inner join KullaniciBilgi k on k.KullaniciID=U.KullaniciID WHERE U.UrunKategoriID=@p1 AND k.KullaniciID!=@p2",bgl.baglanti());
			komut.Parameters.AddWithValue("@p1",UrunKategoriID);
			komut.Parameters.AddWithValue("@p2", id);
			SqlDataReader dr = komut.ExecuteReader();
			Repeater1.DataSource = dr;
			Repeater1.DataBind();
			bgl.baglanti().Close();
		}
	}
}