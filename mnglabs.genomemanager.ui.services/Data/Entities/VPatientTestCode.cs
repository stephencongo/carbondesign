using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VPatientTestCode
{
    public int PatientSampleId { get; set; }

    public int? PatientCaseId { get; set; }

    public int? SsmaRowId { get; set; }

    public string? TestCode { get; set; }

    public string? ContainerId { get; set; }

    public int IsExome { get; set; }

    public long? BigCount { get; set; }
}
