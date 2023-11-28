using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class StringProteinLink
{
    public string Protein1 { get; set; } = null!;

    public string Protein2 { get; set; } = null!;

    public short CombinedScore { get; set; }
}
