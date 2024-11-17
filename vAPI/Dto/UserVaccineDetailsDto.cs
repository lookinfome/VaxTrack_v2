using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vAPI.Dto
{
    public class UserVaccineDetailsDto_UserVaccinationReport
    {
        public string UserId {get; set;} = "";
        public string UserVaccinationStatus {get; set;} = "";
        public string BookingId {get; set;} = "";
        public DateTime Dose1Date {get; set;} = DateTime.MinValue;
        public string D1HospitalName {get; set;} = "";
        public int D1SlotNumber {get; set;} = 0;
        public DateTime Dose2Date {get; set;} = DateTime.MinValue;
        public string D2HospitalName {get; set;} = "";
        public int D2SlotNumber {get; set;} = 0;
    }
}