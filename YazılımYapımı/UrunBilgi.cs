using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace YazilimYapimi
{
	public class UrunBilgi
	{ 
		private int aliciID;
		private int saticiID;
		private int urunID;
		private int urunKategoriID;
		private double fiyat;
		private int adet;

		public int AliciID { get => aliciID; set => aliciID = value; }
		public int SaticiID { get => saticiID; set => saticiID = value; }
		public int UrunID { get => urunID; set => urunID = value; }
		public int UrunKategoriID { get => urunKategoriID; set => urunKategoriID = value; }
		public double Fiyat { get => fiyat; set => fiyat = value; }
		public int Adet { get => adet; set => adet = value; }

	}
}