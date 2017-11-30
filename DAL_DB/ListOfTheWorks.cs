namespace DAL_DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ListOfTheWorks
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ObjectID { get; set; }

        public int ComplexityCategoryOfWork { get; set; }

        public float AverageCoefOfComplecity { get; set; }

        public float Coefficient { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkID { get; set; }

        public virtual Building Building { get; set; }

        public virtual WorkTypes WorkTypes { get; set; }
    }
}
