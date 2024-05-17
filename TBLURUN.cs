namespace Deneme
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLURUN")]
    public partial class TBLURUN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLURUN()
        {
            TBLURUNHAREKET = new HashSet<TBLURUNHAREKET>();
            TBLURUNKABUL = new HashSet<TBLURUNKABUL>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(30)]
        public string AD { get; set; }

        [StringLength(30)]
        public string MARKA { get; set; }

        public decimal? ALISFIYAT { get; set; }

        public decimal? SATISFIYAT { get; set; }

        public short? STOK { get; set; }

        public bool? DURUM { get; set; }

        public byte? KATEGORI { get; set; }

        public virtual TBLKATEGORI TBLKATEGORI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLURUNHAREKET> TBLURUNHAREKET { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLURUNKABUL> TBLURUNKABUL { get; set; }
    }
}
