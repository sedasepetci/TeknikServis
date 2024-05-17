namespace Deneme
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLCARI")]
    public partial class TBLCARI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLCARI()
        {
            TBLFATURABILGI = new HashSet<TBLFATURABILGI>();
            TBLFATURABILGI1 = new HashSet<TBLFATURABILGI>();
            TBLURUNHAREKET = new HashSet<TBLURUNHAREKET>();
            TBLURUNKABUL = new HashSet<TBLURUNKABUL>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(30)]
        public string AD { get; set; }

        [StringLength(30)]
        public string SOYAD { get; set; }

        [StringLength(20)]
        public string TELEFON { get; set; }

        [StringLength(50)]
        public string MAIL { get; set; }

        [StringLength(13)]
        public string IL { get; set; }

        [StringLength(30)]
        public string ILCE { get; set; }

        [StringLength(50)]
        public string BANKA { get; set; }

        [StringLength(50)]
        public string VERGIDAIRESI { get; set; }

        [StringLength(50)]
        public string VERGINO { get; set; }

        [StringLength(50)]
        public string STATU { get; set; }

        [StringLength(250)]
        public string ADRES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLFATURABILGI> TBLFATURABILGI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLFATURABILGI> TBLFATURABILGI1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLURUNHAREKET> TBLURUNHAREKET { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLURUNKABUL> TBLURUNKABUL { get; set; }
    }
}
