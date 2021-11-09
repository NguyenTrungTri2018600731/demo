namespace _11_9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public location()
        {
            departments = new HashSet<department>();
        }

        [Key]
        public int location_id { get; set; }

        [StringLength(40)]
        public string street_address { get; set; }

        [StringLength(12)]
        public string postal_code { get; set; }

        [Required]
        [StringLength(30)]
        public string city { get; set; }

        [StringLength(25)]
        public string state_province { get; set; }

        [Required]
        [StringLength(2)]
        public string country_id { get; set; }

        public virtual country country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<department> departments { get; set; }
    }
}
