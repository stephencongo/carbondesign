using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using mnglabs.genomemanager.ui.Shared;

namespace mnglabs.genomemanager.ui.services.Service
{
    public interface IGMApplicationCacheManager
    {
        List<VariantDisplay> GetApplicationVariantCache(GMApplicationCacheKey cacheKey);
        void UpdateApplicationVariantCache(List<VariantDisplay> variantDisplays, GMApplicationCacheKey cacheKey);
        void RemoveFromCacheIfExists(GMApplicationCacheKey cacheKey);
    }
    public class GMApplicationCacheManager : IGMApplicationCacheManager
    {
        private readonly IMemoryCache _appCache;

        public GMApplicationCacheManager(IMemoryCache memoryCache)
        {
            _appCache = memoryCache;
        }

        public List<VariantDisplay> GetApplicationVariantCache(GMApplicationCacheKey cacheKey)
        {

            _appCache.TryGetValue(cacheKey.ToString(), out var variantDisplay);
            return (List<VariantDisplay>)variantDisplay;

        }

        public void UpdateApplicationVariantCache(List<VariantDisplay> variantDisplays, GMApplicationCacheKey cacheKey)
        {
            _appCache.Set(cacheKey.ToString(), variantDisplays, new TimeSpan(0, 5, 0));
        }

        public void RemoveFromCacheIfExists(GMApplicationCacheKey cacheKey)
        {
            if (_appCache.Get(cacheKey.ToString()) != null)
            {
                _appCache.Remove(cacheKey.ToString());
            }
        }
    }
}
