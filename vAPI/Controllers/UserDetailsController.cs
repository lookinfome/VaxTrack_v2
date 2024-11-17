using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using vAPI.Services;
using vAPI.Dto;

namespace vAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailsService _userDetailsService;

        public UserDetailsController(IUserDetailsService userDetailsService)
        {
            _userDetailsService = userDetailsService;
        }

        [HttpGet("GetUserDetailsById")]
        public IActionResult GetUserDetailsById(string userid)
        {
            if(!string.IsNullOrEmpty(userid))
            {
                UserDetailsDto_UserProfile userDetails = _userDetailsService.FetchUserDetailsById(userid);

                return userDetails != null ? Ok(userDetails) : NotFound(new {message = new {}});
                
            }

            return NotFound(new {message = new {}}); 
        }



    }
}
