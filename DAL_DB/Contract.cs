namespace DAL_DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contract")]
    public partial class Contract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contract()
        {
            Building = new HashSet<Building>();
        }

        [Key]
        [StringLength(10)]
        public string ContractNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfSignature { get; set; }

        public int ClientID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Building> Building { get; set; }

        public virtual Client Client { get; set; }
    }
}
