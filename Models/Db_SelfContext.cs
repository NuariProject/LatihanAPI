using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LatihanAPI.Models
{
    public partial class Db_SelfContext : DbContext
    {
        public Db_SelfContext()
        {
        }

        public Db_SelfContext(DbContextOptions<Db_SelfContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MasterBio> MasterBios { get; set; } = null!;
        public virtual DbSet<MasterKotum> MasterKota { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Db_Self;Username=postgres;Password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterBio>(entity =>
            {
                entity.HasKey(e => e.IdBio)
                    .HasName("Master_Biodata");

                entity.ToTable("Master_Bio");

                entity.Property(e => e.IdBio)
                    .HasColumnName("Id_Bio")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, null, true);

                entity.Property(e => e.Deskrispsi).HasMaxLength(100);

                entity.Property(e => e.IdKota).HasColumnName("Id_Kota");

                entity.Property(e => e.Nama).HasMaxLength(50);
            });

            modelBuilder.Entity<MasterKotum>(entity =>
            {
                entity.HasKey(e => e.IdKota)
                    .HasName("Master_Kota_pkey");

                entity.ToTable("Master_Kota");

                entity.Property(e => e.IdKota)
                    .HasColumnName("Id_Kota")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, null, true);

                entity.Property(e => e.IdProvinsi).HasColumnName("Id_Provinsi");

                entity.Property(e => e.NamaKota)
                    .HasMaxLength(50)
                    .HasColumnName("Nama_Kota");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
