using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class Igvariant
{
    public int IgvariantId { get; set; }

    public int VariantId { get; set; }

    public int AcmgclassificationId { get; set; }

    public string? Igcomment { get; set; }
}
