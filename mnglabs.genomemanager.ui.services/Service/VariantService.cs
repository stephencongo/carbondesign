using mnglabs.genomemanager.ui.Shared;
using mnglabs.genomemanager.ui.Shared.DisplayModels;
using AutoMapper;

namespace mnglabs.genomemanager.ui.services.Service
{
    public interface IVariantService
    {
        List<int> GetProgramYears(string reviewType, string username, bool isProbandOnly);
        List<VariantDisplay> GetVariantDisplays(VariantFilterModel variantFilterModel);
        List<FrequencyData> GetFrequencyData(string chrMod, int pos, string refAllele, string altAllele, int variantId);
    }
    public class VariantService : IVariantService
    {
        private readonly ICacheService _cacheService;
        private readonly IDataManagerRepository _dataManagerRepository;
        private readonly IMapper _mapper;
        public VariantService(ICacheService cacheService, IDataManagerRepository dataManagerRepository, IMapper mapper)
        {
            _cacheService = cacheService;
            _dataManagerRepository = dataManagerRepository;
            _mapper = mapper;
        }

        public List<int> GetProgramYears(string reviewType, string username, bool isProbandOnly)
        {
            return new List<int>();
        }

        public List<VariantDisplay> GetVariantDisplays(VariantFilterModel variantFilterModel)
        {
            var specialCats = new List<string>() { "0", "1A", "2", "2A", "6" };
            if (specialCats.Contains(variantFilterModel.Category))
            {
                var lstVariants = _cacheService.GetVariantDisplaysFromAppCache(variantFilterModel.PatientSampleId, variantFilterModel.Panel, variantFilterModel.Category);

                if (lstVariants == null)
                {
                    switch (variantFilterModel.Category)
                    {
                        case "0":
                            var lstDataVariants = _dataManagerRepository.GetVariantDisplaysSelected(variantFilterModel.PatientSampleId, variantFilterModel.Panel);
                            return _mapper.Map<List<VariantDisplay>>(lstDataVariants);



                    }
                    return null;
                }
                else
                    return null;
            }
            else
            {
                var lstDataVariants = _dataManagerRepository.GetVariantDisplaysNoFilter(variantFilterModel);
                return _mapper.Map<List<VariantDisplay>>(lstDataVariants);
            }
        }

        public List<FrequencyData> GetFrequencyData(string chrMod, int pos, string refAllele, string altAllele, int variantId)
        {
            var lstFrequencyData = _dataManagerRepository.GetFrequencyData(chrMod, pos, refAllele, altAllele, variantId);
            return _mapper.Map<List<FrequencyData>>(lstFrequencyData);
        }


    }
}
