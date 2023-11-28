using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using mnglabs.genomemanager.ui.services.Data.Entities;

namespace mnglabs.genomemanager.ui.services.Data
{
    public partial class DataManagerContext : DbContext
    {
        public DataManagerContext()
        {
        }

        public DataManagerContext(DbContextOptions<DataManagerContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Hgncgene> Hgncgenes { get; set; }

        public virtual DbSet<HgncgeneInfo> HgncgeneInfos { get; set; }

        public virtual DbSet<HgncmappingTable> HgncmappingTables { get; set; }

        public virtual DbSet<IgclassificationMap> IgclassificationMaps { get; set; }

        public virtual DbSet<IgpreferredRefseqTranscript> IgpreferredRefseqTranscripts { get; set; }

        public virtual DbSet<Igvariant> Igvariants { get; set; }

        public virtual DbSet<LocusGene> LocusGenes { get; set; }

        public virtual DbSet<Ntallele> Ntalleles { get; set; }

        public virtual DbSet<PatientCase> PatientCases { get; set; }

        public virtual DbSet<PatientCasePheno> PatientCasePhenos { get; set; }

        public virtual DbSet<PatientCaseReqPheno> PatientCaseReqPhenos { get; set; }

        public virtual DbSet<PatientSample> PatientSamples { get; set; }

        public virtual DbSet<ReqPheno> ReqPhenos { get; set; }

        public virtual DbSet<SampleCoverage> SampleCoverages { get; set; }

        public virtual DbSet<SampleVariant> SampleVariants { get; set; }

        public virtual DbSet<SampleVariantInfo> SampleVariantInfos { get; set; }

        public virtual DbSet<SelectedTranscript> SelectedTranscripts { get; set; }

        public virtual DbSet<SelectedVariant> SelectedVariants { get; set; }

        public virtual DbSet<Srtnarrow> Srtnarrows { get; set; }

        public virtual DbSet<StatusWarning> StatusWarnings { get; set; }

        public virtual DbSet<StringProteinAction> StringProteinActions { get; set; }

        public virtual DbSet<StringProteinDetailedLink> StringProteinDetailedLinks { get; set; }

        public virtual DbSet<StringProteinLink> StringProteinLinks { get; set; }

        public virtual DbSet<TestCodeAnalytesNarrow> TestCodeAnalytesNarrows { get; set; }

        public virtual DbSet<TestCodePhenoGrp> TestCodePhenoGrps { get; set; }

        public virtual DbSet<V7captureGeneInfo> V7captureGeneInfos { get; set; }

        public virtual DbSet<VCdsbedRegionPadded> VCdsbedRegionPaddeds { get; set; }

        public virtual DbSet<VClinvarPathogenicLocu> VClinvarPathogenicLocus { get; set; }

        public virtual DbSet<VEnsemblGeneTestCode> VEnsemblGeneTestCodes { get; set; }

        public virtual DbSet<VGeneBedRegionPadded> VGeneBedRegionPaddeds { get; set; }

        public virtual DbSet<VLocusWithPathogenicVariant> VLocusWithPathogenicVariants { get; set; }

        public virtual DbSet<VPanelCdsbedRegionPadded> VPanelCdsbedRegionPaddeds { get; set; }

        public virtual DbSet<VPanelGeneBedRegionPadded> VPanelGeneBedRegionPaddeds { get; set; }

        public virtual DbSet<VPatientCasePheno> VPatientCasePhenos { get; set; }

        public virtual DbSet<VPatientTestCode> VPatientTestCodes { get; set; }

        public virtual DbSet<VSampleTestCodePhenoGroup> VSampleTestCodePhenoGroups { get; set; }

        public virtual DbSet<VUserClass> VUserClasses { get; set; }

        public virtual DbSet<Variant> Variants { get; set; }

        public virtual DbSet<VariantClassification> VariantClassifications { get; set; }

        public virtual DbSet<VariantCriterion> VariantCriteria { get; set; }

        public virtual DbSet<VariantFilterMetaProcessingDeprecated> VariantFilterMetaProcessingDeprecateds { get; set; }

        public virtual DbSet<VariantFilterMetum> VariantFilterMeta { get; set; }

        public virtual DbSet<VariantInterpretation> VariantInterpretations { get; set; }

        public virtual DbSet<VariantLocu> VariantLocus { get; set; }

        public virtual DbSet<VariantNote> VariantNotes { get; set; }

        public virtual DbSet<VariantTranscriptConsequence> VariantTranscriptConsequences { get; set; }

        public virtual DbSet<VariantTranscriptConsequenceOld> VariantTranscriptConsequenceOlds { get; set; }

        public virtual DbSet<VariantTransferIgsnapshot> VariantTransferIgsnapshots { get; set; }

        public virtual DbSet<VariantTransferIgsnapshotBackup> VariantTransferIgsnapshotBackups { get; set; }

        public virtual DbSet<VariantTransferMngsnapshot> VariantTransferMngsnapshots { get; set; }

        public virtual DbSet<Vepterm> Vepterms { get; set; }

        public virtual DbSet<VersionedCaseResult> VersionedCaseResults { get; set; }

        public virtual DbSet<VersionedSampleEvent> VersionedSampleEvents { get; set; }

        public virtual DbSet<WorklistSampleExclusion> WorklistSampleExclusions { get; set; }

        public virtual DbSet<WorklistSupervisor> WorklistSupervisors { get; set; }
        public virtual DbSet<UserLoginAttempt> UserLoginAttempts { get; set; }

        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //        => optionsBuilder.UseSqlServer("Data Source=mng-dbi-mssql-d001.cku3kfglpdjk.us-east-1.rds.amazonaws.com;Initial Catalog=DataManager;Persist Security Info=false;User ID=congos;Password=Alexander2054;TrustServerCertificate=true");

        public IQueryable<VariantDisplay> CatSelected(int patientSampleId, string testCode)
        => FromExpression(() => CatSelected(patientSampleId, testCode));

        public IQueryable<VariantDisplay> CatAnyNoFilter(int patientSampleId, string testCode, int category)
            => FromExpression(() => CatAnyNoFilter(patientSampleId, testCode, category));
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Hgncgene>(entity =>
            {
                entity.HasKey(e => e.HgncId);

                entity.ToTable("HGNCGene");

                entity.Property(e => e.HgncId)
                    .ValueGeneratedNever()
                    .HasColumnName("HGNC ID");
                entity.Property(e => e.ApprovedName)
                    .HasMaxLength(122)
                    .IsUnicode(false)
                    .HasColumnName("Approved name");
                entity.Property(e => e.ApprovedSymbol)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Approved symbol");
                entity.Property(e => e.Status)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HgncgeneInfo>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("HGNCGeneInfo");

                entity.HasIndex(e => e.HgncId, "IX_HGNCGeneInfo");

                entity.Property(e => e.AliasName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Alias name");
                entity.Property(e => e.AliasSymbol)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("Alias symbol");
                entity.Property(e => e.ApprovedName)
                    .HasMaxLength(122)
                    .IsUnicode(false)
                    .HasColumnName("Approved name");
                entity.Property(e => e.ApprovedSymbol)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Approved symbol");
                entity.Property(e => e.Chromosome)
                    .HasMaxLength(12)
                    .IsUnicode(false);
                entity.Property(e => e.ChromosomeLocation)
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("Chromosome location");
                entity.Property(e => e.DateApproved)
                    .HasColumnType("datetime")
                    .HasColumnName("Date approved");
                entity.Property(e => e.DateModified)
                    .HasColumnType("datetime")
                    .HasColumnName("Date modified");
                entity.Property(e => e.DateNameChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("Date name changed");
                entity.Property(e => e.DateSymbolChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("Date symbol changed");
                entity.Property(e => e.HgncFamilyId)
                    .IsUnicode(false)
                    .HasColumnName("HGNC family ID");
                entity.Property(e => e.HgncFamilyName)
                    .IsUnicode(false)
                    .HasColumnName("HGNC family name");
                entity.Property(e => e.HgncId).HasColumnName("HGNC ID");
                entity.Property(e => e.LocusGroup)
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .HasColumnName("Locus group");
                entity.Property(e => e.LocusType)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("Locus type");
                entity.Property(e => e.PreviousName)
                    .HasMaxLength(158)
                    .IsUnicode(false)
                    .HasColumnName("Previous name");
                entity.Property(e => e.PreviousSymbol)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Previous symbol");
                entity.Property(e => e.Status)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HgncmappingTable>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("HGNCMappingTable");

                entity.Property(e => e.ApprovedName)
                    .HasMaxLength(122)
                    .IsUnicode(false)
                    .HasColumnName("Approved name");
                entity.Property(e => e.ApprovedSymbol)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Approved symbol");
                entity.Property(e => e.DateSymbolChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("Date symbol changed");
                entity.Property(e => e.EnsemblGeneId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Ensembl gene ID");
                entity.Property(e => e.HgncId).HasColumnName("HGNC ID");
                entity.Property(e => e.MouseGenomeInformaticsMgiId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("Mouse genome informatics (MGI) ID");
                entity.Property(e => e.NcbiGeneId).HasColumnName("NCBI gene ID");
                entity.Property(e => e.OmimId).HasColumnName("OMIM ID");
                entity.Property(e => e.RatGenomeDatabaseRgdId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Rat genome database (RGD) ID");
                entity.Property(e => e.Status)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.UcscGeneId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UCSC gene ID");
                entity.Property(e => e.VegaGeneId)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("Vega gene ID");
            });

            modelBuilder.Entity<IgclassificationMap>(entity =>
            {
                entity.HasKey(e => new { e.AcmgclassificationId, e.IgclassificationId });

                entity.ToTable("IGClassificationMap");

                entity.Property(e => e.AcmgclassificationId).HasColumnName("ACMGClassificationID");
                entity.Property(e => e.IgclassificationId).HasColumnName("IGClassificationID");
            });

            modelBuilder.Entity<IgpreferredRefseqTranscript>(entity =>
            {
                entity.HasKey(e => e.HgncgeneId);

                entity.ToTable("IGPreferredRefseqTranscript");

                entity.Property(e => e.HgncgeneId)
                    .ValueGeneratedNever()
                    .HasColumnName("HGNCGeneID");
                entity.Property(e => e.TranscriptId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TranscriptID");
            });

            modelBuilder.Entity<Igvariant>(entity =>
            {
                entity.ToTable("IGVariant");

                entity.Property(e => e.IgvariantId).HasColumnName("IGVariantID");
                entity.Property(e => e.AcmgclassificationId).HasColumnName("ACMGClassificationID");
                entity.Property(e => e.Igcomment)
                    .IsUnicode(false)
                    .HasColumnName("IGComment");
                entity.Property(e => e.VariantId).HasColumnName("VariantID");
            });

            modelBuilder.Entity<LocusGene>(entity =>
            {
                entity.ToTable("LocusGene");

                entity.HasIndex(e => e.GeneSymbol, "IX_LocusGene_GeneSymbol");

                entity.HasIndex(e => e.VariantLocusId, "IX_LocusGene_VariantLocusID");

                entity.Property(e => e.LocusGeneId).HasColumnName("LocusGeneID");
                entity.Property(e => e.EnsemblGeneId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EnsemblGeneID");
                entity.Property(e => e.GeneSymbol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.VariantLocusId).HasColumnName("VariantLocusID");

                entity.HasOne(d => d.VariantLocus).WithMany(p => p.LocusGenes)
                    .HasForeignKey(d => d.VariantLocusId)
                    .HasConstraintName("FK_LocusGene_VariantLocus");
            });

            modelBuilder.Entity<Ntallele>(entity =>
            {
                entity.ToTable("NTAllele");

                entity.HasIndex(e => e.Allele, "IX_Allele").IsUnique();

                entity.Property(e => e.NtalleleId).HasColumnName("NTAlleleID");
                entity.Property(e => e.Allele).IsUnicode(false);
            });

            modelBuilder.Entity<PatientCase>(entity =>
            {
                entity.HasKey(e => e.PatientCaseId).HasName("PK_Case");

                entity.ToTable("PatientCase");

                entity.Property(e => e.PatientCaseId).HasColumnName("PatientCaseID");
                entity.Property(e => e.CaseName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.CaseResult)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PatientCasePheno>(entity =>
            {
                entity.HasKey(e => new { e.PatientCaseId, e.Pheno, e.PhenoNum });

                entity.ToTable("PatientCasePheno");

                entity.Property(e => e.PatientCaseId).HasColumnName("PatientCaseID");
                entity.Property(e => e.Pheno)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.PatientCase).WithMany(p => p.PatientCasePhenos)
                    .HasForeignKey(d => d.PatientCaseId)
                    .HasConstraintName("FK_PatientCasePheno_PatientCase");
            });

            modelBuilder.Entity<PatientCaseReqPheno>(entity =>
            {
                entity.HasKey(e => new { e.PatientCaseId, e.Pheno, e.PhenoNum });

                entity.ToTable("PatientCaseReqPheno");

                entity.Property(e => e.PatientCaseId).HasColumnName("PatientCaseID");
                entity.Property(e => e.Pheno)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.PatientCase).WithMany(p => p.PatientCaseReqPhenos)
                    .HasForeignKey(d => d.PatientCaseId)
                    .HasConstraintName("FK_PatientCaseReqPheno_PatientCase");
            });

            modelBuilder.Entity<PatientSample>(entity =>
            {
                entity.ToTable("PatientSample");

                entity.HasIndex(e => e.SsmaRowId, "IX_PatientSampleID_SSMA_RowID");

                entity.HasIndex(e => e.PatientCaseId, "IX_PatientSample_PatientCaseID_SSMA_RowID");

                entity.Property(e => e.PatientSampleId).HasColumnName("PatientSampleID");
                entity.Property(e => e.ContainerId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ContainerID");
                entity.Property(e => e.CoverageFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.CoverageProcessingPending).HasDefaultValueSql("((0))");
                entity.Property(e => e.PatientCaseId).HasColumnName("PatientCaseID");
                entity.Property(e => e.SampleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.SampleType).HasMaxLength(25);
                entity.Property(e => e.SsmaRowId).HasColumnName("SSMA_RowID");
                entity.Property(e => e.VariantFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.VariantProcessingPending).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.PatientCase).WithMany(p => p.PatientSamples)
                    .HasForeignKey(d => d.PatientCaseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PatientSample_PatientCase");

                entity.HasMany(d => d.VariantLocus).WithMany(p => p.PatientSamples)
                    .UsingEntity<Dictionary<string, object>>(
                        "PathogenicLocusNotCovered",
                        r => r.HasOne<VariantLocu>().WithMany()
                            .HasForeignKey("VariantLocusId")
                            .HasConstraintName("FK_PathogenicLocusNotCovered_VariantLocus"),
                        l => l.HasOne<PatientSample>().WithMany()
                            .HasForeignKey("PatientSampleId")
                            .HasConstraintName("FK_PathogenicLocusNotCovered_PatientSample"),
                        j =>
                        {
                            j.HasKey("PatientSampleId", "VariantLocusId").HasName("PK_LocusNotCovered");
                            j.ToTable("PathogenicLocusNotCovered");
                            j.IndexerProperty<int>("PatientSampleId").HasColumnName("PatientSampleID");
                            j.IndexerProperty<int>("VariantLocusId").HasColumnName("VariantLocusID");
                        });
            });

            modelBuilder.Entity<ReqPheno>(entity =>
            {
                entity.HasKey(e => new { e.PhenoGrp, e.Pheno });

                entity.ToTable("Req_Pheno");

                entity.Property(e => e.PhenoGrp).HasMaxLength(150);
                entity.Property(e => e.Pheno).HasMaxLength(255);
            });

            modelBuilder.Entity<SampleCoverage>(entity =>
            {
                entity.HasKey(e => e.SampleCoverageId).HasName("PK_SampleCoverageBig");

                entity.ToTable("SampleCoverage");

                entity.HasIndex(e => e.PatientSampleId, "IX_SampleCoverageBig_PatientSampleID");

                entity.Property(e => e.SampleCoverageId).HasColumnName("SampleCoverageID");
                entity.Property(e => e.ChrMod)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Gene)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.PatientSampleId).HasColumnName("PatientSampleID");

                entity.HasOne(d => d.PatientSample).WithMany(p => p.SampleCoverages)
                    .HasForeignKey(d => d.PatientSampleId)
                    .HasConstraintName("FK_SampleCoverageBig_PatientSample");
            });

            modelBuilder.Entity<SampleVariant>(entity =>
            {
                entity.HasKey(e => e.SampleVariantId).HasName("PK_SampleVariantBig");

                entity.ToTable("SampleVariant");

                entity.HasIndex(e => e.PatientSampleId, "IX_SampleVariantBig_PatientSampleID");

                entity.HasIndex(e => e.VariantId, "IX_SampleVariantBig_VariantID");

                entity.Property(e => e.SampleVariantId).HasColumnName("SampleVariantID");
                entity.Property(e => e.PatientSampleId).HasColumnName("PatientSampleID");
                entity.Property(e => e.SelectedVariantTranscriptConsequenceId).HasColumnName("SelectedVariantTranscriptConsequenceID");
                entity.Property(e => e.VariantId).HasColumnName("VariantID");
                entity.Property(e => e.VariantLocusId).HasColumnName("VariantLocusID");

                entity.HasOne(d => d.PatientSample).WithMany(p => p.SampleVariants)
                    .HasForeignKey(d => d.PatientSampleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SampleVariantBig_PatientSample");

                entity.HasOne(d => d.Variant).WithMany(p => p.SampleVariants)
                    .HasForeignKey(d => d.VariantId)
                    .HasConstraintName("FK_SampleVariant_Variant");
            });

            modelBuilder.Entity<SampleVariantInfo>(entity =>
            {
                entity.HasKey(e => e.SampleVariantId);

                entity.ToTable("SampleVariantInfo");

                entity.Property(e => e.SampleVariantId)
                    .ValueGeneratedNever()
                    .HasColumnName("SampleVariantID");
                entity.Property(e => e.AminoAcidChange)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsSparse();
                entity.Property(e => e.AminoAcidChangeTypeId).HasColumnName("AminoAcidChangeTypeID");
                entity.Property(e => e.Dbsnp)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("DBSNP");
                entity.Property(e => e.Filter)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Format)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.FormatData)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Info)
                    .HasMaxLength(2000)
                    .IsUnicode(false);
                entity.Property(e => e.ReferenceAminoAcid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsSparse();
            });

            modelBuilder.Entity<SelectedTranscript>(entity =>
            {
                entity.HasKey(e => e.SampleVariantId);

                entity.ToTable("SelectedTranscript");

                entity.Property(e => e.SampleVariantId)
                    .ValueGeneratedNever()
                    .HasColumnName("SampleVariantID");
                entity.Property(e => e.TranscriptId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TranscriptID");
                entity.Property(e => e.VariantId).HasColumnName("VariantID");
            });

            modelBuilder.Entity<SelectedVariant>(entity =>
            {
                entity.HasKey(e => new { e.SampleVariantId, e.UserName });

                entity.ToTable("SelectedVariant");

                entity.HasIndex(e => new { e.UserName, e.PatientSampleId, e.SampleVariantId }, "IX_SelectedVariantByUser").IsUnique();

                entity.HasIndex(e => new { e.PatientSampleId, e.SampleVariantId }, "IX_SelectedVariant_FINAL")
                    .IsDescending(true, false)
                    .HasFilter("([UserName]='FINAL')");

                entity.Property(e => e.SampleVariantId).HasColumnName("SampleVariantID");
                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.PatientSampleId).HasColumnName("PatientSampleID");

                entity.HasOne(d => d.SampleVariant).WithMany(p => p.SelectedVariants)
                    .HasForeignKey(d => d.SampleVariantId)
                    .HasConstraintName("FK_SelectedVariant_SampleVariant");
            });

            modelBuilder.Entity<Srtnarrow>(entity =>
            {
                entity.HasKey(e => e.SsmaRowId);

                entity.ToTable("SRTNarrow");

                entity.Property(e => e.SsmaRowId)
                    .ValueGeneratedNever()
                    .HasColumnName("SSMA_RowID");
                entity.Property(e => e.ContainerId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ContainerID");
                entity.Property(e => e.TestCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusWarning>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("StatusWarning");

                entity.Property(e => e.PatientSampleId).HasColumnName("PatientSampleID");
                entity.Property(e => e.WarningDate).HasColumnType("datetime");
                entity.Property(e => e.WarningText)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StringProteinAction>(entity =>
            {
                entity.HasKey(e => new { e.ItemIdA, e.ItemIdB, e.ActionId });

                entity.ToTable("StringProteinAction");

                entity.Property(e => e.ItemIdA)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("item_id_a");
                entity.Property(e => e.ItemIdB)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("item_id_b");
                entity.Property(e => e.ActionId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ActionID");
                entity.Property(e => e.AIsActing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("a_is_acting");
                entity.Property(e => e.Action)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("action");
                entity.Property(e => e.IsDirectional)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("is_directional");
                entity.Property(e => e.Mode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mode");
                entity.Property(e => e.Score).HasColumnName("score");
            });

            modelBuilder.Entity<StringProteinDetailedLink>(entity =>
            {
                entity.HasKey(e => new { e.Protein1, e.Protein2 });

                entity.ToTable("StringProteinDetailedLink");

                entity.Property(e => e.Protein1)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("protein1");
                entity.Property(e => e.Protein2)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("protein2");
                entity.Property(e => e.Coexpression).HasColumnName("coexpression");
                entity.Property(e => e.CombinedScore).HasColumnName("combined_score");
                entity.Property(e => e.Cooccurence).HasColumnName("cooccurence");
                entity.Property(e => e.Database).HasColumnName("database");
                entity.Property(e => e.Experimental).HasColumnName("experimental");
                entity.Property(e => e.Fusion).HasColumnName("fusion");
                entity.Property(e => e.Neighborhood).HasColumnName("neighborhood");
                entity.Property(e => e.Textmining).HasColumnName("textmining");
            });

            modelBuilder.Entity<StringProteinLink>(entity =>
            {
                entity.HasKey(e => new { e.Protein1, e.Protein2 });

                entity.Property(e => e.Protein1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("protein1");
                entity.Property(e => e.Protein2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("protein2");
                entity.Property(e => e.CombinedScore).HasColumnName("combined_score");
            });

            modelBuilder.Entity<TestCodeAnalytesNarrow>(entity =>
            {
                entity.HasKey(e => new { e.TestCode, e.NextGeneSym });

                entity.ToTable("TestCodeAnalytesNarrow");

                entity.Property(e => e.TestCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);
                entity.Property(e => e.NextGeneSym)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Analyte)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.WebsiteTestCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestCodePhenoGrp>(entity =>
            {
                entity.HasKey(e => new { e.TestCode, e.PhenoGrp });

                entity.ToTable("TestCodePhenoGrp");

                entity.Property(e => e.TestCode).HasMaxLength(15);
                entity.Property(e => e.PhenoGrp).HasMaxLength(150);
            });

            modelBuilder.Entity<V7captureGeneInfo>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("V7CaptureGeneInfo");

                entity.Property(e => e.Analyte)
                    .HasMaxLength(9)
                    .IsUnicode(false);
                entity.Property(e => e.GeneStableId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Gene stable ID");
                entity.Property(e => e.GeneType)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("Gene type");
            });

            modelBuilder.Entity<VCdsbedRegionPadded>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vCDSBedRegionPadded");

                entity.Property(e => e.Chr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("chr");
                entity.Property(e => e.EnsemblExonId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EnsemblExonID");
                entity.Property(e => e.EnsemblGeneId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EnsemblGeneID");
            });

            modelBuilder.Entity<VClinvarPathogenicLocu>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vClinvarPathogenicLocus");

                entity.Property(e => e.ChrMod)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.LocusType)
                    .HasMaxLength(3)
                    .IsUnicode(false);
                entity.Property(e => e.Ref)
                    .HasMaxLength(900)
                    .IsUnicode(false)
                    .HasColumnName("REF");
                entity.Property(e => e.VariantLocusId).HasColumnName("VariantLocusID");
            });

            modelBuilder.Entity<VEnsemblGeneTestCode>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vEnsemblGeneTestCode");

                entity.Property(e => e.Countbig).HasColumnName("countbig");
                entity.Property(e => e.GeneSymbol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.TestCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VGeneBedRegionPadded>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vGeneBedRegionPadded");

                entity.Property(e => e.Chr)
                    .HasMaxLength(24)
                    .IsUnicode(false);
                entity.Property(e => e.GeneId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GeneID");
                entity.Property(e => e.GeneSymbol)
                    .HasMaxLength(22)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VLocusWithPathogenicVariant>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vLocusWithPathogenicVariant");

                entity.Property(e => e.ChrMod)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.VariantLocusId).HasColumnName("VariantLocusID");
            });

            modelBuilder.Entity<VPanelCdsbedRegionPadded>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vPanelCDSBedRegionPadded");

                entity.Property(e => e.Chr)
                    .HasMaxLength(24)
                    .IsUnicode(false);
                entity.Property(e => e.EnsemblGeneId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("EnsemblGeneID");
                entity.Property(e => e.GeneSymbol)
                    .HasMaxLength(22)
                    .IsUnicode(false);
                entity.Property(e => e.TestCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VPanelGeneBedRegionPadded>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vPanelGeneBedRegionPadded");

                entity.Property(e => e.Chr)
                    .HasMaxLength(24)
                    .IsUnicode(false);
                entity.Property(e => e.EnsemblGeneId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("EnsemblGeneID");
                entity.Property(e => e.GeneSymbol)
                    .HasMaxLength(22)
                    .IsUnicode(false);
                entity.Property(e => e.TestCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VPatientCasePheno>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vPatientCasePheno");

                entity.Property(e => e.PatientCaseId).HasColumnName("PatientCaseID");
                entity.Property(e => e.PatientSampleId).HasColumnName("PatientSampleID");
            });

            modelBuilder.Entity<VPatientTestCode>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vPatientTestCode");

                entity.Property(e => e.ContainerId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ContainerID");
                entity.Property(e => e.PatientCaseId).HasColumnName("PatientCaseID");
                entity.Property(e => e.PatientSampleId).HasColumnName("PatientSampleID");
                entity.Property(e => e.SsmaRowId).HasColumnName("SSMA_RowID");
                entity.Property(e => e.TestCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VSampleTestCodePhenoGroup>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vSampleTestCodePhenoGroup");

                entity.Property(e => e.PatientCaseId).HasColumnName("PatientCaseID");
                entity.Property(e => e.PatientSampleId).HasColumnName("PatientSampleID");
                entity.Property(e => e.PhenoGrp).HasMaxLength(150);
                entity.Property(e => e.SsmaRowId).HasColumnName("SSMA_RowID");
                entity.Property(e => e.TestCode).HasMaxLength(15);
            });

            modelBuilder.Entity<VUserClass>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vUserClass");

                entity.Property(e => e.Alt)
                    .HasMaxLength(900)
                    .IsUnicode(false);
                entity.Property(e => e.ChrMod)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Ref)
                    .HasMaxLength(900)
                    .IsUnicode(false);
                entity.Property(e => e.VariantId).HasColumnName("VariantID");
            });

            modelBuilder.Entity<Variant>(entity =>
            {
                entity.ToTable("Variant");

                entity.HasIndex(e => e.ReviewPathogenic, "IX_Variant_ReviewPathogenic_FILTERED").HasFilter("([ReviewPathogenic]=(1))");

                entity.HasIndex(e => new { e.ReviewRare, e.ReviewPathogenic }, "IX_Variant_ReviewRare_ReviewPathogenic");

                entity.HasIndex(e => e.VariantLocusId, "IX_Variant_VariantLocusID");

                entity.HasIndex(e => e.VariantLocusId, "IX_tmpCaseNumCount");

                entity.Property(e => e.VariantId).HasColumnName("VariantID");
                entity.Property(e => e.AltAlleleId).HasColumnName("AltAlleleID");
                entity.Property(e => e.ClinvarRowId).HasColumnName("ClinvarRowID");
                entity.Property(e => e.DbSnprowId).HasColumnName("dbSNPRowID");
                entity.Property(e => e.ExAcrowId).HasColumnName("ExACRowID");
                entity.Property(e => e.GnomadExomesRowId).HasColumnName("GnomadExomesRowID");
                entity.Property(e => e.GnomadGenomesRowId).HasColumnName("GnomadGenomesRowID");
                entity.Property(e => e.HgmdrowId).HasColumnName("HGMDRowID");
                entity.Property(e => e.MitoMapRowId).HasColumnName("MitoMapRowID");
                entity.Property(e => e.OmimrowId).HasColumnName("OMIMRowID");
                entity.Property(e => e.ReviewPathogenic).HasDefaultValueSql("((0))");
                entity.Property(e => e.ThousandGenomesRowId).HasColumnName("ThousandGenomesRowID");
                entity.Property(e => e.VariantLocusId).HasColumnName("VariantLocusID");

                entity.HasOne(d => d.VariantLocus).WithMany(p => p.Variants)
                    .HasForeignKey(d => d.VariantLocusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Variant_VariantLocus");
            });

            modelBuilder.Entity<VariantClassification>(entity =>
            {
                entity.HasKey(e => new { e.VariantId, e.UserName });

                entity.ToTable("VariantClassification");

                entity.HasIndex(e => new { e.UserName, e.VariantId }, "IX_Classification_FINAL").HasFilter("([UserName]='FINAL')");

                entity.Property(e => e.VariantId).HasColumnName("VariantID");
                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ClassificationDate).HasColumnType("datetime");
                entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");


                entity.HasOne(d => d.Variant).WithMany(p => p.VariantClassifications)
                    .HasForeignKey(d => d.VariantId)
                    .HasConstraintName("FK_VariantClassification_Variant");
            });

            modelBuilder.Entity<VariantCriterion>(entity =>
            {
                entity.HasKey(e => new { e.VariantId, e.UserName, e.AcmgcriteriaId });

                entity.HasIndex(e => e.VariantId, "IX_VariantCriteria_VariantID_FINAL").HasFilter("([UserName]='FINAL')");

                entity.Property(e => e.VariantId).HasColumnName("VariantID");
                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.AcmgcriteriaId).HasColumnName("ACMGCriteriaID");

                entity.HasOne(d => d.Variant).WithMany(p => p.VariantCriteria)
                    .HasForeignKey(d => d.VariantId)
                    .HasConstraintName("FK_VariantCriteria_Variant");
            });

            modelBuilder.Entity<VariantFilterMetaProcessingDeprecated>(entity =>
            {
                entity.HasKey(e => new { e.VariantId, e.AnnotationSource }).HasName("PK_VariantFilterMetaProcessing");

                entity.ToTable("VariantFilterMetaProcessingDEPRECATED");

                entity.Property(e => e.VariantId).HasColumnName("VariantID");
                entity.Property(e => e.AnnotationSource)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VariantFilterMetum>(entity =>
            {
                entity.HasKey(e => e.VariantId).HasName("PK_VariantFilterMetaStaging");

                entity.Property(e => e.VariantId)
                    .ValueGeneratedNever()
                    .HasColumnName("VariantID");
            });

            modelBuilder.Entity<VariantInterpretation>(entity =>
            {
                entity.ToTable("VariantInterpretation");

                entity.HasIndex(e => e.VariantId, "IX_VariantInterpretation_VariantID");

                entity.Property(e => e.VariantInterpretationId).HasColumnName("VariantInterpretationID");
                entity.Property(e => e.DateUpdated)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Interpretation).IsUnicode(false);
                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.VariantId).HasColumnName("VariantID");

                entity.HasOne(d => d.Variant).WithMany(p => p.VariantInterpretations)
                    .HasForeignKey(d => d.VariantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_VariantInterpretation_Variant");
            });

            modelBuilder.Entity<VariantLocu>(entity =>
            {
                entity.HasKey(e => e.VariantLocusId);

                entity.HasIndex(e => new { e.ChrMod, e.Pos, e.RefAlleleId, e.LocusType }, "IX_VariantLocus_Normalization").IsUnique();

                entity.HasIndex(e => e.VariantLocusId, "IX_VariantLocus_VariantLocusID_ChrMod_Pos")
                    .IsUnique()
                    .IsDescending();

                entity.Property(e => e.VariantLocusId).HasColumnName("VariantLocusID");
                entity.Property(e => e.ChrMod)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.InCdsbed).HasColumnName("InCDSBed");
                entity.Property(e => e.KnownPathogenicGene).HasDefaultValueSql("((0))");
                entity.Property(e => e.LocusType)
                    .HasMaxLength(3)
                    .IsUnicode(false);
                entity.Property(e => e.RefAlleleId).HasColumnName("RefAlleleID");
            });

            modelBuilder.Entity<VariantNote>(entity =>
            {
                entity.HasKey(e => new { e.UserName, e.VariantId });

                entity.ToTable("VariantNote");

                entity.HasIndex(e => new { e.VariantId, e.UserName }, "IX_VariantNote_VariantID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.VariantId).HasColumnName("VariantID");
                entity.Property(e => e.Note)
                    .HasMaxLength(8000)
                    .IsUnicode(false);
                entity.Property(e => e.NoteDate).HasColumnType("datetime");

                entity.HasOne(d => d.Variant).WithMany(p => p.VariantNotes)
                    .HasForeignKey(d => d.VariantId)
                    .HasConstraintName("FK_VariantNote_Variant");
            });

            modelBuilder.Entity<VariantTranscriptConsequence>(entity =>
            {
                entity.HasKey(e => new { e.VariantId, e.TranscriptId }).HasName("PK_VariantTranscriptConsequenceProcessing");

                entity.ToTable("VariantTranscriptConsequence");

                entity.Property(e => e.VariantId).HasColumnName("VariantID");
                entity.Property(e => e.TranscriptId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TranscriptID");
                entity.Property(e => e.AnnotationSource)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.BamEdit).IsUnicode(false);
                entity.Property(e => e.Codons).IsUnicode(false);
                entity.Property(e => e.ConsequenceTerms).IsUnicode(false);
                entity.Property(e => e.EnsemblTranscriptId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EnsemblTranscriptID");
                entity.Property(e => e.EnsemblTranslationId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EnsemblTranslationID");
                entity.Property(e => e.Exon)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.GeneId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GeneID");
                entity.Property(e => e.GeneIdsource)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GeneIDSource");
                entity.Property(e => e.GivenRef)
                    .HasMaxLength(101)
                    .IsUnicode(false);
                entity.Property(e => e.Hgvsc)
                    .IsUnicode(false)
                    .HasColumnName("HGVSc");
                entity.Property(e => e.Hgvsp)
                    .IsUnicode(false)
                    .HasColumnName("HGVSp");
                entity.Property(e => e.ImpactTerm)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Intron)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsSparse();
                entity.Property(e => e.PolyPhen2PredictionTerm)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.PolyPhen2PredictionTermId).HasColumnName("PolyPhen2PredictionTermID");
                entity.Property(e => e.SiftPredictionTerm)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.SiftPredictionTermId).HasColumnName("SiftPredictionTermID");
                entity.Property(e => e.TranscriptBiotype)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.TranslationId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TranslationID");
                entity.Property(e => e.UsedRef).IsUnicode(false);
                entity.Property(e => e.VariantTranscriptConsequenceId).HasColumnName("VariantTranscriptConsequenceID");
            });

            modelBuilder.Entity<VariantTranscriptConsequenceOld>(entity =>
            {
                entity.HasKey(e => new { e.VariantId, e.TranscriptId }).HasName("PK_VariantTranscriptConsequence");

                entity.ToTable("VariantTranscriptConsequenceOLD");

                entity.Property(e => e.VariantId).HasColumnName("VariantID");
                entity.Property(e => e.TranscriptId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TranscriptID");
                entity.Property(e => e.AnnotationSource)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.BamEdit).IsUnicode(false);
                entity.Property(e => e.Codons).IsUnicode(false);
                entity.Property(e => e.ConsequenceTerms).IsUnicode(false);
                entity.Property(e => e.Exon)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.GeneId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GeneID");
                entity.Property(e => e.GeneIdsource)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GeneIDSource");
                entity.Property(e => e.GivenRef)
                    .HasMaxLength(101)
                    .IsUnicode(false);
                entity.Property(e => e.Hgvsc)
                    .IsUnicode(false)
                    .HasColumnName("HGVSc");
                entity.Property(e => e.Hgvsp)
                    .IsUnicode(false)
                    .HasColumnName("HGVSp");
                entity.Property(e => e.ImpactTerm)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Intron)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsSparse();
                entity.Property(e => e.PolyPhen2PredictionTerm)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.SiftPredictionTerm)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.TranscriptBiotype)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.TranslationId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TranslationID");
                entity.Property(e => e.UsedRef).IsUnicode(false);

                entity.HasOne(d => d.Variant).WithMany(p => p.VariantTranscriptConsequenceOlds)
                    .HasForeignKey(d => d.VariantId)
                    .HasConstraintName("FK_VariantTranscriptConsequence_Variant");
            });

            modelBuilder.Entity<VariantTransferIgsnapshot>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("VariantTransferIGSnapshot");

                entity.Property(e => e.AltAllele)
                    .HasMaxLength(101)
                    .IsUnicode(false);
                entity.Property(e => e.Chr)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.IgclassificationId).HasColumnName("IGClassificationID");
                entity.Property(e => e.Igcomment)
                    .IsUnicode(false)
                    .HasColumnName("IGComment");
                entity.Property(e => e.RefAllele)
                    .HasMaxLength(101)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VariantTransferIgsnapshotBackup>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("VariantTransferIGSnapshotBackup");

                entity.Property(e => e.AltAllele)
                    .HasMaxLength(101)
                    .IsUnicode(false);
                entity.Property(e => e.Chr)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.IgclassificationId).HasColumnName("IGClassificationID");
                entity.Property(e => e.Igcomment)
                    .IsUnicode(false)
                    .HasColumnName("IGComment");
                entity.Property(e => e.RefAllele)
                    .HasMaxLength(101)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VariantTransferMngsnapshot>(entity =>
            {
                entity.HasKey(e => new { e.Chr, e.Pos, e.RefAlleleId, e.AltAlleleId });

                entity.ToTable("VariantTransferMNGSnapshot");

                entity.Property(e => e.Chr)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.RefAlleleId).HasColumnName("RefAlleleID");
                entity.Property(e => e.AltAlleleId).HasColumnName("AltAlleleID");
                entity.Property(e => e.Acmgclassification)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ACMGClassification");
                entity.Property(e => e.AltAllele)
                    .HasMaxLength(101)
                    .IsUnicode(false);
                entity.Property(e => e.Mngcomment)
                    .IsUnicode(false)
                    .HasColumnName("MNGComment");
                entity.Property(e => e.RefAllele)
                    .HasMaxLength(101)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vepterm>(entity =>
            {
                entity.HasKey(e => e.VeptermId).HasName("PK_TranscriptConsequenceTerm");

                entity.ToTable("VEPTerm");

                entity.Property(e => e.VeptermId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VEPTermID");
                entity.Property(e => e.Term)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.TermSubtype)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.TermType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VersionedCaseResult>(entity =>
            {
                entity.ToTable("VersionedCaseResult");

                entity.Property(e => e.VersionedCaseResultId).HasColumnName("VersionedCaseResultID");
                entity.Property(e => e.PatientCaseId).HasColumnName("PatientCaseID");
                entity.Property(e => e.Result)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ResultDate).HasColumnType("datetime");
                entity.Property(e => e.SystemVersionId).HasColumnName("SystemVersionID");
                entity.Property(e => e.TestCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.PatientCase).WithMany(p => p.VersionedCaseResults)
                    .HasForeignKey(d => d.PatientCaseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_VersionedCaseResult_PatientCase");
            });

            modelBuilder.Entity<VersionedSampleEvent>(entity =>
            {
                entity.ToTable("VersionedSampleEvent");

                entity.Property(e => e.VersionedSampleEventId).HasColumnName("VersionedSampleEventID");
                entity.Property(e => e.Event)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.EventDate).HasColumnType("datetime");
                entity.Property(e => e.PatientSampleId).HasColumnName("PatientSampleID");
                entity.Property(e => e.SystemVersionId).HasColumnName("SystemVersionID");
                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorklistSampleExclusion>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.PatientSampleId });

                entity.ToTable("WorklistSampleExclusion");

                entity.Property(e => e.Username)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.PatientSampleId).HasColumnName("PatientSampleID");
            });

            modelBuilder.Entity<WorklistSupervisor>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.ToTable("WorklistSupervisor");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLoginAttempt>(entity =>
            {
                entity.HasKey(e => e.IpAddress);
                entity.ToTable("UserLoginAttempt");
                entity.Property(e => e.IpAddress).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.LoginAttempts);
            });

            //modelBuilder.Entity<VariantDisplay>(entityBuilder => {
            //    entityBuilder
            //    .ToTable("Variant")
            //    .SplitToTable("PatientSample",
            //    tableBuilder =>
            //    {
            //        tableBuilder.Property(v => v.PatientSampleId);
            //        tableBuilder.Property(v => v.PatientCaseId);
            //        tableBuilder.Property(v => v.SampleName);
            //    })
            //    .SplitToTable(
            //        "SampleVariant",
            //        tableBuilder =>
            //        {
            //            tableBuilder.Property(v => v.SampleVariantId);
            //        })
            //    .SplitToTable(
            //        "VariantLocus",
            //        tableBuilder =>
            //        {
            //            tableBuilder.Property(v => v.VariantLocusId);
            //            tableBuilder.Property(v => v.ChrMod);
            //            tableBuilder.Property(v => v.Pos);
            //            tableBuilder.Property(v => v.LocusType);
            //        })
            //    .SplitToTable(
            //            "NTAllele",
            //            tableBuilder =>
            //            {
            //                tableBuilder.Property(v => v.Ref);
            //                tableBuilder.Property(v => v.Alt);
            //            })
            //    .SplitToTable(
            //            "dbSNPProcessingReference",
            //            tableBuilder =>
            //            {
            //                tableBuilder.Property(v => v.Rs);
            //            })
            //    .SplitToTable(
            //            "VariantFilterMeta",
            //            tableBuilder =>
            //            {
            //                tableBuilder.Property(v => v.HasDisruptive);
            //                tableBuilder.Property(v => v.HasAminoAcidChange);
            //            })
            //    .SplitToTable(
            //            "HGMDProcessingReference",
            //            tableBuilder =>
            //            {
            //                tableBuilder.Property(v => v.Disease);
            //                tableBuilder.Property(v => v.HgmdPheno);
            //                tableBuilder.Property(v => v.HgmdInheritance);
            //                tableBuilder.Property(v => v.HgmdClassification);
            //            })
            //    .SplitToTable("ClinvarProcessingReference",
            //            tableBuilder =>
            //            {
            //                tableBuilder.Property(v => v.CLNREVSTAT);
            //            });
            //    });

            //modelBuilder.Entity<VariantDisplay>()
            //    .HasOne<Variant>()
            //    .WithOne()
            //    .HasForeignKey<VariantDisplay>(a => a.VariantId);

            //modelBuilder.Entity<VariantDisplay>()
            //    .HasOne<PatientSample>()
            //    .WithOne()
            //    .HasForeignKey<VariantDisplay>(a => a.PatientSampleId);

            //modelBuilder.Entity<VariantDisplay>()
            //    .HasOne<SampleVariant>()
            //    .WithOne()
            //    .HasForeignKey<VariantDisplay>(a => a.SampleVariantId);

            //modelBuilder.Entity<VariantDisplay>()
            //    .HasOne<VariantLocu>()
            //    .WithOne()
            //    .HasForeignKey<VariantDisplay>(a => a.VariantLocusId);

            var methodInfo = typeof(DataManagerContext)
                   .GetMethod(nameof(CatSelected), new[] { typeof(int), typeof(string) });

            modelBuilder.HasDbFunction(methodInfo)
        .HasName("CatSelected");

            var methodInfoNoFilter = typeof(DataManagerContext)
                .GetMethod(nameof(CatAnyNoFilter), new[] { typeof(int), typeof(string), typeof(int) });
            modelBuilder.HasDbFunction(methodInfoNoFilter)
                .HasName("CatAnyNoFilter");

            modelBuilder.Entity<VariantDisplay>().HasNoKey();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
