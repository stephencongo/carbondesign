using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnglabs.genomemanager.ui.Shared
{
    public class FrequencyDataRequest
    {
        public string ChrMod { get; set; }
        public int Pos { get; set; }
        public string RefAllele { get; set; }
        public string AltAllele { get; set; }
        public int VariantId { get; set; }
    }
}
