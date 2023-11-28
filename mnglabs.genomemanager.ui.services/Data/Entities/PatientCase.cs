using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class PatientCase
{
    public int PatientCaseId { get; set; }

    public string? CaseName { get; set; }

    public string? CaseResult { get; set; }

    public virtual ICollection<PatientCasePheno> PatientCasePhenos { get; set; } = new List<PatientCasePheno>();

    public virtual ICollection<PatientCaseReqPheno> PatientCaseReqPhenos { get; set; } = new List<PatientCaseReqPheno>();

    public virtual ICollection<PatientSample> PatientSamples { get; set; } = new List<PatientSample>();

    public virtual ICollection<VersionedCaseResult> VersionedCaseResults { get; set; } = new List<VersionedCaseResult>();
}
