namespace Deneme
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLURUNHAREKET")]
    public partial class TBLURUNHAREKET
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HAREKETID { get; set; }

        public int? URUN { get; set; }

        public int? MUSTERI { get; set; }

        public short? PERSONEL { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? TARIH { get; set; }

        public short? ADET { get; set; }

        public decimal? FIYAT { get; set; }

        [StringLength(5)]
        public string URUNSERINO { get; set; }

        public virtual TBLCARI TBLCARI { get; set; }

        public virtual TBLPERSONEL TBLPERSONEL { get; set; }

        public virtual TBLURUN TBLURUN { get; set; }
    }
}
