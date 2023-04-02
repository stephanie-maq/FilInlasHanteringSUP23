using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FISSUP23.Database.Models;

public partial class SsisGenericReadContext : DbContext
{
    public SsisGenericReadContext()
    {
    }

    public SsisGenericReadContext(DbContextOptions<SsisGenericReadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Datatyp> Datatyps { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<Fil> Fils { get; set; }

    public virtual DbSet<FilDatatyp> FilDatatyps { get; set; }

    public virtual DbSet<FilKollektion> FilKollektions { get; set; }

    public virtual DbSet<Filtyp> Filtyps { get; set; }

    public virtual DbSet<Inlasning> Inlasnings { get; set; }

    public virtual DbSet<Kolumn> Kolumns { get; set; }

    public virtual DbSet<KolumnDatatyp> KolumnDatatyps { get; set; }


    public virtual DbSet<Logg> Loggs { get; set; }

    public virtual DbSet<Lookup> Lookups { get; set; }

    public virtual DbSet<LookupKolumn> LookupKolumns { get; set; }

    public virtual DbSet<LookupTyp> LookupTyps { get; set; }

    public virtual DbSet<NyOverforing> NyOverforings { get; set; }

    public virtual DbSet<Overforing> Overforings { get; set; }


    public virtual DbSet<RawDataKolumner> RawDataKolumners { get; set; }

    public virtual DbSet<RawDataParsed> RawDataParseds { get; set; }

    public virtual DbSet<RawDatum> RawData { get; set; }

    public virtual DbSet<Tabell> Tabells { get; set; }

    public virtual DbSet<Test> Tests { get; set; }




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,57000;Database=SSIS_GenericRead;User Id=SA;Password=Str#ng_Passw#rd;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Datatyp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Datatyper");

            entity.ToTable("Datatyp", "import");

            entity.Property(e => e.Fig1).HasColumnName("fig1");
            entity.Property(e => e.Fig2).HasColumnName("fig2");
            entity.Property(e => e.IsNullable).HasColumnName("is_nullable");
            entity.Property(e => e.MaxLength).HasColumnName("max_length");
            entity.Property(e => e.Namn).HasMaxLength(128);
            entity.Property(e => e.Precision).HasColumnName("precision");
            entity.Property(e => e.Scale).HasColumnName("scale");
            entity.Property(e => e.SystemTypeId).HasColumnName("system_type_id");
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.ToTable("ErrorLog", "import");

            entity.Property(e => e.ErrorText).IsUnicode(false);
            entity.Property(e => e.Tid).HasColumnType("datetime");
        });

        modelBuilder.Entity<Fil>(entity =>
        {
            entity.ToTable("Fil", "import");

            entity.Property(e => e.Beskrivning)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.KolumnSeparator)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MatchMonster)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Namn)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.FilKollektion).WithMany(p => p.Fils)
                .HasForeignKey(d => d.FilKollektionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fil_FilKollektion");
        });

        modelBuilder.Entity<FilDatatyp>(entity =>
        {
            entity.ToTable("Fil_Datatyp", "import");

            entity.HasOne(d => d.Datatyp).WithMany(p => p.FilDatatyps)
                .HasForeignKey(d => d.DatatypId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fil_Datatyp_Datatyper");

            entity.HasOne(d => d.Fil).WithMany(p => p.FilDatatyps)
                .HasForeignKey(d => d.FilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fil_Datatyp_Kolumn");
        });

        modelBuilder.Entity<FilKollektion>(entity =>
        {
            entity.ToTable("FilKollektion", "import");

            entity.Property(e => e.Andelse)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Beskrivning)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FolderArkiv)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FolderFelaktigFil)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FolderNyFil)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FolderRoot)
                .HasMaxLength(511)
                .IsUnicode(false);
            entity.Property(e => e.MatchMonster)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Namn)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.FilTyp).WithMany(p => p.FilKollektions)
                .HasForeignKey(d => d.FilTypId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FilKollektion_Filtyp");

            entity.HasOne(d => d.Overforing).WithMany(p => p.FilKollektions)
                .HasForeignKey(d => d.OverforingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FilKollektion_Overforing");
        });

        modelBuilder.Entity<Filtyp>(entity =>
        {
            entity.ToTable("Filtyp", "import");

            entity.Property(e => e.Andelse)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Beskrivning)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Namn)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PunktAndelse)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasComputedColumnSql("(concat('.',[Andelse]))", false);
        });

        modelBuilder.Entity<Inlasning>(entity =>
        {
            entity.ToTable("Inlasning", "import");
            
            entity.Property(e => e.DatumTid).HasColumnType("datetime");
            entity.Property(e => e.FilNamn)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Namn)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.ErrorLog).WithMany(p => p.Inlasnings)
                .HasForeignKey(d => d.ErrorLogId)
                .HasConstraintName("FK_Inlasning_ErrorLog");

            entity.HasOne(d => d.Fil).WithMany(p => p.Inlasnings)
                .HasForeignKey(d => d.FilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inlasning_Fil");
        });

        modelBuilder.Entity<Kolumn>(entity =>
        {
            entity.ToTable("Kolumn", "import");

            entity.Property(e => e.InNamn)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UtNamn)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Fil).WithMany(p => p.Kolumns)
                .HasForeignKey(d => d.FilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Kolumn_Fil");

            entity.HasOne(d => d.Inlasning).WithMany(p => p.Kolumns)
                .HasForeignKey(d => d.InlasningId)
                .HasConstraintName("FK_Kolumn_Inlasning");
        });

        modelBuilder.Entity<KolumnDatatyp>(entity =>
        {
            entity.ToTable("Kolumn_Datatyp", "import");

            entity.HasOne(d => d.Datatyp).WithMany(p => p.KolumnDatatyps)
                .HasForeignKey(d => d.DatatypId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Kolumn_Datatyp_Datatyper");

            entity.HasOne(d => d.Kolumn).WithMany(p => p.KolumnDatatyps)
                .HasForeignKey(d => d.KolumnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Kolumn_Datatyp_Kolumn");
        });


        modelBuilder.Entity<Logg>(entity =>
        {
            entity.ToTable("Logg", "import");

            entity.Property(e => e.AktuellFil)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Handelse)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Loggtext).IsUnicode(false);
            entity.Property(e => e.SokFil)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tid).HasColumnType("datetime");
        });

        modelBuilder.Entity<Lookup>(entity =>
        {
            entity.ToTable("Lookup", "import");

            entity.HasOne(d => d.Fil).WithMany(p => p.Lookups)
                .HasForeignKey(d => d.FilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lookup_Fil");

            entity.HasOne(d => d.LookupTyp).WithMany(p => p.Lookups)
                .HasForeignKey(d => d.LookupTypId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lookup_LookupTyp");
        });

        modelBuilder.Entity<LookupKolumn>(entity =>
        {
            entity.ToTable("Lookup_Kolumn", "import");

            entity.HasOne(d => d.Kolumn).WithMany(p => p.LookupKolumns)
                .HasForeignKey(d => d.KolumnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lookup_Kolumn_Kolumn");

            entity.HasOne(d => d.Lookup).WithMany(p => p.LookupKolumns)
                .HasForeignKey(d => d.LookupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lookup_Kolumn_Lookup");
        });

        modelBuilder.Entity<LookupTyp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LookupType");

            entity.ToTable("LookupTyp", "import");

            entity.Property(e => e.Namn)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NyOverforing>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NyOverforing", "temp");

            entity.Property(e => e.Beskrivning).HasMaxLength(255);
            entity.Property(e => e.Namn).HasMaxLength(255);
            entity.Property(e => e.SystemNamn).HasMaxLength(255);
        });

        modelBuilder.Entity<Overforing>(entity =>
        {
            entity.ToTable("Overforing", "import");

            entity.Property(e => e.Beskrivning)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Namn)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SystemNamn)
                .HasMaxLength(255)
                .IsUnicode(false);
        });


        modelBuilder.Entity<RawDataKolumner>(entity =>
        {
            entity.ToTable("RawDataKolumner", "import");

            entity.Property(e => e.InlasningId).HasColumnName("InlasningID");
            entity.Property(e => e.RawData)
                .HasMaxLength(2047)
                .IsUnicode(false);

            entity.HasOne(d => d.Fil).WithMany(p => p.RawDataKolumners)
                .HasForeignKey(d => d.FilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RawDataKolumner_Fil");

            entity.HasOne(d => d.Inlasning).WithMany(p => p.RawDataKolumners)
                .HasForeignKey(d => d.InlasningId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RawDataKolumner_Inlasning");
        });

        modelBuilder.Entity<RawDataParsed>(entity =>
        {
            entity.ToTable("RawDataParsed", "import");

            entity.Property(e => e.InlasningId).HasColumnName("InlasningID");
            entity.Property(e => e.RawDataParsed1)
                .HasMaxLength(2047)
                .IsUnicode(false)
                .HasColumnName("RawDataParsed");

            entity.HasOne(d => d.Fil).WithMany(p => p.RawDataParseds)
                .HasForeignKey(d => d.FilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RawDataParsed_Fil");

            entity.HasOne(d => d.Inlasning).WithMany(p => p.RawDataParseds)
                .HasForeignKey(d => d.InlasningId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RawDataParsed_Inlasning");
        });

        modelBuilder.Entity<RawDatum>(entity =>
        {
            entity.ToTable("RawData", "import");

            entity.Property(e => e.InlasningId).HasColumnName("InlasningID");
            entity.Property(e => e.RawData)
                .HasMaxLength(2047)
                .IsUnicode(false);

            entity.HasOne(d => d.Fil).WithMany(p => p.RawData)
                .HasForeignKey(d => d.FilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RawData_Fil");

            entity.HasOne(d => d.Inlasning).WithMany(p => p.RawData)
                .HasForeignKey(d => d.InlasningId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RawData_Inlasning");
        });

        modelBuilder.Entity<Tabell>(entity =>
        {
            entity.ToTable("Tabell", "import");

            entity.Property(e => e.Beskrivning)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Modifierad).HasColumnType("datetime");
            entity.Property(e => e.Namn)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Schema)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SkapadInlasningId).HasColumnName("Skapad_InlasningId");
            entity.Property(e => e.TabellNamn)
                .HasMaxLength(517)
                .HasComputedColumnSql("(concat_ws('.',quotename([Schema]),quotename([Namn])))", false);
            entity.Property(e => e.VyNamn)
                .HasMaxLength(517)
                .HasComputedColumnSql("(concat_ws('.',quotename([VySchema]),quotename(concat([VyPrefix],[Namn]))))", false);
            entity.Property(e => e.VyNamnLookup)
                .HasMaxLength(517)
                .HasComputedColumnSql("(concat_ws('.',quotename([VySchema]),quotename(concat([VyPrefix],[Namn],'_LookUp'))))", false);
            entity.Property(e => e.VyPrefix)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.VySchema)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Fil).WithMany(p => p.Tabells)
                .HasForeignKey(d => d.FilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tabell_Fil");

            entity.HasOne(d => d.SkapadInlasning).WithMany(p => p.Tabells)
                .HasForeignKey(d => d.SkapadInlasningId)
                .HasConstraintName("FK_Tabell_Inlasning");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Test", "import");

            entity.Property(e => e.DatumTid).HasColumnType("datetime");
            entity.Property(e => e.SystemNamn)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

       

       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
