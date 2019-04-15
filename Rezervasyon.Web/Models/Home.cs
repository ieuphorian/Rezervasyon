using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rezervasyon.Web.Models
{
    public class RandevuAlModel
    {
        public string TCNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int DogumTarihi { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Bolum { get; set; }
        public string Okul { get; set; }
        public string OkulNo { get; set; }
    }
    public class RandevuGirisModel
    {
        public string TCNo { get; set; }
    }
}