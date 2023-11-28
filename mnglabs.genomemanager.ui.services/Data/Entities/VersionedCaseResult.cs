using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VersionedCaseResult
{
    public int VersionedCaseResultId { get; set; }

    public int? SystemVersionId { get; set; }

    public int? PatientCaseId { get; set; }

    public string? TestCode { get; set; }

    public string? Result { get; set; }

    public DateTime? ResultDate { get; set; }

    public string? UserName { get; set; }

    public virtual PatientCase? PatientCase { get; set; }
}
