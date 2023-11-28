using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class V7captureGeneInfo
{
    public string Analyte { get; set; } = null!;

    public string? GeneType { get; set; }

    public string? GeneStableId { get; set; }
}
