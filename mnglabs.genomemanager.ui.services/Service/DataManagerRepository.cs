using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mnglabs.genomemanager.ui.services.Data.Entities;
using mnglabs.genomemanager.ui.services.Data;
using mnglabs.genomemanager.ui.Shared.DisplayModels;
using mnglabs.genomemanager.ui.services.Service;
using System.Data.Common;
using Microsoft.Data.SqlClient;
//using mnglabs.genomemanager.ui.Shared;
using mnglabs.genomemanager.ui.services.Data.Entities;
using Shared = mnglabs.genomemanager.ui.Shared;

namespace mnglabs.genomemanager.ui.services.Service
{
    public interface IDataManagerRepository
    {
        List<string> GetAnalytesForPanelFilter();
        //List<VariantDisplay> GetVariantDisplays(VariantFilterModel variantFilterModel);
        List<VariantDisplay> GetVariantDisplaysSelected(int patientSampleId, string panel);
        List<VariantDisplay> GetVariantDisplaysNoFilter(VariantFilterModel variantFilterModel);
        List<FrequencyData> GetFrequencyData(string chrMod, int pos, string refAllele, string altAllele, int variantId);
        List<Transcript> GetTranscripts(int sampleVariantId, int variantId);
        void AddUserLoginAttempt(UserLoginAttempt userLoginAttempt);
        List<UserLoginAttempt> GetUserLoginAttempts(string ipAddress);
        void UpdateUserLoginAttempts(UserLoginAttempt userLoginAttempt);
        void ClearLoginAttemps(string ipAddress);
    }
    public class DataManagerRepository : IDataManagerRepository
    {
        private DataManagerContext _dataManagerContext;
        private ICacheService _cacheService;
        public DataManagerRepository(DataManagerContext dataManagerContext, ICacheService cacheService)
        {
            _dataManagerContext = dataManagerContext;
            _cacheService = cacheService;
        }
        public List<string> GetAnalytesForPanelFilter()
        {
            //var analytes = _dataManagerContext.TestCodeAnalytesNarrows.FromSqlRaw("select t.testcode " +
            //    "FROM TestCodeAnalytesNarrow t WHERE TestCode LIKE '%NGS%' OR (TestCode LIKE '%MOL%') GROUP BY TestCode ORDER BY TestCode").ToList();

            var lstAnalytes = _dataManagerContext.TestCodeAnalytesNarrows.Where(t => t.TestCode.Contains("NGS") || t.TestCode.Contains("MOL"))
                .GroupBy(t => t.TestCode).ToList();
            var finalLstAnalytes = lstAnalytes.Select(a => a.Key).ToList();
            finalLstAnalytes.Insert(0, "EXOME");
            finalLstAnalytes.Insert(1, "mtDNA");
            return finalLstAnalytes;
        }

        //public List<VariantDisplay> GetVariantDisplays(VariantFilterModel variantFilterModel)
        //{

        //}

        public List<VariantDisplay> GetVariantDisplaysSelected(int patientSampleId, string panel)
        {
            //var lstVariants = _dataManagerContext.CatSelected(patientSampleId, panel);\
            var lstVariants = _dataManagerContext.CatSelected(42073, "exome");
            return lstVariants.ToList();
        }

        public List<VariantDisplay> GetVariantDisplaysNoFilter(VariantFilterModel variantFilterModel)
        {
            var dbPatientSample = new SqlParameter("PatientSampleId", System.Data.SqlDbType.Int) { Value = variantFilterModel.PatientSampleId };
            var dbTestCode = new SqlParameter("TestCode", System.Data.SqlDbType.VarChar) { Value = variantFilterModel.Panel };
            var categoryId = 0;

            int.TryParse(variantFilterModel.Category, out categoryId);

            var dbCategory = new SqlParameter("Category", System.Data.SqlDbType.Int) { Value = categoryId };
            var whereClause = VariantFilterWhereClause(variantFilterModel);
            var sqlStatement = "select * from dbo.CatAnyNoFilter(@PatientSampleId, @TestCode, @Category) ";
            if (whereClause != string.Empty)
                sqlStatement += "where " + VariantFilterWhereClause(variantFilterModel);
            var dtVariants = _dataManagerContext.DataTable(sqlStatement, dbPatientSample, dbTestCode, dbCategory);

            return dtVariants.ConvertDataTable<VariantDisplay>();

        }

        public void AddUserLoginAttempt(UserLoginAttempt userLoginAttempt)
        {
            _dataManagerContext.Add(userLoginAttempt);
            _dataManagerContext.SaveChangesAsync();
        }

        public List<UserLoginAttempt> GetUserLoginAttempts(string ipAddress)
        {
            return _dataManagerContext.UserLoginAttempts.Where(ula => ula.IpAddress.Equals(ipAddress)).ToList();
        }

        public void ClearLoginAttemps(string ipAddress)
        {
            var _loginAttempt = _dataManagerContext.UserLoginAttempts.FirstOrDefault(item => item.IpAddress.Equals(ipAddress));
            if (_loginAttempt != null)
            {
                _dataManagerContext.UserLoginAttempts.Remove(_loginAttempt);
                _dataManagerContext.SaveChangesAsync();
            }
        }
        public void UpdateUserLoginAttempts(UserLoginAttempt userLoginAttempt)
        {
            var _userLoginAttempt = _dataManagerContext.UserLoginAttempts.FirstOrDefault(item => item.IpAddress.Equals(userLoginAttempt.IpAddress));
            if (_userLoginAttempt != null)
            {
                _userLoginAttempt.LoginAttempts = userLoginAttempt.LoginAttempts;
                _dataManagerContext.SaveChangesAsync();
            }
        }

        public List<Transcript> GetTranscripts(int sampleVariantId, int variantId)
        {
            var sqlStatement = "SELECT distinct @SampleVariantID AS SampleVariantID, VTC.VariantID, CAST(" +
"CASE WHEN PT.TranscriptID IS NULL THEN 0 ELSE 1 END AS BIT) AS PreferredTranscript, " +
"GeneID," +

"COALESCE(MT.[Approved symbol]," +
"CASE WHEN VTC.AnnotationSource = 'Ensembl' THEN(SELECT[Gene Name] FROM EnsemblGene EG WHERE EG.[Gene Stable Id] = VTC.GeneID) ELSE '' END) AS GeneSymbol," +
"CASE WHEN VTC.AnnotationSource = 'Refseq' THEN 1 ELSE 0 END As IsRefseq," +

"AnnotationSource," +

"VTC.TranscriptID," +

"TranscriptBiotype," +

"TranslationID," +


"HGVSc," +


"HGVSp, " +


"Exon, " +


"Intron," +


"Codons," +

"SiftPredictionTerm," +

"PolyPhen2PredictionTerm," +


"ImpactTerm," +


"IsCanonical," +


"IsMostSevereConsequence, " +


"ConsequenceTerms," +
"GivenRef," +
"UsedRef" +
"    FROM VariantTranscriptConsequence VTC" +
" LEFT JOIN HGNCMappingTable MT ON VTC.GeneID =" +
"    CASE WHEN VTC.AnnotationSource = 'Ensembl' THEN[Ensembl gene ID]" +

"    WHEN VTC.AnnotationSource = 'Refseq' THEN CAST([NCBI gene ID] AS VARCHAR(25)) END" +
" LEFT JOIN IGPreferredRefseqTranscript PT ON PT.TranscriptID =" +
"    CASE WHEN VTC.TranscriptID LIKE '%.%'" +

"    THEN LEFT(VTC.[TranscriptID], CHARINDEX('.', VTC.TranscriptID)-1) " +

"    ELSE VTC.TranscriptID END" +

 "   AND VTC.AnnotationSource = 'REFSEQ'" +

 "   AND CAST(MT.[HGNC ID] AS VARCHAR(10)) = CAST(PT.HGNCGeneID AS VARCHAR(10))WHERE VTC.VariantID = @VariantID" +
" AND IsCanonical = 0 " +

"ORDER BY IsRefseq desc, PreferredTranscript, GeneSymbol, IsCanonical DESC, IsMostSevereConsequence DESC";

            var dbVariantId = new SqlParameter("VariantId", System.Data.SqlDbType.VarChar) { Value = variantId };
            var dbSampleVariantId = new SqlParameter("SampleVariantId", System.Data.SqlDbType.Int) { Value = sampleVariantId };

            var dtTranscript = _dataManagerContext.DataTable(sqlStatement, dbVariantId, dbSampleVariantId);
            return dtTranscript.ConvertDataTable<Transcript>();
        }

        public List<FrequencyData> GetFrequencyData(string chrMod, int pos, string refAllele, string altAllele, int variantId)
        {
            var dbChrMod = new SqlParameter("ChrMod", System.Data.SqlDbType.VarChar) { Value = chrMod };
            var dbPos = new SqlParameter("Pos", System.Data.SqlDbType.Int) { Value = pos };
            var dbRefAllele = new SqlParameter("REFAllele", System.Data.SqlDbType.VarChar) { Value = refAllele };
            var dbAltAllele = new SqlParameter("ALTAllele", System.Data.SqlDbType.VarChar) { Value = altAllele };
            var dbVariantId = new SqlParameter("VariantID", System.Data.SqlDbType.Int) { Value = variantId };

            var sqlStatement = "SELECT Source, PercentString, @ChrMod AS ChrMod, @Pos AS Pos, @REFAllele AS REFAllele, @ALTAllele AS ALTAllele  FROM" +
                "\r\n(SELECT '1KG' as Source,  PercentString FROM Variant V INNER JOIN DataManagerReference.dbo.ThousandGenomesProcessingReference TGPR ON V.ThousandGenomesRowID = TGPR.ThousandGenomesRowID " +
                "WHERE V.VariantID = @VariantID\r\nUNION\r\nSELECT 'MitoMap' as Source, PercentString FROM Variant V INNER JOIN DataManagerReference.dbo.MitoMapFreqProcessingReference MMFPR ON V.MitoMapRowID =" +
                " MMFPR.MitoMapRowID WHERE V.VariantID = @VariantID\r\nUNION \r\nSELECT 'GnomAD Genomes' AS Source, MAXPOP + ' - ' + CAST(ROUND(CAST((AC_MAXPOP*1.0)/(AN_MAXPOP*1.0)*100 AS FLOAT), 2) AS Varchar(50))" +
                " AS PercentString FROM Variant V INNER JOIN\r\nDataManagerReference.dbo.GnomadGenomesProcessingReference GPR ON V.GnomadGenomesRowID = GPR.GnomadGenomesRowID\r\nWHERE V.VariantID = @VariantID\r\nUNION" +
                "\r\nSELECT 'GnomAD Exomes' AS Source, MAXPOP + ' - ' + CAST(ROUND(CAST((AC_MAXPOP*1.0)/(AN_MAXPOP*1.0)*100 AS FLOAT), 2) AS Varchar(50)) AS PercentString FROM Variant V INNER JOIN\r\nDataManagerReference." +
                "dbo.GnomadExomesProcessingReference GPR ON V.GnomadExomesRowID = GPR.GnomadExomesRowID\r\nWHERE V.VariantID = @VariantID\r\n) A";

            var dtFrequencyData = _dataManagerContext.DataTable(sqlStatement, dbChrMod, dbPos, dbRefAllele, dbAltAllele, dbVariantId);
            return dtFrequencyData.ConvertDataTable<FrequencyData>();
        }

        private string VariantFilterWhereClause(VariantFilterModel variantFilterModel)
        {
            var whereString = new StringBuilder();

            switch (variantFilterModel.View)
            {
                case "1":
                    whereString.Append("Denovo=1");
                    break;
                case "2":
                    whereString.Append("HasAminoAcidChange=1");
                    break;
                case "3":
                    whereString.Append("Homozygous='Homozygous'");
                    break;
                case "5":
                    whereString.Append("HasDisruptive=1");
                    break;
                case "7":
                    whereString.Append("CaseNum=1");
                    break;
                case "8":
                    whereString.Append("SampleNum=1");
                    break;
                case "9":
                    whereString.Append("HasAminoAcidChange=1 AND HasDisruptive=0");
                    break;

            }


            if (variantFilterModel.ACMGGenesOnly)
                whereString.Append("ACMGGene=1");

            var alleleRatio = 0.0M;
            var readDepthFilter = 0;

            if (variantFilterModel.FilterByAllelleRatio && decimal.TryParse(variantFilterModel.AlleleRatio, out alleleRatio))
                whereString.Append($"(AlleleRatio)>={alleleRatio.ToString()}");

            if (variantFilterModel.FilterByReads && int.TryParse(variantFilterModel.NumberOfReads, out readDepthFilter))
                whereString.Append($"(VariantCoverage)>={readDepthFilter.ToString()}");

            return string.Join(" AND ", whereString);
        }


    }
}
