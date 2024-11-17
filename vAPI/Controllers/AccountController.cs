using Microsoft.AspNetCore.Mvc;
using vAPI.Services;
using vAPI.Dto;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace vAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("LoginUser")]
        public IActionResult LoginUser([FromBody] AccountDetailsDto_Login submittedDeails)
        {
            if(submittedDeails != null)
            {
                return Ok(new {userRole = _accountService.LoginUser(submittedDeails).Result});
            }

            return NotFound(new {message = new {}});
        }


        [HttpPost("RegisterNewUser")]
        public IActionResult RegisterNewUser([FromBody] AccountDetailsDto_Registration submittedDetails)
        {
            if(submittedDetails != null)
            {
                return Ok(new {registrationStatus = _accountService.RegisterNewUser(submittedDetails).Result});
            }

            return NotFound(new {message = new{}});
        }
    }
}