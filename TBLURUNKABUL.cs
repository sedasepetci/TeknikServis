namespace Deneme
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLURUNKABUL")]
    public partial class TBLURUNKABUL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ISLEMID { get; set; }

        public int? URUN { get; set; }

        public int? CARI { get; set; }

        public short? PERSONEL { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? GELISTARIHI { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CIKISTARIHI { get; set; }

        [StringLength(5)]
        public string URUNSERINO { get; set; }

        public virtual TBLCARI TBLCARI { get; set; }

        public virtual TBLPERSONEL TBLPERSONEL { get; set; }

        public virtual TBLURUN TBLURUN { get; set; }
    }
}
