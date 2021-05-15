using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YazılımYapımı
{
	public partial class Register : System.Web.UI.Page
	{
		Baglanti bgl = new Baglanti();
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			SqlCommand komut = new SqlCommand("insert into KullaniciBilgi (KullaniciAdi,KullaniciAdSoyad,KullaniciParola,KullaniciTC,KullaniciTelefon,KullaniciMail,KullaniciAdres)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.baglanti());
			komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
			komut.Parameters.AddWithValue("@p2", txtAdSoyad.Text);
			komut.Parameters.AddWithValue("@p3", txtParola.Text);
			komut.Parameters.AddWithValue("@p4", txtTC.Text);
			komut.Parameters.AddWithValue("@p5", txtTelefon.Text);
			komut.Parameters.AddWithValue("@p6", txtMail.Text);
			komut.Parameters.AddWithValue("@p7", txtAdres.Text);
			komut.ExecuteNonQuery();
			Label8.Text = "Kayıt işlemi başarıyla gerçekleştirildi";
			bgl.baglanti().Close();
		}
	}
}