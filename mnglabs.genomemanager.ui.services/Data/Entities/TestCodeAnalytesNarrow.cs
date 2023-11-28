using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class TestCodeAnalytesNarrow
{
    public string TestCode { get; set; } = null!;

    public string NextGeneSym { get; set; } = null!;

    public string WebsiteTestCode { get; set; } = null!;

    public string Analyte { get; set; } = null!;
}
