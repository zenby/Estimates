namespace DAL_DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkTypes()
        {
            ListOfTheWorks = new HashSet<ListOfTheWorks>();
        }

        [Required]
        [StringLength(80)]
        public string WorkType { get; set; }

        [Key]
        public int WorkID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListOfTheWorks> ListOfTheWorks { get; set; }
    }
}
