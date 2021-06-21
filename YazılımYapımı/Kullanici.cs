using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YazilimYapimi
{
	public class Kullanici
	{
		private int urunID;
		private int urunKategoriID;
		private string urunad;
		private double urunfiyat;
		private int urunadet;
		private decimal toplamfiyat;
		private string kullaniciad;
		private double kullanicipara;
		private int kullaniciID;
		private int saticiID;
		private int aliciID;
		private int istekID;

		public int UrunID { get => urunID; set => urunID = value; }
		public string Urunad { get => urunad; set => urunad = value; }
		public double Urunfiyat { get => urunfiyat; set => urunfiyat = value; }
		public int Urunadet { get => urunadet; set => urunadet = value; }
		public decimal Toplamfiyat { get => toplamfiyat; set => toplamfiyat = value; }
		public string Kullaniciad { get => kullaniciad; set => kullaniciad = value; }
		public double Kullanicipara { get => kullanicipara; set => kullanicipara = value; }
		public int KullaniciID { get => kullaniciID; set => kullaniciID = value; }
		public int UrunKategoriID { get => urunKategoriID; set => urunKategoriID = value; }
		public int SaticiID { get => saticiID; set => saticiID = value; }
		public int AliciID { get => aliciID; set => aliciID = value; }
		public int IstekID { get => istekID; set => istekID = value; }
	}
}
