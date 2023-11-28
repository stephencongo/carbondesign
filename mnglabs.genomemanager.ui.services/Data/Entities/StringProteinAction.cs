using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class StringProteinAction
{
    public int ActionId { get; set; }

    public string ItemIdA { get; set; } = null!;

    public string ItemIdB { get; set; } = null!;

    public string? Mode { get; set; }

    public string? Action { get; set; }

    public string? IsDirectional { get; set; }

    public string? AIsActing { get; set; }

    public short? Score { get; set; }
}
