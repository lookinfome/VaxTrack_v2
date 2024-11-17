namespace vAPI.Dto
{
    public class AccountDetailsDto_Login
    {
        public string UserId {get; set;} = "";
        public string UserPassword {get; set;} = "";
    }

    public class AccountDetailsDto_Registration
    {
        public string UserId {get; set;} = "";
        public string UserPassword {get; set;} = "";
        public string UserName {get; set;} = "";
        public string UserUid {get; set;} = "";
        public DateTime UserBirthDate {get; set;} = DateTime.MinValue;
        public string UserGender {get; set;} = "";
        public string UserPhone {get; set;} = "";
        public string UserRole {get; set;} = "";
        public string UserVaccinationId {get; set;} = "";
        public string BookingId {get; set;} = "";
    }
}