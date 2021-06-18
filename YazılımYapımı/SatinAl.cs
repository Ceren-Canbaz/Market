using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace YazilimYapimi
{
	public static class SatinAl
	{
		static Baglanti bgl = new Baglanti();
		public static void SatinAlma(Kullanici kullanici,UrunBilgi urun)
		{
			SqlCommand komut = new SqlCommand("Select*From KullaniciBilgi", bgl.baglanti());
			
		}
	}
}