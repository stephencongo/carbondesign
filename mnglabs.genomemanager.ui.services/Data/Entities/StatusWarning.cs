using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class StatusWarning
{
    public string? WarningText { get; set; }

    public DateTime? WarningDate { get; set; }

    public int? PatientSampleId { get; set; }
}
