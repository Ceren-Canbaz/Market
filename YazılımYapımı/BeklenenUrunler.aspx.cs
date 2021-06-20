using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace YazilimYapimi
{
	public partial class BeklenenUrunler : System.Web.UI.Page
	{
		Baglanti bgl = new Baglanti();
		string islem = "";
		string id = "";
		string kullaniciID = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			kullaniciID = Session["KullaniciID"].ToString();
			SqlCommand listele = new SqlCommand("SELECT*FROM BeklenenUrun b inner join UrunKategori u on b.UrunKategoriID=u.UrunKategoriID WHERE AliciID=@p1",bgl.baglanti());
			listele.Parameters.AddWithValue("@p1",kullaniciID);
			SqlDataReader dr = listele.ExecuteReader();
			Repeater1.DataSource = dr;
			Repeater1.DataBind();
			if(Page.IsPostBack==false)
			{
				id = Request.QueryString["IstekID"];
				islem = Request.QueryString["islem"];
			}
			if(islem=="iptal")
			{
				SqlCommand komut = new SqlCommand("DELETE FROM BeklenenUrun WHERE IstekID=@p1",bgl.baglanti());
				komut.Parameters.AddWithValue("@p1", id);
				komut.ExecuteNonQuery();
				Response.Redirect("BeklenenUrunler.aspx");
			}
		}
	}
}