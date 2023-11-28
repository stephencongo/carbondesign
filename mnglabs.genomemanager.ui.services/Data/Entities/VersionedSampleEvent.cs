using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VersionedSampleEvent
{
    public int VersionedSampleEventId { get; set; }

    public int? SystemVersionId { get; set; }

    public int? PatientSampleId { get; set; }

    public string? Event { get; set; }

    public DateTime? EventDate { get; set; }

    public string? UserName { get; set; }
}
