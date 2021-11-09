namespace _11_9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            dependents = new HashSet<dependent>();
            employees1 = new HashSet<employee>();
        }

        [Key]
        public int employee_id { get; set; }

        [StringLength(20)]
        public string first_name { get; set; }

        [Required]
        [StringLength(25)]
        public string last_name { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [StringLength(20)]
        public string phone_number { get; set; }

        [Column(TypeName = "date")]
        public DateTime hire_date { get; set; }

        public int job_id { get; set; }

        public decimal salary { get; set; }

        public int? manager_id { get; set; }

        public int? department_id { get; set; }

        public virtual department department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dependent> dependents { get; set; }

        public virtual job job { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee> employees1 { get; set; }

        public virtual employee employee1 { get; set; }
    }
}
