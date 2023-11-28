using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class HgncmappingTable
{
    public int? HgncId { get; set; }

    public string? ApprovedSymbol { get; set; }

    public DateTime? DateSymbolChanged { get; set; }

    public string? EnsemblGeneId { get; set; }

    public int? NcbiGeneId { get; set; }

    public string? Status { get; set; }

    public int? OmimId { get; set; }

    public string? ApprovedName { get; set; }

    public string? UcscGeneId { get; set; }

    public string? VegaGeneId { get; set; }

    public string? MouseGenomeInformaticsMgiId { get; set; }

    public string? RatGenomeDatabaseRgdId { get; set; }
}
