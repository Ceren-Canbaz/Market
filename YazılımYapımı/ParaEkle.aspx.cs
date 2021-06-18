using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace YazilimYapimi
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		Baglanti bgl = new Baglanti();
		Kullanici ent = new Kullanici();
		protected void Page_Load(object sender, EventArgs e)
		{

			ent.KullaniciID = Convert.ToInt32(Session["KullaniciID"]);
			SqlCommand komut = new SqlCommand("SELECT*FROM KullaniciBilgi WHERE KullaniciID=@p1",bgl.baglanti());
			komut.Parameters.AddWithValue("@p1", ent.KullaniciID);
			SqlDataReader dr = komut.ExecuteReader();
			while(dr.Read())
			{
				TxtPara.Text = dr["KullaniciPara"].ToString();
			}
			TxtPara.Enabled = false;
			dr.Close();
			
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			double para;
			para = Convert.ToDouble(TextBox1.Text);
			string value = code.SelectedValue;
			SqlCommand komut = new SqlCommand("insert into ParaTalep (KullaniciID,Para,Doviz) values (@p1,@p2,@p3)", bgl.baglanti());
			komut.Parameters.AddWithValue("@p1", ent.KullaniciID);
			komut.Parameters.AddWithValue("@p2", para);
			komut.Parameters.AddWithValue("@p3", code.SelectedValue.ToString());
			komut.ExecuteNonQuery();
			Label1.Text = "Talebiniz olusturuldu";
			bgl.baglanti().Close();
		}
	}
}