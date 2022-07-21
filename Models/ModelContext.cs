using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ContactManagement
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<UserRrgistration> UserRrgistrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=PROJECT;Password=project;Data Source=10.11.201.203:1523/mblhrm;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("PROJECT")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("CONTACTS");

                entity.Property(e => e.ContactId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CONTACT_ID")
                    .HasDefaultValueSql("\"PROJECT\".\"CONTACTS_ID_PK\".nextval ");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTHDATE");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY");

                entity.Property(e => e.Department)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Event)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EVENT");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Image)
                    .HasColumnType("BLOB")
                    .HasColumnName("IMAGE");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("JOB_TITLE");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.Notes)
                    .IsUnicode(false)
                    .HasColumnName("NOTES");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POSTAL_CODE");

                entity.Property(e => e.Relationship)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RELATIONSHIP");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Website)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE");
            });

            modelBuilder.Entity<UserRrgistration>(entity =>
            {
                entity.ToTable("USER_RRGISTRATION");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID")
                    .HasDefaultValueSql("\"PROJECT\".\"USER_RRGISTRATION_PK\".nextval ");

                entity.Property(e => e.Created)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Isauthorized)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISAUTHORIZED");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phonenumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUMBER");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Updated)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED");
            });

            modelBuilder.HasSequence("CONTACTS_ID_PK");

            modelBuilder.HasSequence("USER_RRGISTRATION_PK");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
