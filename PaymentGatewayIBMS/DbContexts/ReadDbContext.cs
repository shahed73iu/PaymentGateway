using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PaymentGatewayIBMS.Models.Read;

#nullable disable

namespace PaymentGatewayIBMS.DbContexts
{
    public partial class ReadDbContext : DbContext
    {
        public ReadDbContext()
        {
        }

        public ReadDbContext(DbContextOptions<ReadDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAccount> TblAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=20.195.36.155,49621;Initial Catalog=iBOSDDD;User ID=isukisespts3vapp8dt;Password=wsa0str1vpo@8d5ws;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAccount>(entity =>
            {
                entity.HasKey(e => e.IntAccountId);

                entity.ToTable("tblAccount", "bill");

                entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");

                entity.Property(e => e.DteCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreatedDate");

                entity.Property(e => e.DteLastModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dteLastModifiedDate");

                entity.Property(e => e.DteServerDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("dteServerDateTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntCreatedBy).HasColumnName("intCreatedBy");

                entity.Property(e => e.IntLastmodifiedBy).HasColumnName("intLastmodifiedBy");

                entity.Property(e => e.IntOwnerNid).HasColumnName("intOwnerNID");

                entity.Property(e => e.IntSmsBalance).HasColumnName("intSmsBalance");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StrBusinessAddress)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("strBusinessAddress");

                entity.Property(e => e.StrBusinessEmail)
                    .HasMaxLength(300)
                    .HasColumnName("strBusinessEmail");

                entity.Property(e => e.StrBusinessLogo)
                    .HasMaxLength(300)
                    .HasColumnName("strBusinessLogo");

                entity.Property(e => e.StrBusinessName)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("strBusinessName");

                entity.Property(e => e.StrEmail)
                    .HasMaxLength(300)
                    .HasColumnName("strEmail");

                entity.Property(e => e.StrMobileNo)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("strMobileNo");

                entity.Property(e => e.StrOwnerName)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("strOwnerName");

                entity.Property(e => e.StrPassword)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("strPassword");

                entity.Property(e => e.StrTradeLicense)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("strTradeLicense");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
