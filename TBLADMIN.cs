namespace Deneme
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLADMIN")]
    public partial class TBLADMIN
    {
        public byte ID { get; set; }

        [StringLength(10)]
        public string KULLANICIAD { get; set; }

        [StringLength(10)]
        public string SIFRE { get; set; }
    }
}
