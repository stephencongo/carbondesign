using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class HgncgeneInfo
{
    public int HgncId { get; set; }

    public string? Status { get; set; }

    public string? ApprovedSymbol { get; set; }

    public string? ApprovedName { get; set; }

    public string? AliasSymbol { get; set; }

    public string? AliasName { get; set; }

    public string? PreviousSymbol { get; set; }

    public string? PreviousName { get; set; }

    public string? Chromosome { get; set; }

    public string? ChromosomeLocation { get; set; }

    public string? LocusGroup { get; set; }

    public string? LocusType { get; set; }

    public string? HgncFamilyId { get; set; }

    public string? HgncFamilyName { get; set; }

    public DateTime? DateApproved { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? DateSymbolChanged { get; set; }

    public DateTime? DateNameChanged { get; set; }
}
