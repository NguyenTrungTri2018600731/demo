namespace _11_9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dependent
    {
        [Key]
        public int dependent_id { get; set; }

        [Required]
        [StringLength(50)]
        public string first_name { get; set; }

        [Required]
        [StringLength(50)]
        public string last_name { get; set; }

        [Required]
        [StringLength(25)]
        public string relationship { get; set; }

        public int employee_id { get; set; }

        public virtual employee employee { get; set; }
    }
}
