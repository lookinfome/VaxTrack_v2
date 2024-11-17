using Microsoft.AspNetCore.Identity;
using vAPI.Models;

namespace vAPI.Services
{
    // interface: to expose the services
    public interface IAppUserService
    {
        public Task<IdentityResult> RegisterNewUser(string userid, string password, string role);
        public Task<string> LoginUser(string userid, string password);
    }

    // class: to define the implementation of services
    public class AppUserService : IAppUserService
    {
        // variable: to operate with SQLite DB
        private readonly AppDbContext _v2Context;

        // variable: to handle signup operations
        private readonly UserManager<AppUserModel> _userManager;

        // variable: to handle signin operations
        private readonly SignInManager<AppUserModel> _signInManager;

        // variable: to handle role creation and assigning operation
        private readonly RoleManager<IdentityRole> _roleManager;

        // contructor: to initialize the class variables
        public AppUserService (AppDbContext v2Context, SignInManager<AppUserModel> signInManager, UserManager<AppUserModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            _v2Context = v2Context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        // service: login existing user
        public async Task<string> LoginUser(string userid, string password)
        {
            var user = await _userManager.FindByNameAsync(userid);
            if (user == null)
            {
                return "Invalid userId/password";
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);
            
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();

            return role;
        }
        
        // service: register new user
        public async Task<IdentityResult> RegisterNewUser(string userid, string password, string role)
        {
            // mapping username fom submitted details to app user model
            var user = new AppUserModel
            {
                UserName = userid,
            };

            // saving app user model in asp-net-users table
            var result = await _userManager.CreateAsync(user, password);

            // if successful
            if(result.Succeeded)
            {
                // add role to asp-ne-users
                if(!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }

                // add role to the user
                await _userManager.AddToRoleAsync(user, role);
                
            }

            // return result
            return result;

        }


    }
}