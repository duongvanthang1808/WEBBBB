namespace baitapCNPM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int productID { get; set; }

        [Required]
        [StringLength(100)]
        public string productName { get; set; }

        public decimal price { get; set; }

        [StringLength(50)]
        public string colors { get; set; }

        [StringLength(50)]
        public string sizes { get; set; }

        [StringLength(500)]
        public string productImage { get; set; }

        public int categoryID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateCreated { get; set; }

        public bool? status { get; set; }

        public int? quanity { get; set; }

        public virtual category category { get; set; }
    }
}
