using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VSampleTestCodePhenoGroup
{
    public int? PatientCaseId { get; set; }

    public int PatientSampleId { get; set; }

    public int? SsmaRowId { get; set; }

    public string PhenoGrp { get; set; } = null!;

    public string TestCode { get; set; } = null!;

    public long? Expr1 { get; set; }
}
