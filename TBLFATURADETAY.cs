namespace Deneme
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLFATURADETAY")]
    public partial class TBLFATURADETAY
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FATURADETAYID { get; set; }

        [StringLength(50)]
        public string URUN { get; set; }

        public short? ADET { get; set; }

        public decimal? FIYAT { get; set; }

        public decimal? TUTAR { get; set; }

        public int? FATURAID { get; set; }

        public virtual TBLFATURABILGI TBLFATURABILGI { get; set; }
    }
}
