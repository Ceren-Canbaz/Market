using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace YazilimYapimi
{
	public partial class Rapor : System.Web.UI.Page
	{
		Baglanti bgl = new Baglanti();
		protected void Page_Load(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("SELECT*FROM Rapor", bgl.baglanti());
			SqlDataReader dr = komut.ExecuteReader();
			Repeater2.DataSource = dr;
			Repeater2.DataBind();
			bgl.baglanti().Close();
		}
	}
}