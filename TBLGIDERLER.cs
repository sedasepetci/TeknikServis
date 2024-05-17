namespace Deneme
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLGIDERLER")]
    public partial class TBLGIDERLER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GIDERID { get; set; }

        [StringLength(50)]
        public string GIDERACIKLAMA { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? TARIH { get; set; }

        public decimal? TUTAR { get; set; }
    }
}
