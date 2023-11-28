using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnglabs.genomemanager.ui.Shared
{
    
    public interface IGMCacheKey
    {
        int PatientSampleID { get; set; }
        string Panel { get; set; }
    }
}
