using vAPI.Models;

namespace vAPI.Services
{
    // interface: to expose the services
    public interface IBookingService
    {

    }

    // class: to define the implementation of services
    public class BookingService : IBookingService
    {
        // variable: to operate with SQLite DB
        private readonly AppDbContext _v2Context;

        // contructor: to initialize the class variables
        public BookingService(AppDbContext v2Context)
        {
            _v2Context = v2Context;
        }

        // update and save booking record for user

            

            // check if hospital with 2 slots available or not
                // if dose 1 and dose 2 date are available
                // if only dose 1 or dose 2 date is available
            // else check for 2 hospitals with 1 available slot each
                // if dose 1 and dose 2 date are available
                // if only dose 1 or dose 2 date is available
            // else return message - no slots avialable

    }
 

}