﻿using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VGeneBedRegionPadded
{
    public string? Chr { get; set; }

    public int? StartPos { get; set; }

    public int? EndPos { get; set; }

    public string? GeneSymbol { get; set; }

    public string GeneId { get; set; } = null!;
}
