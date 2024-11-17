using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using vAPI.Services;
using vAPI.Dto;

namespace vAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserVaccineDetailsController : ControllerBase
    {
        private readonly IUserVaccineDetailsService _userVaccineDetailsService;
        public UserVaccineDetailsController(IUserVaccineDetailsService userVaccineDetailsService)
        {
            _userVaccineDetailsService = userVaccineDetailsService;
        }

        [HttpGet("GetUserVaccineReportById")]
        public IActionResult GetUserVaccineReportById (string userid)
        {
            if(!string.IsNullOrEmpty(userid))
            {
                UserVaccineDetailsDto_UserVaccinationReport userVaccineReport = _userVaccineDetailsService.FetchUserVaccinationReportById(userid);

                return userVaccineReport != null ? Ok(userVaccineReport) : NotFound(new { message = "User vaccination report not found." }); 

            }

            Console.WriteLine($"---i am in else part---");

            return NotFound(new {message = new {}}); 
        }
    }
}