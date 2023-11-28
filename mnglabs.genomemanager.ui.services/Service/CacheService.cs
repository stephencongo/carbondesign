using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mnglabs.genomemanager.ui.Shared;

namespace mnglabs.genomemanager.ui.services.Service
{
    public interface ICacheService
    {
        CacheResponse GetVariantDisplaysFromRemoteCache(int patientSampleId, string panel, string category);
        List<VariantDisplay> GetVariantDisplaysFromAppCache(int patientSampleId, string panel, string category);
    }
    public class CacheService : ICacheService
    {
        private readonly IGMApplicationCacheManager _applicationCacheManager;
        public CacheService(IGMApplicationCacheManager cacheManager)
        {
            _applicationCacheManager = cacheManager;
        }

        public CacheResponse GetVariantDisplaysFromRemoteCache(int patientSampleId, string panel, string category)
        {

            var cacheResponse = new CacheResponse();
            var specialCats = new List<string>() { "0", "1A", "2", "2A", "6" };

            if (specialCats.Contains(category))
            {
                var lstVariants = _applicationCacheManager.GetApplicationVariantCache(GetCacheKey(patientSampleId, panel, category));

                //if(lstVariants == null)
                //{
                //    if(string.Equals(category, "0"))
                //    {

                //    }
                //}
            }
            return null;
        }

        public List<VariantDisplay> GetVariantDisplaysFromAppCache(int patientSampleId, string panel, string category)
        {
            return _applicationCacheManager.GetApplicationVariantCache(GetCacheKey(patientSampleId, panel, category));
        }

        protected GMApplicationCacheKey GetCacheKey(int patientSampleId, string panel, string category)
        {
            return new GMApplicationCacheKey(patientSampleId, panel, category);
        }
    }
}

