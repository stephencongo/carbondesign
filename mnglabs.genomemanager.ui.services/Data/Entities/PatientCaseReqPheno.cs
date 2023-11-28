using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class PatientCaseReqPheno
{
    public int PatientCaseId { get; set; }

    public short PhenoNum { get; set; }

    public string Pheno { get; set; } = null!;

    public virtual PatientCase PatientCase { get; set; } = null!;
}
