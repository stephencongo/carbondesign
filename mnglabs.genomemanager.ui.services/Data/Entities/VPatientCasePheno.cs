using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VPatientCasePheno
{
    public int PatientSampleId { get; set; }

    public int? PatientCaseId { get; set; }

    public string PhenoText { get; set; } = null!;
}
