using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoAn6KPI.Models
{
    public partial class DoAnTNKPIContext : DbContext
    {
        public DoAnTNKPIContext()
        {
        }

        public DoAnTNKPIContext(DbContextOptions<DoAnTNKPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Caculator> Caculators { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Groupkpi> Groupkpis { get; set; }
        public virtual DbSet<Kpi> Kpis { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Progresslist> Progresslists { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<Targetlist> Targetlists { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ADMIN\\SQLEXPRESS;Database=DoAnTN: KPI;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("ACCOUNT");

                entity.Property(e => e.Username)
                    .ValueGeneratedNever()
                    .HasColumnName("USERNAME");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(250)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Images)
                    .HasMaxLength(250)
                    .HasColumnName("IMAGES");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Permission)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PERMISSION")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Caculator>(entity =>
            {
                entity.HasKey(e => e.Idcal);

                entity.ToTable("CACULATOR");

                entity.Property(e => e.Idcal).HasColumnName("IDCAL");

                entity.Property(e => e.Completeofday)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("COMPLETEOFDAY");

                entity.Property(e => e.Completeofmonth)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("COMPLETEOFMONTH");

                entity.Property(e => e.Cumulative)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("CUMULATIVE");

                entity.Property(e => e.Growup)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("GROWUP");

                entity.Property(e => e.Idemployees)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IDEMPLOYEES")
                    .IsFixedLength(true);

                entity.Property(e => e.Idkpi).HasColumnName("IDKPI");

                entity.Property(e => e.Idteam)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IDTEAM");

                entity.Property(e => e.Kpilastmonth)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("KPILASTMONTH");

                entity.Property(e => e.Kpiofday)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("KPIOFDAY");

                entity.Property(e => e.Namekpi)
                    .HasMaxLength(150)
                    .HasColumnName("NAMEKPI");

                entity.Property(e => e.Numberkpi)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("NUMBERKPI");

                entity.HasOne(d => d.IdkpiNavigation)
                    .WithMany(p => p.Caculators)
                    .HasForeignKey(d => d.Idkpi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CACULATOR_KPIS");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Idemployee);

                entity.ToTable("EMPLOYEES");

                entity.Property(e => e.Idemployee).HasColumnName("IDEMPLOYEE");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("BIRTHDAY");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Idteam).HasColumnName("IDTEAM");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("NAME");

                entity.Property(e => e.Permission)
                    .HasMaxLength(50)
                    .HasColumnName("PERMISSION");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUMBER");

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PHOTO");

                entity.HasOne(d => d.IdteamNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Idteam)
                    .HasConstraintName("FK_EMPLOYEES_TEAM");
            });

            modelBuilder.Entity<Groupkpi>(entity =>
            {
                entity.HasKey(e => e.Idgroupkpi);

                entity.ToTable("GROUPKPI");

                entity.Property(e => e.Idgroupkpi).HasColumnName("IDGROUPKPI");

                entity.Property(e => e.Namegroupkpi)
                    .HasMaxLength(50)
                    .HasColumnName("NAMEGROUPKPI");

                entity.Property(e => e.Quanty)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("QUANTY");
            });

            modelBuilder.Entity<Kpi>(entity =>
            {
                entity.HasKey(e => e.Idkpi);

                entity.ToTable("KPIS");

                entity.Property(e => e.Idkpi).HasColumnName("IDKPI");

                entity.Property(e => e.Idgroupkpi).HasColumnName("IDGROUPKPI");

                entity.Property(e => e.Namekpi)
                    .HasMaxLength(250)
                    .HasColumnName("NAMEKPI");

                entity.Property(e => e.Quanty)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("QUANTY");

                entity.HasOne(d => d.IdgroupkpiNavigation)
                    .WithMany(p => p.Kpis)
                    .HasForeignKey(d => d.Idgroupkpi)
                    .HasConstraintName("FK_KPIS_GROUPKPI");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.Idmanager)
                    .HasName("PK_MANAGERS");

                entity.ToTable("MANAGER");

                entity.Property(e => e.Idmanager)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IDMANAGER");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("BIRTHDAY");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Idteam)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IDTEAM");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("NAME");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUMBER");

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PHOTO");
            });

            modelBuilder.Entity<Progresslist>(entity =>
            {
                entity.HasKey(e => e.Idprogress);

                entity.ToTable("PROGRESSLIST");

                entity.Property(e => e.Idprogress).HasColumnName("IDPROGRESS");

                entity.Property(e => e.Complete)
                      .HasMaxLength(10)
                    .HasColumnName("COMPLETE");

                entity.Property(e => e.Endtime)
                    .HasColumnType("date")
                    .HasColumnName("ENDTIME");

                entity.Property(e => e.Idemployee).HasColumnName("IDEMPLOYEE");

                entity.Property(e => e.Idgroupkpi).HasColumnName("IDGROUPKPI");

                entity.Property(e => e.Idkpi).HasColumnName("IDKPI");

                entity.Property(e => e.Idteam).HasColumnName("IDTEAM");

                entity.Property(e => e.Nameemployee)
                    .HasMaxLength(150)
                    .HasColumnName("NAMEEMPLOYEE");

                entity.Property(e => e.Namegroupkpi)
                    .HasMaxLength(150)
                    .HasColumnName("NAMEGROUPKPI");

                entity.Property(e => e.Namekpi)
                    .HasMaxLength(150)
                    .HasColumnName("NAMEKPI");

                entity.Property(e => e.Nameteam)
                    .HasMaxLength(150)
                    .HasColumnName("NAMETEAM");

                entity.Property(e => e.Starttime)
                    .HasColumnType("date")
                    .HasColumnName("STARTTIME");

                entity.HasOne(d => d.IdemployeeNavigation)
                    .WithMany(p => p.Progresslists)
                    .HasForeignKey(d => d.Idemployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROGRESSLIST_EMPLOYEES");

                entity.HasOne(d => d.IdkpiNavigation)
                    .WithMany(p => p.Progresslists)
                    .HasForeignKey(d => d.Idkpi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROGRESSLIST_KPIS1");

                entity.HasOne(d => d.IdteamNavigation)
                    .WithMany(p => p.Progresslists)
                    .HasForeignKey(d => d.Idteam)
                    .HasConstraintName("FK_PROGRESSLIST_TEAM");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SCORE");

                entity.Property(e => e.Idkpi).HasColumnName("IDKPI");

                entity.Property(e => e.Namekpi)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("NAMEKPI");

                entity.Property(e => e.Percents)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("PERCENTS");

                entity.Property(e => e.Quantykpi)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("QUANTYKPI");

                entity.Property(e => e.Quantymake)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("QUANTYMAKE");

                entity.Property(e => e.Scorekpi)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("SCOREKPI");

                entity.HasOne(d => d.IdkpiNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idkpi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SCORE_KPIS1");
            });

            modelBuilder.Entity<Targetlist>(entity =>
            {
                entity.HasKey(e => e.Idtarget);

                entity.ToTable("TARGETLIST");

                entity.Property(e => e.Idtarget).HasColumnName("IDTARGET");

                entity.Property(e => e.Endtime)
                    .HasColumnType("date")
                    .HasColumnName("ENDTIME");

                entity.Property(e => e.Idemployees).HasColumnName("IDEMPLOYEES");

                entity.Property(e => e.Idgroukpi).HasColumnName("IDGROUKPI");

                entity.Property(e => e.Idkpi).HasColumnName("IDKPI");

                entity.Property(e => e.Idteam).HasColumnName("IDTEAM");

                entity.Property(e => e.Nameemployee)
                    .HasMaxLength(150)
                    .HasColumnName("NAMEEMPLOYEE");

                entity.Property(e => e.Namegroupkpi)
                    .HasMaxLength(150)
                    .HasColumnName("NAMEGROUPKPI");

                entity.Property(e => e.Namekpi)
                    .HasMaxLength(150)
                    .HasColumnName("NAMEKPI");

                entity.Property(e => e.Namemanager)
                    .HasMaxLength(150)
                    .HasColumnName("NAMEMANAGER");

                entity.Property(e => e.Nameteam)
                    .HasMaxLength(150)
                    .HasColumnName("NAMETEAM");

                entity.Property(e => e.Quanty)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("QUANTY");

                entity.Property(e => e.Starttime)
                    .HasColumnType("date")
                    .HasColumnName("STARTTIME");

                entity.HasOne(d => d.IdemployeesNavigation)
                    .WithMany(p => p.Targetlists)
                    .HasForeignKey(d => d.Idemployees)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TARGETLIST_EMPLOYEES");

                entity.HasOne(d => d.IdkpiNavigation)
                    .WithMany(p => p.Targetlists)
                    .HasForeignKey(d => d.Idkpi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TARGETLIST_KPIS");

                entity.HasOne(d => d.IdteamNavigation)
                    .WithMany(p => p.Targetlists)
                    .HasForeignKey(d => d.Idteam)
                    .HasConstraintName("FK_TARGETLIST_TEAM");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Idteam);

                entity.ToTable("TEAM");

                entity.Property(e => e.Idteam).HasColumnName("IDTEAM");

                entity.Property(e => e.Nameteam)
                    .HasMaxLength(250)
                    .HasColumnName("NAMETEAM");

                entity.Property(e => e.Quanty)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("QUANTY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
