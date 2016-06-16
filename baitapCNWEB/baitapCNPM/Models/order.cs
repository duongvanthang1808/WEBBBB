namespace baitapCNPM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("order")]
    public partial class order
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int orderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int productID { get; set; }

        public int? quanity { get; set; }

        [StringLength(50)]
        public string color { get; set; }

        [StringLength(10)]
        public string size { get; set; }

        public DateTime? date { get; set; }

        public int? userID { get; set; }
    }
}
