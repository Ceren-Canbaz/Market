using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace YazilimYapimi
{
	public partial class Urunler : System.Web.UI.Page
	{
		Baglanti bgl = new Baglanti();
		string UrunKategoriID = "";
		string id = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			UrunKategoriID = Request.QueryString["UrunKategoriID"];
			id = Session["KullaniciID"].ToString();
			SqlCommand komut = new SqlCommand("SELECT*FROM UrunDetay u inner join KullaniciBilgi k on k.KullaniciID=U.KullaniciID WHERE U.UrunKategoriID=@p1 AND k.KullaniciID!=@p2",bgl.baglanti());
			komut.Parameters.AddWithValue("@p1",UrunKategoriID);
			komut.Parameters.AddWithValue("@p2", id);
			SqlDataReader dr = komut.ExecuteReader();
			Repeater1.DataSource = dr;
			Repeater1.DataBind();
			bgl.baglanti().Close();
		}
		protected void Button1_Click(object sender, EventArgs e)
		{
			//Alıcı bir fiyat belirleyecek ve o fiyata kaç tane ürün olduguna aşağıdaki sorgudan erişilecek
			SqlCommand kontrol = new SqlCommand("SELECT COUNT(*) AS Sayi FROM UrunDetay u inner join KullaniciBilgi k on k.KullaniciID=U.KullaniciID WHERE U.UrunKategoriID=@p1 AND k.KullaniciID!=@p2 AND UrunFiyat<=@p3",bgl.baglanti());
			kontrol.Parameters.AddWithValue("@p1", UrunKategoriID);
			kontrol.Parameters.AddWithValue("@p2", id);
			kontrol.Parameters.AddWithValue("@p3", TextBox1.Text);
			SqlDataReader dr2 = kontrol.ExecuteReader();
			while(dr2.Read())
			{
				if(dr2["Sayi"].ToString()!="0") //Eğer alıcının isteidği fiyatta ürün varsa ifin içine girecek ve listeleme işlemi yapılacak
				{
					SqlCommand listele = new SqlCommand("SELECT*FROM UrunDetay u inner join KullaniciBilgi k on k.KullaniciID=U.KullaniciID WHERE U.UrunKategoriID=@p1 AND k.KullaniciID!=@p2 AND UrunFiyat<=@p3 ", bgl.baglanti());
					listele.Parameters.AddWithValue("@p1", UrunKategoriID);
					listele.Parameters.AddWithValue("@p2", id);
					listele.Parameters.AddWithValue("@p3", TextBox1.Text);
					SqlDataReader dr1 = listele.ExecuteReader();
					Repeater1.DataSource = dr1;
					Repeater1.DataBind();
					bgl.baglanti().Close();
				}
				else //eğer Alıcının istediği fiyatta ürün yoksa istek listesinde tutulacak 
				{
					SqlCommand talep = new SqlCommand("insert into BeklenenUrun values(@p1,@p2,@p3,@p4)",bgl.baglanti());
					talep.Parameters.AddWithValue("@p1", id);
					talep.Parameters.AddWithValue("@p2",UrunKategoriID);
					talep.Parameters.AddWithValue("@p3",TextBox1.Text);
					talep.Parameters.AddWithValue("@p4",TextBox2.Text);
					talep.ExecuteNonQuery();
				}
			}


		}
	}
}