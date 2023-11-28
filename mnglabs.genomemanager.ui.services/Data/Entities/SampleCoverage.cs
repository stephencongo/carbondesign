using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class SampleCoverage
{
    public long SampleCoverageId { get; set; }

    public int PatientSampleId { get; set; }

    public string ChrMod { get; set; } = null!;

    public int StartPos { get; set; }

    public int EndPos { get; set; }

    public string? Gene { get; set; }

    public virtual PatientSample PatientSample { get; set; } = null!;
}
