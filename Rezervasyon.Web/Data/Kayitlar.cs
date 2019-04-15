namespace Rezervasyon.Web.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kayitlar")]
    public partial class Kayitlar
    {
        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string TCNo { get; set; }

        [Required]
        [StringLength(128)]
        public string AdSoyad { get; set; }

        public int DogumTarihi { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefon { get; set; }

        [Required]
        [StringLength(128)]
        public string Email { get; set; }

        [Required]
        [StringLength(128)]
        public string Bolum { get; set; }

        [Required]
        [StringLength(128)]
        public string Okul { get; set; }

        [StringLength(50)]
        public string OkulNo { get; set; }

        public int ToplamGirisSayisi { get; set; }
    }
}
