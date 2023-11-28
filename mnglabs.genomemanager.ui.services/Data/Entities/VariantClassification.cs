using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VariantClassification
{
    public string UserName { get; set; } = null!;

    public int VariantId { get; set; }

    public int ClassificationId { get; set; }

    public DateTime? ClassificationDate { get; set; }

    public virtual Variant Variant { get; set; } = null!;
}
