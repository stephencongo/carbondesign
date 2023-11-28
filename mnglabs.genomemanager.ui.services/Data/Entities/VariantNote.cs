using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VariantNote
{
    public string UserName { get; set; } = null!;

    public int VariantId { get; set; }

    public string Note { get; set; } = null!;

    public DateTime? NoteDate { get; set; }

    public virtual Variant Variant { get; set; } = null!;
}
