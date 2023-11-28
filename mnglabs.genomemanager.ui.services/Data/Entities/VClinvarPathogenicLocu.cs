using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VClinvarPathogenicLocu
{
    public int VariantLocusId { get; set; }

    public string ChrMod { get; set; } = null!;

    public int Pos { get; set; }

    public string? Ref { get; set; }

    public string LocusType { get; set; } = null!;
}
