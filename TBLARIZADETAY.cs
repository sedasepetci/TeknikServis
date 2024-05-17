namespace Deneme
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLARIZADETAY")]
    public partial class TBLARIZADETAY
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ARIZAID { get; set; }

        public int? ISLEM { get; set; }

        [StringLength(250)]
        public string SORUN { get; set; }

        [StringLength(250)]
        public string ACIKLAMA { get; set; }

        public decimal? ONFIYAT { get; set; }

        public decimal? NETFIYAT { get; set; }

        [StringLength(500)]
        public string ISLEMLER { get; set; }
    }
}
