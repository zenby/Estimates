namespace DAL_DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Building")]
    public partial class Building
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Building()
        {
            ListOfTheWorks = new HashSet<ListOfTheWorks>();
        }

        [Required]
        [StringLength(200)]
        public string NameOfTheObject { get; set; }

        [Key]
        public int ObjectID { get; set; }

        [Column(TypeName = "date")]
        public DateTime IssueDate { get; set; }

        public float Length { get; set; }

        public float Width { get; set; }

        public float Height { get; set; }

        public int Amount { get; set; }

        public bool IsCivil { get; set; }

        public bool IsPreserved { get; set; }

        public bool IsWhileConstruction { get; set; }

        public bool IsMultistory { get; set; }

        public float StoreyHeight { get; set; }

        public float PrimalCoefficient { get; set; }

        public float CostOfTheObject { get; set; }

        [Required]
        [StringLength(60)]
        public string InvNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string ContractNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListOfTheWorks> ListOfTheWorks { get; set; }

        public virtual Contract Contract { get; set; }
    }
}
