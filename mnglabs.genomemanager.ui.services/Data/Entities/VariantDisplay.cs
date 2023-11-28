using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnglabs.genomemanager.ui.services.Data.Entities
{
    public class VariantDisplay
    {
        public int VariantId { get; set; }
        public int VariantLocusId { get; set; }
        public long SampleVariantId { get; set; }
        public int PatientSampleId { get; set; }
        public int PatientCaseId { get; set; }
        public string? SampleName { get; set; }
        public string? Disease { get; set; }
        public string? HgmdPheno { get; set; }
        public string? HgmdInheritance { get; set; }
        public string? HgmdClassification { get; set; }
        public string? ChrMod { get; set; }
        public int ChrSortIndex { get; set; }
        public int Pos { get; set; }
        public string? LocusType { get; set; }
        public string? Homozygous { get; set; }
        public int LocusCoverage { get; set; }
        public int VariantCoverage { get; set; }
        public string? Ref { get; set; }
        public string? Alt { get; set; }
        public long Rs { get; set; }
        public string? Pmid { get; set; }
        public double AlleleRatio { get; set; }
        public bool HasDisruptive { get; set; }
        public bool HasAminoAcidChange { get; set; }
        public int SampleNum { get; set; }
        public int CaseNum { get; set; }
        public double MngFrequency { get; set; }
        public bool DeNovo { get;set; }
        public bool AcmgGene { get; set; }
        public string? CLNREVSTAT { get; set; }
    }
}
