using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace YazilimYapimi
{
	public class Baglanti
	{
		public SqlConnection baglanti()
		{ 
		SqlConnection baglan = new SqlConnection("Data Source=SNC;Initial Catalog=YazilimYapimiMarket;Integrated Security=True");
			baglan.Open();
			return baglan;
		}
	}
}