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
		protected void Page_Load(object sender, EventArgs e)
		{
			SqlCommand listele = new SqlCommand("SELECT*FROM BeklenenUrun b inner join UrunKategori u on b.UrunKategoriID=u.UrunKategoriID",bgl.baglanti());
			SqlDataReader dr = listele.ExecuteReader();
			Repeater1.DataSource = dr;
			Repeater1.DataBind();
		}
	}
}