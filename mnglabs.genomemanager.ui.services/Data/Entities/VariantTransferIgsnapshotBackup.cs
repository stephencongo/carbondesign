using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VariantTransferIgsnapshotBackup
{
    public string Chr { get; set; } = null!;

    public int Pos { get; set; }

    public string RefAllele { get; set; } = null!;

    public string AltAllele { get; set; } = null!;

    public int IgclassificationId { get; set; }

    public string? Igcomment { get; set; }
}
