using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace YazilimYapimi
{
	public partial class UrunEkle : System.Web.UI.Page
	{
		Baglanti bgl = new Baglanti();
		int kategoriID;
		Kullanici k = new Kullanici();
		protected void Page_Load(object sender, EventArgs e)
		{




		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			kategoriID = int.Parse(DropDownList1.SelectedValue.ToString());
			SqlCommand komut = new SqlCommand("insert into UrunDetay  (UrunKategoriID,UrunAd,UrunAdet,KullaniciID,UrunFiyat) values(@p1,@p2,@p3,@p4,@p5) ",bgl.baglanti());
			k.KullaniciID = Convert.ToInt32(Session["KullaniciID"]);
			komut.Parameters.AddWithValue("@p1",kategoriID);
			komut.Parameters.AddWithValue("@p2",TxtUrunad.Text);
			komut.Parameters.AddWithValue("@p3",TxtAdet.Text);
			komut.Parameters.AddWithValue("@p4",k.KullaniciID);
			komut.Parameters.AddWithValue("@p5",Fiyat.Text);
			komut.ExecuteNonQuery();
			Label5.Text = "Talebiniz Alındı";
		}
	}
}