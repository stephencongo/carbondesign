using Microsoft.AspNetCore.Mvc;
using mnglabs.genomemanager.ui.Shared;
using mnglabs.genomemanager.ui.services.Service;
using AutoMapper;
using mnglabs.genomemanager.ui.services.Data.Entities;
using Shared = mnglabs.genomemanager.ui.Shared;
using mnglabs.genomemanager.ui.Shared.DisplayModels;

namespace mnglabs.genomemanager.ui.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private readonly ILogger<AuthorizeController> _logger;
        private readonly IDataManagerRepository _repository;
        private readonly IMapper _mapper;
        public AuthorizeController(ILogger<AuthorizeController> logger, IDataManagerRepository dataManagerRepository, IMapper mapper)
        {
            _logger = logger;
            _repository = dataManagerRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            //return Ok(LoginResult.Success);
            if (!ADAuthentication.UserExistsInAD("LCA", loginRequest.Username))
                return Ok(LoginResult.NoSuchADUser);

            if (ADAuthentication.IsUserPasswordExpired("LCA", loginRequest.Username) || ADAuthentication.UserMustChangePassword("LCA", loginRequest.Username))
                return Ok(LoginResult.MustChangePassword);

            if (ADAuthentication.CanAuthenticate("LCA", loginRequest.Username, loginRequest.Password))
                return Ok(LoginResult.Success);
            else
                return Ok(LoginResult.Failed);

        }

        [HttpPost]
        [Route("GetLoginAttempts")]
        public async Task<IActionResult> GetLoginAttempts(IpAddressModel ipAddress)
        {
            var userLoginAttempt = _repository.GetUserLoginAttempts(ipAddress.IpAddress);
            if(userLoginAttempt.Count > 0)
            {
                return Ok(_mapper.Map<Shared.UserLoginAttempt>(userLoginAttempt.FirstOrDefault()));
            }
            return Ok(null);
        }
        [HttpPost]
        [Route("RecordLoginAttempt")]
        public async Task<IActionResult> RecordLoginAttempt(Shared.UserLoginAttempt userLoginAttempt)
        {
            try
            {
                var _userLoginAttempt = _mapper.Map<mnglabs.genomemanager.ui.services.Data.Entities.UserLoginAttempt>(userLoginAttempt);
                if (_repository.GetUserLoginAttempts(userLoginAttempt.IpAddress).Count() > 0)
                {
                    _repository.UpdateUserLoginAttempts(_userLoginAttempt);
                }
                else
                {
                    _repository.AddUserLoginAttempt(_userLoginAttempt);
                }
            }catch(Exception ex)
            {
                var message = ex.Message;
            }

            return Ok();
        }

        [HttpPost]
        [Route("ClearLoginAttempt")]
        public async Task<IActionResult> ClearLoginAttempt(IpAddressModel ipAddress)
        {
            
            _repository.ClearLoginAttemps(ipAddress.IpAddress);
            return Ok();
        }
    }
}
