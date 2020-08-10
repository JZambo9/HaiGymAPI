using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HayGym_API.Models
{
    public partial class HaiGymContext : DbContext
    {
        public HaiGymContext()
        {
        }

        public HaiGymContext(DbContextOptions<HaiGymContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appunto> Appunto { get; set; }
        public virtual DbSet<Atleta> Atleta { get; set; }
        public virtual DbSet<AttrEsercizio> AttrEsercizio { get; set; }
        public virtual DbSet<Attrezzo> Attrezzo { get; set; }
        public virtual DbSet<Esercizio> Esercizio { get; set; }
        public virtual DbSet<Giorno> Giorno { get; set; }
        public virtual DbSet<MuscEsercizio> MuscEsercizio { get; set; }
        public virtual DbSet<Muscolo> Muscolo { get; set; }
        public virtual DbSet<Ripetizione> Ripetizione { get; set; }
        public virtual DbSet<Scheda> Scheda { get; set; }
        public virtual DbSet<Serie> Serie { get; set; }
        public virtual DbSet<TipoEsercizio> TipoEsercizio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-G4A4C9N\\MSSQLSERVER2017;Database=HaiGym;User Id=VISIONUSER; Password=vsgevsge;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appunto>(entity =>
            {
                entity.HasKey(e => e.IdAppunto);

                entity.Property(e => e.IdAppunto).HasColumnName("ID_Appunto");

                entity.Property(e => e.Data).HasColumnType("smalldatetime");

                entity.Property(e => e.IdRipetizione).HasColumnName("ID_Ripetizione");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.Peso).HasColumnType("decimal(3, 3)");

                entity.HasOne(d => d.IdRipetizioneNavigation)
                    .WithMany(p => p.Appunto)
                    .HasForeignKey(d => d.IdRipetizione)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appunto_Ripetizione");
            });

            modelBuilder.Entity<Atleta>(entity =>
            {
                entity.HasKey(e => e.IdAtleta);

                entity.Property(e => e.IdAtleta).HasColumnName("ID_Atleta");

                entity.Property(e => e.Cognome).HasMaxLength(50);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AttrEsercizio>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdAttrezzo).HasColumnName("ID_Attrezzo");

                entity.Property(e => e.IdEsercizio).HasColumnName("ID_Esercizio");

                entity.HasOne(d => d.IdAttrezzoNavigation)
                    .WithMany(p => p.AttrEsercizio)
                    .HasForeignKey(d => d.IdAttrezzo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attrezzo");

                entity.HasOne(d => d.IdEsercizioNavigation)
                    .WithMany(p => p.AttrEsercizio)
                    .HasForeignKey(d => d.IdEsercizio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Esercizio");
            });

            modelBuilder.Entity<Attrezzo>(entity =>
            {
                entity.HasKey(e => e.IdAttrezzo);

                entity.Property(e => e.IdAttrezzo).HasColumnName("ID_Attrezzo");

                entity.Property(e => e.NomeAttrezzo)
                    .IsRequired()
                    .HasColumnName("Nome_Attrezzo")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Esercizio>(entity =>
            {
                entity.HasKey(e => e.IdEsercizio)
                    .HasName("PK_Table_1");

                entity.Property(e => e.IdEsercizio)
                    .HasColumnName("ID_Esercizio")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdTipo).HasColumnName("ID_Tipo");

                entity.Property(e => e.NomeEsercizio)
                    .IsRequired()
                    .HasColumnName("Nome_Esercizio")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Esercizio)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tipo_Esercizio");
            });

            modelBuilder.Entity<Giorno>(entity =>
            {
                entity.HasKey(e => e.IdGiorno);

                entity.Property(e => e.IdGiorno).HasColumnName("ID_Giorno");

                entity.Property(e => e.IdScheda).HasColumnName("ID_Scheda");

                entity.HasOne(d => d.IdSchedaNavigation)
                    .WithMany(p => p.Giorno)
                    .HasForeignKey(d => d.IdScheda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Giorno_Scheda");
            });

            modelBuilder.Entity<MuscEsercizio>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdEsercizio).HasColumnName("ID_Esercizio");

                entity.Property(e => e.IdMuscolo).HasColumnName("ID_Muscolo");

                entity.HasOne(d => d.IdEsercizioNavigation)
                    .WithMany(p => p.MuscEsercizio)
                    .HasForeignKey(d => d.IdEsercizio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eserc");

                entity.HasOne(d => d.IdMuscoloNavigation)
                    .WithMany(p => p.MuscEsercizio)
                    .HasForeignKey(d => d.IdMuscolo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Muscolo");
            });

            modelBuilder.Entity<Muscolo>(entity =>
            {
                entity.HasKey(e => e.IdMuscolo);

                entity.Property(e => e.IdMuscolo).HasColumnName("ID_Muscolo");

                entity.Property(e => e.NomeMuscolo)
                    .IsRequired()
                    .HasColumnName("Nome_Muscolo")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ripetizione>(entity =>
            {
                entity.HasKey(e => e.IdRipetizione);

                entity.Property(e => e.IdRipetizione).HasColumnName("ID_Ripetizione");

                entity.Property(e => e.IdSerie).HasColumnName("ID_Serie");

                entity.Property(e => e.MaxReps).HasColumnName("Max_Reps");

                entity.Property(e => e.MinReps).HasColumnName("Min_Reps");

                entity.Property(e => e.NumSet).HasColumnName("Num_Set");

                entity.HasOne(d => d.IdSerieNavigation)
                    .WithMany(p => p.Ripetizione)
                    .HasForeignKey(d => d.IdSerie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ripetizione_Serie");
            });

            modelBuilder.Entity<Scheda>(entity =>
            {
                entity.HasKey(e => e.IdScheda);

                entity.Property(e => e.IdScheda).HasColumnName("ID_Scheda");

                entity.Property(e => e.DataFine)
                    .HasColumnName("Data_Fine")
                    .HasColumnType("date");

                entity.Property(e => e.DataInizio)
                    .HasColumnName("Data_Inizio")
                    .HasColumnType("date");

                entity.Property(e => e.IdAtleta)
                    .IsRequired()
                    .HasColumnName("ID_Atleta")
                    .HasMaxLength(450);

                entity.HasOne(d => d.IdAtletaNavigation)
                    .WithMany(p => p.Scheda)
                    .HasForeignKey(d => d.IdAtleta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Atleta_Scheda");
            });

            modelBuilder.Entity<Serie>(entity =>
            {
                entity.HasKey(e => e.IdSerie);

                entity.Property(e => e.IdSerie).HasColumnName("ID_Serie");

                entity.Property(e => e.IdEsercizio).HasColumnName("ID_Esercizio");

                entity.Property(e => e.IdGiorno).HasColumnName("ID_Giorno");

                entity.HasOne(d => d.IdEsercizioNavigation)
                    .WithMany(p => p.Serie)
                    .HasForeignKey(d => d.IdEsercizio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Esercizio_Serie");

                entity.HasOne(d => d.IdGiornoNavigation)
                    .WithMany(p => p.Serie)
                    .HasForeignKey(d => d.IdGiorno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Serie_Giorno");
            });

            modelBuilder.Entity<TipoEsercizio>(entity =>
            {
                entity.HasKey(e => e.IdTipo);

                entity.Property(e => e.IdTipo).HasColumnName("ID_Tipo");

                entity.Property(e => e.NomeTipo)
                    .IsRequired()
                    .HasColumnName("Nome_Tipo")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
