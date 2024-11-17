using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace vAPI.Models
{
    public class AppDbContext : IdentityDbContext<AppUserModel>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // models to be migerate to DB as table        
        public DbSet<UserDetailsModel> UserDetails { get; set; }
        public DbSet<UserVaccineDetailsModel> UserVaccineDetails { get; set; }
        public DbSet<BookingDetailsModel> BookingDetails { get; set; }
        public DbSet<HospitalDetailsModel> HospitalDetails {get; set;}
        
    }
}