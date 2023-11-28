using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnglabs.genomemanager.ui.Shared
{
    public class GMApplicationCacheKey : IGMCacheKey
    {
        public int PatientSampleID { get; set; }
        public string Panel { get; set; }
        public string Category { get; set; }

        public GMApplicationCacheKey(int patientSampleId, string panel, string category)
        {
            PatientSampleID = patientSampleId;
            Panel = panel;
            Category = category;
        }
        public GMApplicationCacheKey(IGMCacheKey remoteCacheKey, string category)
        {
            PatientSampleID = remoteCacheKey.PatientSampleID;
            Panel = remoteCacheKey.Panel;
            Category = category;
        }
        public override string ToString()
        {
            return $"ReviewDataset_{PatientSampleID}_{Panel}_{Category}";
        }
    }
}
