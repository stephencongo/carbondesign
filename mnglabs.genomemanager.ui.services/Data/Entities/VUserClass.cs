using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VUserClass
{
    public string ChrMod { get; set; } = null!;

    public int Pos { get; set; }

    public string? Ref { get; set; }

    public string? Alt { get; set; }

    public string UserClass { get; set; } = null!;

    public int VariantId { get; set; }
}
