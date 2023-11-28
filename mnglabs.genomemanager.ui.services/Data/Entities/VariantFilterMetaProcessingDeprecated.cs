using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VariantFilterMetaProcessingDeprecated
{
    public int VariantId { get; set; }

    public string AnnotationSource { get; set; } = null!;

    public bool HasAminoAcidChange { get; set; }

    public bool HasDisruptive { get; set; }
}
