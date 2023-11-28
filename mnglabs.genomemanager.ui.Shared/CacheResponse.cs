using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnglabs.genomemanager.ui.Shared
{
    public class CacheResponse
    {
        public DatasetRequestOutcome Outcome { get; set; }
        public List<VariantDisplay> VariantDisplays { get; set; }
    }
}
