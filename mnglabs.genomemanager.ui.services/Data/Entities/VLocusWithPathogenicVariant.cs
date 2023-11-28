using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VLocusWithPathogenicVariant
{
    public int VariantLocusId { get; set; }

    public string ChrMod { get; set; } = null!;

    public int Pos { get; set; }

    public long? BigCount { get; set; }
}
