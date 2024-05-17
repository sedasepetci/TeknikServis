namespace Deneme
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLPERSONEL")]
    public partial class TBLPERSONEL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLPERSONEL()
        {
            TBLURUNHAREKET = new HashSet<TBLURUNHAREKET>();
            TBLURUNKABUL = new HashSet<TBLURUNKABUL>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short ID { get; set; }

        [StringLength(30)]
        public string AD { get; set; }

        [StringLength(30)]
        public string SOYAD { get; set; }

        public byte? DEPARTMAN { get; set; }

        [StringLength(100)]
        public string FOTOGRAF { get; set; }

        [StringLength(50)]
        public string MAIL { get; set; }

        [StringLength(20)]
        public string TELEFON { get; set; }

        public virtual TBLDEPARTMAN TBLDEPARTMAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLURUNHAREKET> TBLURUNHAREKET { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLURUNKABUL> TBLURUNKABUL { get; set; }
    }
}
