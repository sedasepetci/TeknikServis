namespace Deneme
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLNOTLARIM")]
    public partial class TBLNOTLARIM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string BASLIK { get; set; }

        [StringLength(500)]
        public string ICERIK { get; set; }

        public bool? OKUMA { get; set; }
    }
}
