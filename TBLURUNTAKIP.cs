namespace Deneme
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLURUNTAKIP")]
    public partial class TBLURUNTAKIP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TAKIPID { get; set; }

        public int? URUN { get; set; }

        [StringLength(250)]
        public string DURUM { get; set; }

        public int? TARIH { get; set; }

        [StringLength(5)]
        public string TAKIPKODU { get; set; }
    }
}
