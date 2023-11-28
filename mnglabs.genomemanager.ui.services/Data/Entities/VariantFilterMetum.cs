using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VariantFilterMetum
{
    public int VariantId { get; set; }

    public bool HasAminoAcidChange { get; set; }

    public bool HasDisruptive { get; set; }
}
