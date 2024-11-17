using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vAPI.Models
{
    public class UserDetailsModel
    {
        // user id
        [Key]
        [Required(ErrorMessage = "User id is required")]
        public string UserId {get; set;} = "";
        
        // user name
        [Required(ErrorMessage = "User name is required")]
        public string UserName {get; set;} = "";
        
        // user unique id
        [Required(ErrorMessage = "User unique id is required")]
        [StringLength(12, MinimumLength =12, ErrorMessage = "UID must be 12 digits number")]
        public string UserUid {get; set;} = "";
        
        // user birth date
        [Required(ErrorMessage = "User birth date is required")]
        [DataType(DataType.Date)]
        public DateTime UserBirthDate {get; set;} = DateTime.MinValue;
        
        // user gender
        [Required(ErrorMessage = "User gender is required")]
        public string UserGender {get; set;} = "";
        
        // user phone
        [Required(ErrorMessage = "User phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number cannot be longer than 10 digits")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string UserPhone {get; set;} = "";
        
        // user role
        [Required(ErrorMessage = "User role is required")]
        public string UserRole {get; set;} = "";
    }
}