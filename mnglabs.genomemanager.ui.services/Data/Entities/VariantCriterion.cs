using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VariantCriterion
{
    public int VariantId { get; set; }

    public int AcmgcriteriaId { get; set; }

    public string UserName { get; set; } = null!;

    public virtual Variant Variant { get; set; } = null!;
}
