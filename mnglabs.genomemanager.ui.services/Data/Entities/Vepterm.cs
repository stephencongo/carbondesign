using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class Vepterm
{
    public byte VeptermId { get; set; }

    public string Term { get; set; } = null!;

    public string TermType { get; set; } = null!;

    public string? TermSubtype { get; set; }
}
