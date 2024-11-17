using System.ComponentModel.DataAnnotations;

namespace vAPI.Models
{
    public class HospitalDetailsModel
    {
        [Key]
        [Required(ErrorMessage = "Hospital id is required")]
        public string HospitalId {get; set;} = "";

        [Required(ErrorMessage = "Hospital name is required")]
        public string HospitalName {get; set;} = "";

        [Required(ErrorMessage = "Hospital available slots is required")]
        public int HospitalAvailableSlots {get; set;} = 0;
    }
}