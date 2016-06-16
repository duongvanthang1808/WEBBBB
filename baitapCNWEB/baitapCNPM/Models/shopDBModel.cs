namespace baitapCNPM.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class shopDBModel : DbContext
    {
        public shopDBModel()
            : base("name=shopDBModel")
        {
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .HasMany(e => e.products)
                .WithRequired(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order>()
                .Property(e => e.size)
                .IsFixedLength();

            modelBuilder.Entity<product>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<product>()
                .Property(e => e.sizes)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.productImage)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.role1)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .HasMany(e => e.users)
                .WithOptional(e => e.role)
                .HasForeignKey(e => e.role_id);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsFixedLength();

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsFixedLength();

            modelBuilder.Entity<user>()
                .Property(e => e.phonenumber)
                .IsUnicode(false);
        }
    }
}
