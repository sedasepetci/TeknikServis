namespace Deneme
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLFATURABILGI")]
    public partial class TBLFATURABILGI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLFATURABILGI()
        {
            TBLFATURADETAY = new HashSet<TBLFATURADETAY>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(1)]
        public string SERI { get; set; }

        [StringLength(6)]
        public string SIRANO { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? TARIH { get; set; }

        [StringLength(5)]
        public string SAAT { get; set; }

        [StringLength(50)]
        public string VERGIDAIRE { get; set; }

        public int? CARI { get; set; }

        public short? PERSONEL { get; set; }

        public virtual TBLCARI TBLCARI { get; set; }

        public virtual TBLCARI TBLCARI1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLFATURADETAY> TBLFATURADETAY { get; set; }
    }
}
