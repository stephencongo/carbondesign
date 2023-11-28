using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class Variant
{
    public int VariantId { get; set; }

    public int? VariantLocusId { get; set; }

    public int? AltAlleleId { get; set; }

    public int? ThousandGenomesRowId { get; set; }

    public int? ClinvarRowId { get; set; }

    public int? OmimrowId { get; set; }

    public int? HgmdrowId { get; set; }

    public int? SampleNum { get; set; }

    public int? CaseNum { get; set; }

    public bool? ReviewRare { get; set; }

    public bool? ReviewPathogenic { get; set; }

    public int? ExAcrowId { get; set; }

    public int? MitoMapRowId { get; set; }

    public int? DbSnprowId { get; set; }

    public int? GnomadGenomesRowId { get; set; }

    public int? GnomadExomesRowId { get; set; }

    public virtual ICollection<SampleVariant> SampleVariants { get; set; } = new List<SampleVariant>();

    public virtual ICollection<VariantClassification> VariantClassifications { get; set; } = new List<VariantClassification>();

    public virtual ICollection<VariantCriterion> VariantCriteria { get; set; } = new List<VariantCriterion>();

    public virtual ICollection<VariantInterpretation> VariantInterpretations { get; set; } = new List<VariantInterpretation>();

    public virtual VariantLocu? VariantLocus { get; set; }

    public virtual ICollection<VariantNote> VariantNotes { get; set; } = new List<VariantNote>();

    public virtual ICollection<VariantTranscriptConsequenceOld> VariantTranscriptConsequenceOlds { get; set; } = new List<VariantTranscriptConsequenceOld>();
}
