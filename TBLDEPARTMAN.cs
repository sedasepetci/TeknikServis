namespace Deneme
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLDEPARTMAN")]
    public partial class TBLDEPARTMAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLDEPARTMAN()
        {
            TBLPERSONEL = new HashSet<TBLPERSONEL>();
        }

        public byte ID { get; set; }

        [StringLength(50)]
        public string AD { get; set; }

        [StringLength(100)]
        public string ACIKLAMA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLPERSONEL> TBLPERSONEL { get; set; }
    }
}
