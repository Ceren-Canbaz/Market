using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace YazilimYapimi
{
	public class Baglanti
	{
		public  SqlConnection baglanti()
		{
			//Data Source=DESKTOP-TTOQ6J4\\SQLEXPRESS;Initial Catalog=YazilimYapimiMarket;Integrated Security=True ->cerenin veritabanı
			//Data Source = SNC; Initial Catalog = YazilimYapimiMarket; Integrated Security = True -> senanın
			SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-TTOQ6J4\\SQLEXPRESS;Initial Catalog=YazilimYapimiMarket;Integrated Security=True");
			baglan.Open();
			return baglan;
		}
	}
}