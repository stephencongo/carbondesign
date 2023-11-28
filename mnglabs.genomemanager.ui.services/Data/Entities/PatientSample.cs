using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class PatientSample
{
    public int PatientSampleId { get; set; }

    public string? SampleName { get; set; }

    public int? PatientCaseId { get; set; }

    public bool VariantsProcessed { get; set; }

    public bool CoverageProcessed { get; set; }

    public bool Done { get; set; }

    public bool Reviewed { get; set; }

    public int? SsmaRowId { get; set; }

    public string? ContainerId { get; set; }

    public bool IsProband { get; set; }

    public string? SampleType { get; set; }

    public bool? CoverageProcessingPending { get; set; }

    public bool? VariantProcessingPending { get; set; }

    public string? VariantFileName { get; set; }

    public string? CoverageFileName { get; set; }

    public virtual PatientCase? PatientCase { get; set; }

    public virtual ICollection<SampleCoverage> SampleCoverages { get; set; } = new List<SampleCoverage>();

    public virtual ICollection<SampleVariant> SampleVariants { get; set; } = new List<SampleVariant>();

    public virtual ICollection<VariantLocu> VariantLocus { get; set; } = new List<VariantLocu>();
}
