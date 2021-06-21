using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YazilimYapimi
{
    public partial class UrunDuzenle : System.Web.UI.Page
    {
        Baglanti bgl = new Baglanti();
        string UrunID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Yazdir();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand guncelleme = new SqlCommand("UPDATE UrunDetay set UrunFiyat=@p1 , UrunAdet=@p3 WHERE UrunID=@p2", bgl.baglanti());
            guncelleme.Parameters.AddWithValue("@p1", TextBox1.Text);
            guncelleme.Parameters.AddWithValue("@p2", UrunID);
            guncelleme.Parameters.AddWithValue("@p3", TextBox2.Text);
            guncelleme.ExecuteNonQuery();
            lblrapor.Text = "Güncellendi";
            Yazdir();
            SatinAl.BeklenenUrun();
        }
        public void Yazdir()
		{
            UrunID = Request.QueryString["UrunID"].ToString();
            SqlCommand komut = new SqlCommand("SELECT*FROM UrunDetay WHERE UrunID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", UrunID);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Txtad.Text = dr["UrunAd"].ToString();
                Txtid.Text = dr["UrunID"].ToString();
                TxtFiyat.Text = dr["UrunFiyat"].ToString();
                TextBox2.Text = dr["UrunAdet"].ToString();

            }
            dr.Close();
            Txtid.Enabled = false;
            Txtad.Enabled = false;
            TxtFiyat.Enabled = false;
        }
    }
}