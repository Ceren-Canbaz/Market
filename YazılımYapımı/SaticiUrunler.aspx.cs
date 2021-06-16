using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YazilimYapimi
{
    public partial class SaticiUrunler : System.Web.UI.Page
    {
        Baglanti bgl = new Baglanti();
        Kullanici kullanici = new Kullanici();
        protected void Page_Load(object sender, EventArgs e)
        {
            kullanici.KullaniciID = Convert.ToInt32(Session["KullaniciID"].ToString());
            SqlCommand komut = new SqlCommand("SELECT*FROM UrunDetay WHERE KullaniciID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", kullanici.KullaniciID);
            SqlDataReader dr = komut.ExecuteReader();
            Repeater1.DataSource = dr;
            Repeater1.DataBind();
            bgl.baglanti().Close();
        }
    }
}