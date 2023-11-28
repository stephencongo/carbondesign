using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class SampleVariant
{
    public long SampleVariantId { get; set; }

    public int VariantId { get; set; }

    public int VariantLocusId { get; set; }

    public int? VariantCoverage { get; set; }

    public int? LocusCoverage { get; set; }

    public bool? Homozygous { get; set; }

    public int? PatientSampleId { get; set; }

    public int? SelectedVariantTranscriptConsequenceId { get; set; }

    public virtual PatientSample? PatientSample { get; set; }

    public virtual ICollection<SelectedVariant> SelectedVariants { get; set; } = new List<SelectedVariant>();

    public virtual Variant Variant { get; set; } = null!;
}
