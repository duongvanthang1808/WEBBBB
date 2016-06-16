namespace baitapCNPM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int userID { get; set; }

        [StringLength(20)]
        public string username { get; set; }

        [StringLength(18)]
        public string password { get; set; }

        public int? role_id { get; set; }

        [StringLength(500)]
        public string lineAddress { get; set; }

        [StringLength(11)]
        public string phonenumber { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public virtual role role { get; set; }
    }
}
