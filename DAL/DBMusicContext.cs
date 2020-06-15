using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class DBMusicContext : DbContext
    {
        public DBMusicContext()
        {
        }

        public DBMusicContext(DbContextOptions<DBMusicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Albumbaihat> Albumbaihat { get; set; }
        public virtual DbSet<Baihat> Baihat { get; set; }
        public virtual DbSet<Casi> Casi { get; set; }
        public virtual DbSet<Nguoidung> Nguoidung { get; set; }
        public virtual DbSet<Playlist> Playlist { get; set; }
        public virtual DbSet<Quantrivien> Quantrivien { get; set; }
        public virtual DbSet<Theloai> Theloai { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=DBMusic;Persist Security Info=True;User ID=sa;Password=2916;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.MaAb)
                    .HasName("PK__ALBUM__27247E58BC9EC1AF");

                entity.ToTable("ALBUM");

                entity.Property(e => e.MaAb)
                    .HasColumnName("MaAB")
                    .HasMaxLength(20);

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.TenAb)
                    .IsRequired()
                    .HasColumnName("TenAB")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Albumbaihat>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__ALBUMBAI__3213C8B7AA741ADC");

                entity.ToTable("ALBUMBAIHAT");

                entity.Property(e => e.Ma)
                    .HasColumnName("ma")
                    .HasMaxLength(20);

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.MaAb)
                    .HasColumnName("MaAB")
                    .HasMaxLength(20);

                entity.Property(e => e.MaBh)
                    .HasColumnName("MaBH")
                    .HasMaxLength(20);

                entity.HasOne(d => d.MaAbNavigation)
                    .WithMany(p => p.Albumbaihat)
                    .HasForeignKey(d => d.MaAb)
                    .HasConstraintName("FK__ALBUMBAIHA__MaAB__22AA2996");

                entity.HasOne(d => d.MaBhNavigation)
                    .WithMany(p => p.Albumbaihat)
                    .HasForeignKey(d => d.MaBh)
                    .HasConstraintName("FK__ALBUMBAIHA__MaBH__239E4DCF");
            });

            modelBuilder.Entity<Baihat>(entity =>
            {
                entity.HasKey(e => e.MaBaiHat)
                    .HasName("PK__BAIHAT__3F65E08EA9AA0002");

                entity.ToTable("BAIHAT");

                entity.Property(e => e.MaBaiHat).HasMaxLength(20);

                entity.Property(e => e.FileLoiBaiHat)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.LinkNhac)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaCaSi).HasMaxLength(20);

                entity.Property(e => e.MaTheLoai).HasMaxLength(20);

                entity.Property(e => e.NgayChinhSua)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NgayTao)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NguoiChinhSua)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.NguoiTao).HasMaxLength(20);

                entity.Property(e => e.QuocGia)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TenBaiHat)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaCaSiNavigation)
                    .WithMany(p => p.Baihat)
                    .HasForeignKey(d => d.MaCaSi)
                    .HasConstraintName("FK__BAIHAT__MaCaSi__1A14E395");

                entity.HasOne(d => d.MaTheLoaiNavigation)
                    .WithMany(p => p.Baihat)
                    .HasForeignKey(d => d.MaTheLoai)
                    .HasConstraintName("FK__BAIHAT__MaTheLoa__1B0907CE");

                entity.HasOne(d => d.NguoiTaoNavigation)
                    .WithMany(p => p.Baihat)
                    .HasForeignKey(d => d.NguoiTao)
                    .HasConstraintName("FK__BAIHAT__NguoiTao__1BFD2C07");
            });

            modelBuilder.Entity<Casi>(entity =>
            {
                entity.HasKey(e => e.MaCaSi)
                    .HasName("PK__CASI__20E428511B5CE780");

                entity.ToTable("CASI");

                entity.Property(e => e.MaCaSi).HasMaxLength(20);

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.GioiTinh)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HinhAnh).HasMaxLength(50);

                entity.Property(e => e.QuocTich)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TenCaSi)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Nguoidung>(entity =>
            {
                entity.HasKey(e => e.MaUser)
                    .HasName("PK__NGUOIDUN__55DAC4B782E0C96B");

                entity.ToTable("NGUOIDUNG");

                entity.Property(e => e.MaUser).HasMaxLength(20);

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.GioiTinh).HasMaxLength(20);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasMaxLength(20);

                entity.Property(e => e.TenUser)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.HasKey(e => e.MaPlayList)
                    .HasName("PK__PLAYLIST__3E949BE145D8F494");

                entity.ToTable("PLAYLIST");

                entity.Property(e => e.MaPlayList).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.MaBaiHat).HasMaxLength(20);

                entity.Property(e => e.MaUser).HasMaxLength(20);

                entity.Property(e => e.TenPlaylist)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaBaiHatNavigation)
                    .WithMany(p => p.Playlist)
                    .HasForeignKey(d => d.MaBaiHat)
                    .HasConstraintName("FK__PLAYLIST__MaBaiH__1ED998B2");

                entity.HasOne(d => d.MaUserNavigation)
                    .WithMany(p => p.Playlist)
                    .HasForeignKey(d => d.MaUser)
                    .HasConstraintName("FK__PLAYLIST__MaUser__1FCDBCEB");
            });

            modelBuilder.Entity<Quantrivien>(entity =>
            {
                entity.HasKey(e => e.MaQuanTri)
                    .HasName("PK__QUANTRIV__05FA934873BF9724");

                entity.ToTable("QUANTRIVIEN");

                entity.Property(e => e.MaQuanTri).HasMaxLength(20);

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.NgaySinh).HasMaxLength(20);

                entity.Property(e => e.TenQtv)
                    .IsRequired()
                    .HasColumnName("TenQTV")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Theloai>(entity =>
            {
                entity.HasKey(e => e.MaTheLoai)
                    .HasName("PK__THELOAI__D73FF34A49E2936D");

                entity.ToTable("THELOAI");

                entity.Property(e => e.MaTheLoai).HasMaxLength(20);

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.TenTheLoai)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
