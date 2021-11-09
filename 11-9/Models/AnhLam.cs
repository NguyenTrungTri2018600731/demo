using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace _11_9.Models
{
    public partial class AnhLam : DbContext
    {
        public AnhLam()
            : base("name=AnhLam")
        {
        }

        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<dependent> dependents { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<job> jobs { get; set; }
        public virtual DbSet<location> locations { get; set; }
        public virtual DbSet<region> regions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<country>()
                .Property(e => e.country_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .Property(e => e.country_name)
                .IsUnicode(false);

            modelBuilder.Entity<department>()
                .Property(e => e.department_name)
                .IsUnicode(false);

            modelBuilder.Entity<department>()
                .HasMany(e => e.employees)
                .WithOptional(e => e.department)
                .WillCascadeOnDelete();

            modelBuilder.Entity<dependent>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<dependent>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<dependent>()
                .Property(e => e.relationship)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.salary)
                .HasPrecision(8, 2);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.employees1)
                .WithOptional(e => e.employee1)
                .HasForeignKey(e => e.manager_id);

            modelBuilder.Entity<job>()
                .Property(e => e.job_title)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .Property(e => e.min_salary)
                .HasPrecision(8, 2);

            modelBuilder.Entity<job>()
                .Property(e => e.max_salary)
                .HasPrecision(8, 2);

            modelBuilder.Entity<location>()
                .Property(e => e.street_address)
                .IsUnicode(false);

            modelBuilder.Entity<location>()
                .Property(e => e.postal_code)
                .IsUnicode(false);

            modelBuilder.Entity<location>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<location>()
                .Property(e => e.state_province)
                .IsUnicode(false);

            modelBuilder.Entity<location>()
                .Property(e => e.country_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<location>()
                .HasMany(e => e.departments)
                .WithOptional(e => e.location)
                .WillCascadeOnDelete();

            modelBuilder.Entity<region>()
                .Property(e => e.region_name)
                .IsUnicode(false);
        }
    }
}
