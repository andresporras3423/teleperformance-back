using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace teleperformance_back_api.Models
{
    public partial class teleperformanceContext : DbContext
    {
        public teleperformanceContext()
        {
        }

        public teleperformanceContext(DbContextOptions<teleperformanceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IdentityType> IdentityTypes { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=project-teleperformance.database.windows.net;Initial Catalog=teleperformance;User ID=oscar;Password=Jenny-1997");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<IdentityType>(entity =>
            {
                entity.ToTable("identity_type");

                entity.HasIndex(e => e.Type1, "UQ__identity__9962CF8B731E67B9")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("type1");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.HasIndex(e => new { e.IdentityTypeId, e.IdentityNumber }, "uq_identity")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowEmailMessage).HasColumnName("allow_email_message");

                entity.Property(e => e.AllowPhoneMessage).HasColumnName("allow_phone_message");

                entity.Property(e => e.CanRegister).HasColumnName("can_register");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("company_name");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstLastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_last_name");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.IdentityNumber).HasColumnName("identity_number");

                entity.Property(e => e.IdentityTypeId).HasColumnName("identity_type_id");

                entity.Property(e => e.SecondLastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("second_last_name");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("second_name");

                entity.HasOne(d => d.IdentityType)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.IdentityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("person_identity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
