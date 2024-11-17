using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vAPI.Dto
{
    public class UserDetailsDto_UserProfile
    {
        public string UserId {get; set;} = "";
        public string UserName {get; set;} = "";
        public string UserUid {get; set;} = "";
        public DateTime UserBirthDate {get; set;} = DateTime.MinValue;
        public string UserGender {get; set;} = "";
        public string UserPhone {get; set;} = "";
        public string UserRole {get; set;} = "";
    }
}