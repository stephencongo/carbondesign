using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace mnglabs.genomemanager.ui.Shared.DisplayModels
{
    public class VariantFilterModel
    {
        public int PatientSampleId { get; set; }
        public string? ProbandOnly { get; set; }
        public string? Worklist { get; set; }
        public string? ProgramYear { get; set; }
        public string? Panel { get; set; }
        public string? Category { get; set; }
        public bool ACMGGenesOnly { get; set; }
        public bool StringAllCategories { get; set; }
        public bool FilterByAllelleRatio { get; set; }
        public string? AlleleRatio { get; set; }
        public bool FilterByReads { get; set; }
        public string? NumberOfReads { get; set; }
        public string? View { get; set; }
        public string? SortBy { get; set; }
        public string? RowsPerPage { get; set; }
        public string? UCSCCoordRange { get; set; }

        public List<string?> TestCodes { get; set; }
    }
}
