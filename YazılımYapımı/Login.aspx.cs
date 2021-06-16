using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace YazilimYapimi
{
    public partial class Login : System.Web.UI.Page
    {
        Baglanti bgl = new Baglanti();
        string KullaniciID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("SELECT*FROM AdminBilgi where Admin=@admin AND Parola=@parola", bgl.baglanti());
            komut.Parameters.AddWithValue("@admin", TextBox1.Text);
            komut.Parameters.AddWithValue("@parola", TextBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            
            SqlCommand komut2 = new SqlCommand("SELECT*FROM KullaniciBilgi Where KullaniciAdi=@KullaniciAdi AND KullaniciParola=@KullaniciParola ",bgl.baglanti());
            komut2.Parameters.AddWithValue("@KullaniciAdi",TextBox1.Text);
            komut2.Parameters.AddWithValue("@KullaniciParola",TextBox2.Text);
            SqlDataReader dr2 = komut2.ExecuteReader();

            if (dr.Read())
            {
                Response.Redirect("UrunTalep.aspx");
            }
            else if (dr2.Read())
            {
                KullaniciID = dr2["KullaniciID"].ToString();
                Session.Add("KullaniciID", KullaniciID);
                Response.Redirect("Anasayfa.aspx");
			}
            else
			{
                Label3.Text = "Hatalı Kullanıcı Adı veya Şifre";
			}
            bgl.baglanti().Close();
        }
    }
}