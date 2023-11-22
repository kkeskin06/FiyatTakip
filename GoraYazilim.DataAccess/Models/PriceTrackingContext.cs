using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GoraYazilim.DataAccess.Models;

public partial class PriceTrackingContext : DbContext
{
    public PriceTrackingContext()
    {
    }

    public PriceTrackingContext(DbContextOptions<PriceTrackingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AltUrun> AltUruns { get; set; }

    public virtual DbSet<Fiyatlandirma> Fiyatlandirmas { get; set; }

    public virtual DbSet<Kategori> Kategoris { get; set; }

    public virtual DbSet<Satici> Saticis { get; set; }

    public virtual DbSet<Urun> Uruns { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
          optionsBuilder.UseSqlServer(@"Server=(LocalDb)\\MSSQLLocalDB;Database=PriceTracking;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AltUrun>(entity =>
        {
            entity.ToTable("AltUrun");

            entity.Property(e => e.AlturunAdi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AlturunFiyat)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Urun).WithMany(p => p.AltUruns)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK_AltUrun_Urun");
        });

        

        modelBuilder.Entity<Fiyatlandirma>(entity =>
        {
            entity.HasKey(e => e.FiyatmandirmaId);

            entity.ToTable("Fiyatlandirma");

            entity.Property(e => e.CozumOrtagiFiyat)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FiyatBaslangicTarihi).HasColumnType("date");
            entity.Property(e => e.FiyatDegisimTarihi).HasColumnType("date");
            entity.Property(e => e.ListeFiyat)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Maliyet)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ParakendeSatisFiyat)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BayiiSatisfiyati)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TabanFiyat)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Urun).WithMany(p => p.Fiyatlandirmas)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK_Fiyatlandirma_Urun");

            entity.HasOne(d => d.Satici).WithMany(p => p.Fiyatlandirmas)
                .HasForeignKey(d => d.SaticiId)
                .HasConstraintName("FK_Fiyatlandirma_Satici");
        });

        modelBuilder.Entity<Kategori>(entity =>
        {
            entity.ToTable("Kategori");

            entity.Property(e => e.KategoriAdi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KategoriBilgisi)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserSurname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserMail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Satici>(entity =>
        {
            entity.ToTable("Satici");

            entity.Property(e => e.SaticiAdi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SaticiAdres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SaticiMail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SaticiTuru)
               .HasMaxLength(50)
               .IsUnicode(false);
            entity.Property(e => e.SaticiTelefon)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Urun).WithMany(p => p.Saticis)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK_Satici_Urun");

            
        });

        modelBuilder.Entity<Urun>(entity =>
        {
            entity.ToTable("Urun");

            entity.Property(e => e.UrunAdi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UrunFiyat)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UrunKodu)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UrunMarkasi)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Kategori).WithMany(p => p.Uruns)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("FK_Urun_Kategori");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
