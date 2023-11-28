using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VEnsemblGeneTestCode
{
    public string TestCode { get; set; } = null!;

    public string? GeneSymbol { get; set; }

    public long? Countbig { get; set; }
}
