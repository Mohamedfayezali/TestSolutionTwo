using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolutoin.Infrastructure.Seeding
{
    public static class AddUserToDB
    {
        //private static UserManager<IdentityUser> _userManager;

        //public AddUserToDB(UserManager<IdentityUser> userManager)
        //{
        //    _userManager = userManager;
        //    Handle();
        //}
        public static void SeedData(UserManager<IdentityUser> userManager)
        {
            SeedUsers(userManager);
        }
    private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("gamal@gmail.com").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "gamal@gmail.com";
                user.Email = "gamal@gmail.com";

               var result = userManager.CreateAsync(user, "Pa$$word123").Result;

                if (result.Succeeded)
                {
                   // userManager.AddToRoleAsync(user, "NormalUser").Wait();
                }
            }


            if (userManager.FindByNameAsync("gamal2@gmail.com").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "gamal2@gmail.com";
                user.Email = "gamal2@gmail.com";

                var result = userManager.CreateAsync(user, "Pa$$word123").Result;

                if (result.Succeeded)
                {
                    //.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        //private static void Handle(UserManager<IdentityUser> userManager)
        //{
        //    _userManager = userManager;
        //    var user = _userManager.FindByEmailAsync("gamal@gmail.com");
        //    if (user == null)

        //    {
        //        var identityUser = new IdentityUser
        //        {
        //            Email = "gamal@gmail.com",
        //            UserName = "gamal@gmail.com"
        //        };

        //        _userManager.CreateAsync(identityUser, "Gamal12345#");

        //    }
        //}

    }
}
