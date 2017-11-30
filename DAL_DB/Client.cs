namespace DAL_DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Contract = new HashSet<Contract>();
        }

        [Required]
        [StringLength(60)]
        public string Organization { get; set; }

        [Required]
        [StringLength(60)]
        public string Adress { get; set; }

        [Required]
        [StringLength(60)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(60)]
        public string BankAccount { get; set; }

        [Required]
        [StringLength(60)]
        public string Fax { get; set; }

        public int PostIndex { get; set; }

        public int ClientID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract> Contract { get; set; }
    }
}
