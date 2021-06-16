using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YazilimYapimi
{
	public class Kullanici
	{
		private int urunID;
		private string urunad;
		private double urunfiyat;
		private int urunadet;
		private decimal toplamfiyat;
		private string kullaniciad;
		private double kullanicipara;
		private int kullaniciID;
		

		public int UrunID { get => urunID; set => urunID = value; }
		public string Urunad { get => urunad; set => urunad = value; }
		public double Urunfiyat { get => urunfiyat; set => urunfiyat = value; }
		public int Urunadet { get => urunadet; set => urunadet = value; }
		public decimal Toplamfiyat { get => toplamfiyat; set => toplamfiyat = value; }
		public string Kullaniciad { get => kullaniciad; set => kullaniciad = value; }
		public double Kullanicipara { get => kullanicipara; set => kullanicipara = value; }
		public int KullaniciID { get => kullaniciID; set => kullaniciID = value; }
	}
}