using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class Hgncgene
{
    public int HgncId { get; set; }

    public string? ApprovedSymbol { get; set; }

    public string? ApprovedName { get; set; }

    public string? Status { get; set; }
}
