using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VCdsbedRegionPadded
{
    public string? EnsemblGeneId { get; set; }

    public string EnsemblExonId { get; set; } = null!;

    public string? Chr { get; set; }

    public int? StartPos { get; set; }

    public int? EndPos { get; set; }
}
