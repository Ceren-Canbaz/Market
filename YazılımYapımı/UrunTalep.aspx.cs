using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace YazılımYapımı
{
	public partial class UrunTalep : System.Web.UI.Page
	{
		Baglanti bgl = new Baglanti();
		string id = "";
		string islem = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Page.IsPostBack == false)
			{ 
				id = Request.QueryString["UrunID"];
				islem = Request.QueryString["islem"];
			}
			
			SqlCommand urun = new SqlCommand("SELECT*FROM UrunDetay WHERE Onay=0", bgl.baglanti());
			SqlDataReader dr = urun.ExecuteReader();
			Repeater2.DataSource = dr;
			Repeater2.DataBind();
			dr.Close();


			if (islem == "sil")
			{
				SqlCommand sil = new SqlCommand("DELETE FROM UrunDetay WHERE UrunID=@p1", bgl.baglanti());
				sil.Parameters.AddWithValue("@p1", id);
				sil.ExecuteNonQuery();
				bgl.baglanti().Close();
				Response.Redirect("UrunTalep.aspx");
			}
			else if (islem == "onayla")
			{
				SqlCommand onayla = new SqlCommand("UPDATE UrunDetay set Onay=1 WHERE UrunID=@p1", bgl.baglanti());
				onayla.Parameters.AddWithValue("@p1", id);
				onayla.ExecuteNonQuery();
				bgl.baglanti().Close();
				Response.Redirect("UrunTalep.aspx");
			}
		}
	}
}