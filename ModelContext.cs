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
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=PROJECT;Password=project;Data Source=10.11.201.203:1523/MBLHRM;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("PROJECT")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CONTACTS");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BIRTHDATE");

                entity.Property(e => e.Chat)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("CHAT");

                entity.Property(e => e.City)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.Company)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY");

                entity.Property(e => e.ContactId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.Department)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Event)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EVENT");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Image)
                    .HasColumnType("BLOB")
                    .HasColumnName("IMAGE");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("JOB_TITLE");

                entity.Property(e => e.LastName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.Notes)
                    .IsUnicode(false)
                    .HasColumnName("NOTES");

                entity.Property(e => e.Phone)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PHONE");

                entity.Property(e => e.PostalCode)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POSTAL_CODE");

                entity.Property(e => e.Relationship)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("RELATIONSHIP");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Website)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("USERID_FK");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Authentication)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("AUTHENTICATION");

                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
