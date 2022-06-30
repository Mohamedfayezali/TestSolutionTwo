using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestSolution.Application.Register;

namespace TestSolution.Application.Login
{
    public class CommandLoginHandler : IRequestHandler<CommandLogin, Response?>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CommandLoginHandler(UserManager<IdentityUser> userManager,IConfiguration configuration,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        public async Task<Response?> Handle(CommandLogin request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return new Response
                {
                    Message = "Email Not Found",
                    IsSucsess = false
                };

            var result = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!result)
                return new Response
                {
                    Message = "Password is not correct",
                    IsSucsess = false
                };

            //var userRoles = await _userManager.GetRolesAsync(user);
            //foreach (var userRole in userRoles)
            //{
            //    new Claim(ClaimTypes.Role, userRole);
            //}

            var claims = await GetAllClaims(user);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha256)
                );

            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new Response
            {
                Message = stringToken,
                IsSucsess = true,
                ExpireDate = token.ValidTo,
            };

        }


       // this method is very immportant to understand
        public async Task<List<Claim>> GetAllClaims(IdentityUser user)
        {
            var claims = new List<Claim>
            {   
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.NameId,user.Id),
                new Claim("JEMY","Ia'm here")
            };

            //getting the claims that we have assigned to the user
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            //getting the user roles and added it the the claims
            var userRoles = await _userManager.GetRolesAsync(user);

            foreach(var userRole in userRoles)
            {
                var role = await _roleManager.FindByNameAsync(userRole); //for safty major

                //check if the user role exist 
                if(role != null)
                {
                    //here adding the user role to list of claims
                    claims.Add(new Claim(ClaimTypes.Role, userRole));//exchange ClaimTypes.Role with "role" ("role":"Admin") => my soluthion for this problem
                                                            //("http://schemas.microsoft.com/ws/2008/06/identity/claims/role":"Admin") 
                                                           
                    //getting all roleclaims associated the role
                    var roleClaims = await _roleManager.GetClaimsAsync(role);

                    foreach(var roleClaim in roleClaims)
                    {
                        //add roleclaims to the main claim in this method
                        claims.Add(roleClaim);
                    }

                }
            }

            return claims;
        }


    }
}
