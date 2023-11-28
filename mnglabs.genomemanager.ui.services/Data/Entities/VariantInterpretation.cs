using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VariantInterpretation
{
    public int VariantInterpretationId { get; set; }

    public int? VariantId { get; set; }

    public string? Interpretation { get; set; }

    public DateTime? DateUpdated { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Variant? Variant { get; set; }
}
