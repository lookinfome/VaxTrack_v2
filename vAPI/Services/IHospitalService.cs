using Microsoft.CodeAnalysis.CSharp.Syntax;
using vAPI.Dto;
using vAPI.Models;

namespace vAPI.Services
{
    public interface IHospitalService
    {
        public List<HospitalDetailsDto_HospitalsList> FetchHospitalDetails();
        public HospitalDetailsDto_HospitalsList FetchHospitalDetailById(string hospitalId);
        public HospitalDetailsDto_HospitalsList FetchHospitalAvailableWith2Slots();
        public List<HospitalDetailsDto_HospitalsList> FetchHospitalAvailableWith1Slots();
    }

    public class HospitalService : IHospitalService
    {
        private readonly AppDbContext _v2Context;

        public HospitalService(AppDbContext v2Context)
        {
            _v2Context = v2Context;
        }

        // service: fetch hospital details
        public List<HospitalDetailsDto_HospitalsList> FetchHospitalDetails()
        {
            var hospitalDetails = _v2Context.HospitalDetails.Select(record => new HospitalDetailsDto_HospitalsList
            {
                HospitalId = record.HospitalId,
                HospitalName = record.HospitalName,
                HospitalAvailableSlots = record.HospitalAvailableSlots
            }).ToList();

            return hospitalDetails != null ? hospitalDetails : new List<HospitalDetailsDto_HospitalsList>();
        }

        // service: fetch hospital details by Id
        public HospitalDetailsDto_HospitalsList FetchHospitalDetailById(string hospitalId)
        {
            var hospitalDetail = _v2Context.HospitalDetails
                                        .Where(record => record.HospitalId == hospitalId)
                                        .Select(record => new HospitalDetailsDto_HospitalsList
                                        {
                                            HospitalId = record.HospitalId,
                                            HospitalName = record.HospitalName,
                                            HospitalAvailableSlots = record.HospitalAvailableSlots
                                        })
                                        .FirstOrDefault();
            
            return hospitalDetail ?? new HospitalDetailsDto_HospitalsList();
        }

        // service: fetch hospital with 2 available slots
        public HospitalDetailsDto_HospitalsList FetchHospitalAvailableWith2Slots()
        {
            HospitalDetailsDto_HospitalsList availableHospital = _v2Context.HospitalDetails.Where(record=>record.HospitalAvailableSlots >= 2)
                                                .Select(
                                                    record => new HospitalDetailsDto_HospitalsList
                                                    {
                                                        HospitalId = record.HospitalId,
                                                        HospitalName = record.HospitalName,
                                                        HospitalAvailableSlots = record.HospitalAvailableSlots
                                                    } 
                                                ).FirstOrDefault();

            return availableHospital ?? new HospitalDetailsDto_HospitalsList();
        }

        // service: fetch hospital with 1 available slots each
        public List<HospitalDetailsDto_HospitalsList> FetchHospitalAvailableWith1Slots()
        {
            List<HospitalDetailsDto_HospitalsList> availableHospitals = _v2Context.HospitalDetails.Where(record => record.HospitalAvailableSlots > 0)
                                                            .Select(
                                                                record => new HospitalDetailsDto_HospitalsList
                                                                {
                                                                    HospitalId = record.HospitalId,
                                                                    HospitalName = record.HospitalName,
                                                                    HospitalAvailableSlots = record.HospitalAvailableSlots
                                                                }
                                                            ).Take(2).OrderBy(record=>record.HospitalAvailableSlots).ToList();

            return availableHospitals.Count > 0 ? availableHospitals : new List<HospitalDetailsDto_HospitalsList>();
        }


    }

}