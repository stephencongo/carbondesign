using Microsoft.AspNetCore.Mvc;
using mnglabs.genomemanager.ui.services.Service;
using mnglabs.genomemanager.ui.Shared;
using mnglabs.genomemanager.ui.Shared.DisplayModels;

namespace mnglabs.genomemanager.ui.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VariantController : ControllerBase
    {
        private readonly ILogger<AuthorizeController> _logger;
        private readonly IDataManagerRepository _dataManagerRepository;
        private readonly IVariantService _variantService;
        public VariantController(ILogger<AuthorizeController> logger, IDataManagerRepository dataManagerRepository, IVariantService variantService)
        {
            _logger = logger;
            _dataManagerRepository = dataManagerRepository;
            _variantService = variantService;
        }

        [HttpGet]
        [Route("ProgramYears")]
        public IActionResult GetProgramYears()
        {
            return Ok();
        }

        [HttpGet]
        [Route("Samples")]
        public IActionResult GetSamples()
        {
            return Ok();
        }

        [HttpGet]
        [Route("Filter/Panel")]
        public IActionResult GetPanelsForVariantFilter()
        {
            var panels = _dataManagerRepository.GetAnalytesForPanelFilter();
            return Ok(panels);
        }

        [HttpPost]
        [Route("VariantDisplay")]
        public IActionResult GetVariants([FromBody] VariantFilterModel variantFilterModel)
        {
            var lstVariants = _variantService.GetVariantDisplays(variantFilterModel);
            return Ok(lstVariants);
        }

        [HttpPost]
        [Route("FrequencyData")]
        public IActionResult GetFrequencyData(FrequencyDataRequest frequencyDataRequest)
        {
            var lstFrequencyData = _variantService.GetFrequencyData(frequencyDataRequest.ChrMod, frequencyDataRequest.Pos, frequencyDataRequest.RefAllele,
                frequencyDataRequest.AltAllele, frequencyDataRequest.VariantId);
            return Ok(lstFrequencyData);
        }
    }
}
