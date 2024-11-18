using vAPI.Models;
using vAPI.Dto;

namespace vAPI.Services
{
    // interface: to expose the services
    public interface IUserDetailsService
    {
        public UserDetailsDto_UserProfile FetchUserDetailsById (string userid);
    }

    // class: to define the implementation of services
    public class UserDetailsService : IUserDetailsService
    {
        // variable: to operate with SQLite DB
        private readonly AppDbContext _v2Context;

        // contructor: to initialize the class variables
        public UserDetailsService(AppDbContext v2Context)
        {
            _v2Context = v2Context;
        }

        // service: fetch user details by user id
        public UserDetailsDto_UserProfile FetchUserDetailsById (string userid)
        {
            var userDetails = _v2Context.UserDetails.Where(record=>record.UserId == userid)
                                .Select(record=> new UserDetailsDto_UserProfile 
                                {
                                    UserId = record.UserId,
                                    UserName = record.UserName,
                                    UserUid = record.UserUid,
                                    UserBirthDate = record.UserBirthDate,
                                    UserGender = record.UserGender,
                                    UserPhone = record.UserPhone,
                                    UserRole = record.UserRole
                                }).FirstOrDefault();
            
            return userDetails != null ? userDetails : new UserDetailsDto_UserProfile {};
        }

    }
}