using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnglabs.genomemanager.ui.services.Data.Entities
{
    public class FrequencyData
    {
        public string Source { get; set; }
        public string PercentString { get; set; }
        public string ChrMod { get; set; }
        public int Pos { get; set; }
        public string RefAllele { get; set; }
        public string AltAllele { get; set; }
    }
}
