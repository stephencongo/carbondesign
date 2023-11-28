using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VariantLocu
{
    public int VariantLocusId { get; set; }

    public string ChrMod { get; set; } = null!;

    public int Pos { get; set; }

    public int RefAlleleId { get; set; }

    public string LocusType { get; set; } = null!;

    public bool InCdsbed { get; set; }

    public bool? KnownPathogenicGene { get; set; }

    public virtual ICollection<LocusGene> LocusGenes { get; set; } = new List<LocusGene>();

    public virtual ICollection<Variant> Variants { get; set; } = new List<Variant>();

    public virtual ICollection<PatientSample> PatientSamples { get; set; } = new List<PatientSample>();
}
