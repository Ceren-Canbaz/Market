using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;


namespace YazilimYapimi
{
	public partial class Talep : System.Web.UI.Page
	{
		string islem = "";
		string id = "";
		string para = "";
		string doviz = "";
		Baglanti bgl = new Baglanti();
		Kullanici k = new Kullanici();
		protected void Page_Load(object sender, EventArgs e)
		{   //Para onaylama ve silme işlemleri
			if (Page.IsPostBack == false)
			{
				id = Request.QueryString["TalepID"];
				islem = Request.QueryString["islem"];
				para = Request.QueryString["para"];
				doviz = Request.QueryString["doviz"];

			}
			SqlCommand komut = new SqlCommand("SELECT*FROM ParaTalep p inner join KullaniciBilgi k on k.KullaniciID=p.KullaniciID WHERE Durum=0", bgl.baglanti());
			SqlDataReader dr = komut.ExecuteReader();
			Repeater1.DataSource = dr;
			Repeater1.DataBind();

			//Dövizleri xml ile çekiyoruz.
			string path = "https://tcmb.gov.tr/kurlar/today.xml";
			var xmldoc = new XmlDocument();
			xmldoc.Load(path);

			if (islem == "sil")
			{
				SqlCommand sil = new SqlCommand("DELETE FROM ParaTalep WHERE TalepID=@p1", bgl.baglanti());
				sil.Parameters.AddWithValue("@p1", id);
				sil.ExecuteNonQuery();
				bgl.baglanti().Close();
				Response.Redirect("ParaTalep.aspx");
			}
			else if(islem=="onayla")
			{
				SqlCommand komut1 = new SqlCommand("SELECT*FROM ParaTalep p inner join KullaniciBilgi k on k.KullaniciID=p.KullaniciID WHERE TalepID=@p1", bgl.baglanti());
				komut1.Parameters.AddWithValue("@p1", id);
				komut1.ExecuteNonQuery();
				SqlDataReader dr1 = komut1.ExecuteReader();
				Kullanici ent = new Kullanici();
				string money = "1";

				var xml = xmldoc.SelectSingleNode($"Tarih_Date/Currency [@Kod='{doviz}']/BanknoteSelling");


				if (xml!=null)   //Para birimi TRY olursa işlemi '1' değeriyle yapıyoruz
                {
					money = xml.InnerXml;
				}

				para = (decimal.Parse(para) * decimal.Parse(money.Replace('.',','))).ToString(); //Kullanıcının talebini dövizdeki kur değeriyle çarpıyoruz
				
                while (dr1.Read())
				{
					
					ent.KullaniciID = Convert.ToInt32(dr1["KullaniciID"].ToString());
					ent.Kullanicipara= Convert.ToDouble(dr1["KullaniciPara"].ToString());
				}
				dr1.Close();
				ent.Kullanicipara +=Convert.ToDouble(para);
				SqlCommand onayla = new SqlCommand("UPDATE KullaniciBilgi set KullaniciPara=@p1 WHERE KullaniciID=@p2",bgl.baglanti());
				onayla.Parameters.AddWithValue("@p1", ent.Kullanicipara);
				onayla.Parameters.AddWithValue("@p2", ent.KullaniciID);
				onayla.ExecuteNonQuery();
				bgl.baglanti().Close();
				SqlCommand durum = new SqlCommand("UPDATE ParaTalep set Durum=@p1 WHERE TalepID=@p2",bgl.baglanti());
				durum.Parameters.AddWithValue("@p1",1);
				durum.Parameters.AddWithValue("@p2", id);
				durum.ExecuteNonQuery();
				Response.Redirect("ParaTalep.aspx");
			}
			
		}
	}
}