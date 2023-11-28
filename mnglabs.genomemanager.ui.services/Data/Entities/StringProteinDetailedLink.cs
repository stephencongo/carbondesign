using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class StringProteinDetailedLink
{
    public string Protein1 { get; set; } = null!;

    public string Protein2 { get; set; } = null!;

    public short? Neighborhood { get; set; }

    public short? Fusion { get; set; }

    public short? Cooccurence { get; set; }

    public short? Coexpression { get; set; }

    public short? Experimental { get; set; }

    public short? Database { get; set; }

    public short? Textmining { get; set; }

    public short? CombinedScore { get; set; }
}
