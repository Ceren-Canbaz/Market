using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YazilimYapimi
{
	public partial class Anasayfa : System.Web.UI.Page
	{
		Baglanti bgl = new Baglanti();
		protected void Page_Load(object sender, EventArgs e)
		{
		
			SqlCommand komut=new SqlCommand("Select*from UrunKategori",bgl.baglanti());
			SqlDataReader dr = komut.ExecuteReader();
			Repeater1.DataSource = dr;
			Repeater1.DataBind();
			bgl.baglanti().Close();
			
		}

		
	}
}