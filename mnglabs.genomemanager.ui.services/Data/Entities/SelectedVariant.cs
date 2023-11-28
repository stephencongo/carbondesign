using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class SelectedVariant
{
    public string UserName { get; set; } = null!;

    public long SampleVariantId { get; set; }

    public int PatientSampleId { get; set; }

    public virtual SampleVariant SampleVariant { get; set; } = null!;
}
