using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class SelectedTranscript
{
    public long SampleVariantId { get; set; }

    public int VariantId { get; set; }

    public string TranscriptId { get; set; } = null!;
}
