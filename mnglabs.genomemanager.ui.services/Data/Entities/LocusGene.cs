using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class LocusGene
{
    public int LocusGeneId { get; set; }

    public int VariantLocusId { get; set; }

    public string GeneSymbol { get; set; } = null!;

    public string? EnsemblGeneId { get; set; }

    public virtual VariantLocu VariantLocus { get; set; } = null!;
}
