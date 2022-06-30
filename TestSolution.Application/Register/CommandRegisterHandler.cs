using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace TestSolution.Application.Register
{
    public class CommandRegisterHandler : IRequestHandler<CommandRegister,Response?>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CommandRegisterHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response?> Handle(CommandRegister register, CancellationToken cancellationToken)
        {

            //if (register.Password != register.ConfirmPassword)
            //    return new Response
            //    {
            //        Message = "confirm password does not match the password",
            //        IsSucsess = false,
            //    };

            var identityUser = new IdentityUser
            {
                Email = register.Email,
                UserName = register.Email,
            };

            var result = await _userManager.CreateAsync(identityUser, register.Password);

            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(identityUser, new Claim("Created_claim", "this is a created claim for a new registered user"));
                var addUserToRole = await _userManager.AddToRoleAsync(identityUser, "Normal");
                if (addUserToRole.Succeeded)
                    return new Response
                    {
                        Message = "Creating Succesfuly",
                        IsSucsess = true
                    };
                else
                    return new Response 
                    { 
                        Message = "The User Is Creating Succesfuly But Can't Added To the Normal Role",
                        IsSucsess = true
                    };
            }
            return new Response
            {
                Message = "User did not Created",
                IsSucsess = false,
                Errors = result.Errors.Select(b => b.Description)
            };


        }

    }
}
