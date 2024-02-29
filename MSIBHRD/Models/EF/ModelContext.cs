using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MSIBHRD.Models.EF;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MDeparteman> MDepartemen { get; set; }

    public virtual DbSet<MKandidat> MKandidats { get; set; }

    public virtual DbSet<MPelamar> MPelamars { get; set; }

    public virtual DbSet<MPosisi> MPosisis { get; set; }

    public virtual DbSet<THasilInterview> THasilInterviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=hrd;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<MDeparteman>(entity =>
        {
            entity.HasKey(e => e.IdDepartemen).HasName("PRIMARY");

            entity.ToTable("m_departemen");

            entity.Property(e => e.IdDepartemen)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_departemen");
            entity.Property(e => e.NamaDepartemen)
                .HasMaxLength(50)
                .HasColumnName("nama_departemen");
        });

        modelBuilder.Entity<MKandidat>(entity =>
        {
            entity.HasKey(e => e.IdKandidat).HasName("PRIMARY");

            entity.ToTable("m_kandidat");

            entity.HasIndex(e => e.IdDepartemen, "id_departemen");

            entity.Property(e => e.IdKandidat)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_kandidat");
            entity.Property(e => e.IdDepartemen)
                .HasColumnType("int(11)")
                .HasColumnName("id_departemen");
            entity.Property(e => e.NamaKandidat)
                .HasMaxLength(100)
                .HasColumnName("nama_kandidat");
            entity.Property(e => e.TanggalLahir).HasColumnName("tanggal_lahir");

            entity.HasOne(d => d.IdDepartemenNavigation).WithMany(p => p.MKandidats)
                .HasForeignKey(d => d.IdDepartemen)
                .HasConstraintName("m_kandidat_ibfk_1");
        });

        modelBuilder.Entity<MPelamar>(entity =>
        {
            entity.HasKey(e => e.IdPelamar).HasName("PRIMARY");

            entity.ToTable("m_pelamar");

            entity.HasIndex(e => e.IdPosisi, "id_posisi");

            entity.Property(e => e.IdPelamar)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_pelamar");
            entity.Property(e => e.IdPosisi)
                .HasColumnType("int(11)")
                .HasColumnName("id_posisi");
            entity.Property(e => e.NamaPelamar)
                .HasMaxLength(100)
                .HasColumnName("nama_pelamar");

            entity.HasOne(d => d.IdPosisiNavigation).WithMany(p => p.MPelamars)
                .HasForeignKey(d => d.IdPosisi)
                .HasConstraintName("m_pelamar_ibfk_1");
        });

        modelBuilder.Entity<MPosisi>(entity =>
        {
            entity.HasKey(e => e.IdPosisi).HasName("PRIMARY");

            entity.ToTable("m_posisi");

            entity.Property(e => e.IdPosisi)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_posisi");
            entity.Property(e => e.NamaPosisi)
                .HasMaxLength(50)
                .HasColumnName("nama_posisi");
        });

        modelBuilder.Entity<THasilInterview>(entity =>
        {
            entity.HasKey(e => e.IdHasil).HasName("PRIMARY");

            entity.ToTable("t_hasil_interview");

            entity.HasIndex(e => e.IdKandidat, "id_kandidat");

            entity.HasIndex(e => e.IdPelamar, "id_pelamar");

            entity.Property(e => e.IdHasil)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_hasil");
            entity.Property(e => e.Hasil)
                .HasMaxLength(50)
                .HasColumnName("hasil");
            entity.Property(e => e.IdKandidat)
                .HasColumnType("int(11)")
                .HasColumnName("id_kandidat");
            entity.Property(e => e.IdPelamar)
                .HasColumnType("int(11)")
                .HasColumnName("id_pelamar");
            entity.Property(e => e.TanggalInterview).HasColumnName("tanggal_interview");

            entity.HasOne(d => d.IdKandidatNavigation).WithMany(p => p.THasilInterviews)
                .HasForeignKey(d => d.IdKandidat)
                .HasConstraintName("t_hasil_interview_ibfk_2");

            entity.HasOne(d => d.IdPelamarNavigation).WithMany(p => p.THasilInterviews)
                .HasForeignKey(d => d.IdPelamar)
                .HasConstraintName("t_hasil_interview_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
