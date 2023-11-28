using System;
using System.Collections.Generic;

namespace mnglabs.genomemanager.ui.services.Data.Entities;

public partial class VariantTranscriptConsequence
{
    public int VariantId { get; set; }

    public string? AnnotationSource { get; set; }

    public string? GeneId { get; set; }

    public string TranscriptId { get; set; } = null!;

    public string? TranslationId { get; set; }

    public string? Hgvsc { get; set; }

    public string? Hgvsp { get; set; }

    public string? Codons { get; set; }

    public string? ConsequenceTerms { get; set; }

    public string? ImpactTerm { get; set; }

    public string? TranscriptBiotype { get; set; }

    public bool? IsCanonical { get; set; }

    public bool? IsMostSevereConsequence { get; set; }

    public string? Exon { get; set; }

    public string? Intron { get; set; }

    public string? GivenRef { get; set; }

    public string? UsedRef { get; set; }

    public string? BamEdit { get; set; }

    public string? GeneIdsource { get; set; }

    public string? EnsemblTranscriptId { get; set; }

    public string? EnsemblTranslationId { get; set; }

    public int? VariantTranscriptConsequenceId { get; set; }

    public byte? SiftPredictionTermId { get; set; }

    public byte? PolyPhen2PredictionTermId { get; set; }

    public string? SiftPredictionTerm { get; set; }

    public string? PolyPhen2PredictionTerm { get; set; }
}
