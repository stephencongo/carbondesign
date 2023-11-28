using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class WorklistSampleExclusion
{
    public string Username { get; set; } = null!;

    public int PatientSampleId { get; set; }
}
