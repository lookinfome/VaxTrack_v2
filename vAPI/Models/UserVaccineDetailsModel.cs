using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vAPI.Models
{
    public class UserVaccineDetailsModel
    {
        // user vaccination id
        [Key]
        [Required(ErrorMessage = "User vaccination id")]
        public string UserVaccinationId {get; set;} = "";

        // user vacciation status
        [Required(ErrorMessage = "User vaccination status is required")]
        public string UserVaccinationStatus {get; set;} = "";

        // user id
        [Required(ErrorMessage = "User id is required")]
        public string UserId {get; set;} = "";
    }
}