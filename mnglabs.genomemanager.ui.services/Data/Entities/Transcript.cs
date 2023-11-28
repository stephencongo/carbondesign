using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnglabs.genomemanager.ui.services.Data.Entities
{
    public class Transcript
    {
        public int SampleVariantId { get; set; }
        public int VariantId { get; set; }
        public bool PreferredTranscript { get; set; }
        public int GeneId { get; set; }
        public string GeneSymbol { get; set; }
        public string AnnotationSource { get; set; }
        public int TranscriptId { get; set; }
        public string TranscriptBiotype { get; set; }
        public int TranslationId { get; set; }
        public string Hgvsp { get; set; }
        public string Exon { get; set; }
        public string Intron { get; set; }
        public string Codons { get; set; }
        public string SiftPredictionTerm { get; set; }
        public string PolyPhen2PredictionTerm { get; set; }
        public string ImpactTerm { get; set; }
        public bool IsCanonical { get; set; }
        public bool IsMostSevereConsequence { get; set; }
        public string ConsequenceTerms { get; set; }
        public string GivenRef { get; set; }
        public string UsedRef { get; set; }
        public bool IsRefseq { get; set; }
        public string Hgvsc { get; set; }
    }
}
