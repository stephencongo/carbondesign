using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnglabs.genomemanager.ui.Shared
{
    public class Variant
    {
        public string? VariantInfo { get; set; }
        public string? Classification { get; set; }
        public string? Criteria { get; set; }
        public string? Notes { get; set; }
        public int Interpretation { get; set; }
        public int Samples { get; set; }
        public int Cases { get; set; }
        public string? SampleName { get; set; }
        public string? Phenotype { get; set; }
        public string? DiseaseAssociations { get; set; }
        public string? HGMDPhenotype { get; set; }
        public string? HGMDInheritance { get; set; }
        public string? HGMDClassification { get; set; }
        public string? FrequencyData { get; set; }
        public string? Zygosity { get; set; }
        public string? LocusCoverage { get; set; }
        public string? VariantCoverage { get; set; }
        public string? Transcripts { get; set; }
        public string? CLNREVSTAT { get; set; }
        public string? AlleleRatio { get; set; }
        public string? MNGFrequency { get; set; }
    }
}
