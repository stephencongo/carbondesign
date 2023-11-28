using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VariantTransferMngsnapshot
{
    public string Chr { get; set; } = null!;

    public int Pos { get; set; }

    public string RefAllele { get; set; } = null!;

    public string AltAllele { get; set; } = null!;

    public string Acmgclassification { get; set; } = null!;

    public string? Mngcomment { get; set; }

    public int RefAlleleId { get; set; }

    public int AltAlleleId { get; set; }
}
