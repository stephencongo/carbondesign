using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class SampleVariantInfo
{
    public int SampleVariantId { get; set; }

    public string? Info { get; set; }

    public string? Format { get; set; }

    public string? FormatData { get; set; }

    public string? Filter { get; set; }

    public string? Dbsnp { get; set; }

    public string? ReferenceAminoAcid { get; set; }

    public string? AminoAcidChange { get; set; }

    public float? AlleleScore { get; set; }

    public byte? AminoAcidChangeTypeId { get; set; }
}
