using Microsoft.AspNetCore.Mvc;
using vAPI.Services;
using vAPI.Dto;

namespace vAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet("FetchHospitalDetails")]
        public IActionResult FetchHospitalDetails()
        {
            var hospitalDetails = _hospitalService.FetchHospitalDetails();

            return hospitalDetails.Count > 0 ? Ok(hospitalDetails) : NotFound(new {hospitalDetails = new {}});

        }

        [HttpGet("FetchHospitalDetailById")]
        public IActionResult FetchHospitalDetailById(string hospitalId)
        {
            var hospitalDetails = _hospitalService.FetchHospitalDetailById(hospitalId);

            return hospitalDetails.HospitalId != null ? Ok(hospitalDetails) : NotFound(new {hospitalDetails = new {}});
        }

        [HttpGet("FetchHospitalAvailableWith2Slots")]
        public IActionResult FetchHospitalAvailableWith2Slots()
        {
            var availableHospital = _hospitalService.FetchHospitalAvailableWith2Slots();

            return availableHospital.HospitalId != null ? Ok(availableHospital) : NotFound(new {availableHospital = new {}});

        }

        [HttpGet("FetchHospitalAvailableWith1Slots")]
        public IActionResult FetchHospitalAvailableWith1Slots()
        {
            var availableHospital = _hospitalService.FetchHospitalAvailableWith1Slots();

            return availableHospital.Count > 0 ? Ok(availableHospital) : NotFound(new {availableHospital = new {}}); 
        }

    }
}