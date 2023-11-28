using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VPanelCdsbedRegionPadded
{
    public string TestCode { get; set; } = null!;

    public string? Chr { get; set; }

    public int? StartPos { get; set; }

    public int? EndPos { get; set; }

    public string? GeneSymbol { get; set; }

    public string EnsemblGeneId { get; set; } = null!;
}
