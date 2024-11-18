using vAPI.Models;
using vAPI.Dto;

namespace vAPI.Services
{
    // interface: to expose the services
    public interface IAccountService
    {
        public Task<bool> RegisterNewUser(AccountDetailsDto_Registration submittedDetails);
        public Task<UserDetailsDto_UserProfile> LoginUser(AccountDetailsDto_Login submittedDetails);
    }

    // class: to define the implementation of services
    public class AccountService : IAccountService
    {
        // variable: to operate with SQLite DB
        private readonly AppDbContext _v2Context;

        // variable: to handle signin and signup operations
        private readonly IAppUserService _appUserService;

        // variable: to handle user details service
        private readonly IUserDetailsService _userDetailsService;

        // contructor: to initialize the class variables
        public AccountService(AppDbContext v2Context, IAppUserService appUserService, IUserDetailsService userDetailsService)
        {
            _v2Context = v2Context;
            _appUserService = appUserService;
            _userDetailsService = userDetailsService;
        }

        // service: login existing user
        public async Task<UserDetailsDto_UserProfile> LoginUser(AccountDetailsDto_Login submittedDetails)
        {
            // Await the asynchronous method
            string userId = await _appUserService.LoginUser(submittedDetails.UserId, submittedDetails.UserPassword);

            // Fetch user details
            if (!string.IsNullOrEmpty(userId))
            {
                UserDetailsDto_UserProfile userProfileDetails = _userDetailsService.FetchUserDetailsById(userId);

                return userProfileDetails;
            }

            return new UserDetailsDto_UserProfile();
        }


        // service: register new user
        public async Task<bool> RegisterNewUser(AccountDetailsDto_Registration submittedDetails)
        {
            // register userid and hased password in asp-net-table, with their role
            var registrationResult = await _appUserService.RegisterNewUser(submittedDetails.UserId, submittedDetails.UserPassword, submittedDetails.UserRole);

            if (registrationResult.Succeeded)
            {
                // create a new record for new user
                UserDetailsModel newUserDetail = new UserDetailsModel
                {
                    UserId = submittedDetails.UserId,
                    UserName = submittedDetails.UserName,
                    UserUid = submittedDetails.UserUid,
                    UserBirthDate = submittedDetails.UserBirthDate,
                    UserGender = submittedDetails.UserGender,
                    UserPhone = submittedDetails.UserPhone,
                    UserRole = submittedDetails.UserRole
                };

                // adding new user details to table
                _v2Context.UserDetails.Add(newUserDetail);

                // save changes to the database
                int dbOP1Status = _v2Context.SaveChanges();

                if (dbOP1Status >= 0)
                {
                    // create a new record for vaccination for new user
                    UserVaccineDetailsModel newUserVaccineDetail = new UserVaccineDetailsModel
                    {
                        UserVaccinationId = submittedDetails.UserVaccinationId,
                        UserVaccinationStatus = "Not Vaccinated",
                        UserId = submittedDetails.UserId
                    };

                    // adding new user vaccination details to table
                    _v2Context.UserVaccineDetails.Add(newUserVaccineDetail);

                    // save changes to the database
                    int dbOP2Status = _v2Context.SaveChanges();

                    if (dbOP2Status >= 0)
                    {
                        // create a new record for booking details for new user
                        BookingDetailsModel newUserBookingDetails = new BookingDetailsModel
                        {
                            BookingId = submittedDetails.BookingId,
                            UserVaccinationId = submittedDetails.UserVaccinationId
                        };

                        // adding new user booking details to table
                        _v2Context.BookingDetails.Add(newUserBookingDetails);

                        // save changes to the database
                        int dbOP3Status = _v2Context.SaveChanges();

                        return dbOP3Status >= 0 ? true : false;
                    }

                }

            }

            return false;
        }

    }

}