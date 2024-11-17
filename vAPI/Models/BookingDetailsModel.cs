using System.ComponentModel.DataAnnotations;

namespace vAPI.Models
{
    public class BookingDetailsModel
    {
        // booking id
        [Key]
        [Required(ErrorMessage = "Booking id is required")]
        public string BookingId {get; set;} = "";

        // dose 1 date
        [Required(ErrorMessage = "Dose 1 date is required")]
        public DateTime Dose1Date {get; set;} = DateTime.MinValue;

        // dose 1 hospital name
        [Required(ErrorMessage = "Dose 1 hospital name is required")]
        public string D1HospitalName {get; set;} = "";

        // dose 1 slot number
        [Required(ErrorMessage = "Dose 1 slot number")]
        public int D1SlotNumber {get; set;} = 0;
        
        // dose 2 date
        [Required(ErrorMessage = "Dose 2 date is required")]
        public DateTime Dose2Date {get; set;} = DateTime.MinValue;
        
        // dose 2 hospital name
        [Required(ErrorMessage = "Dose 2 hospital name is required")]
        public string D2HospitalName {get; set;} = "";
        
        // dose 2 slot number
        [Required(ErrorMessage = "Dose 2 slot number")] 
        public int D2SlotNumber {get; set;} = 0;

        // user vaccination id
        [Required(ErrorMessage = "User vaccination id is reuqired")]
        public string UserVaccinationId {get; set;} = "";
    }
}