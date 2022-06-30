using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TestSolution.Application.Services.UserRoleServices.Commandes.AddUserToRole;
using TestSolution.Application.Services.UserRoleServices.Commandes.CreateRoleCommand;
using TestSolution.Application.Services.UserRoleServices.Commandes.RemoveUserFromRole;
using TestSolution.Application.Services.UserRoleServices.Queries.GetRoles;
using TestSolution.Application.Services.UserRoleServices.Queries.GetUserRoles;

namespace TestSolution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMediator _mediator;

        public TestController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager,IMediator mediator)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllRoles()
        {
            //var roles = _roleManager.Roles.ToList();
            //return Ok(roles);
            // return Ok(await _mediator.Send(new RolesQuery()));
            //var userName = User?.Identity?.Name;
            //var userRole = User?.Claims.FirstOrDefault(b => b.Type.Equals("role", StringComparison.InvariantCultureIgnoreCase));
            //var token = "[encoded jwt]";
            //var handler = new JwtSecurityTokenHandler();
            //var jwtSecurityToken = handler.ReadJwtToken(token);
            //var role = jwtSecurityToken.Claims.First(claim => claim.Type == "role").Value;

            //var userName = User.FindFirst(ClaimTypes.Role)?.Value;
            //var userIdentity = (ClaimsIdentity)User.Identity;
            //var claims = userIdentity?.Claims;
            //var roleClaimType = userIdentity?.RoleClaimType;

            //var userRoles = new List<string>();

            var roles = User.Claims?.Where(c => c.Type.ToString().Equals("jemy",StringComparison.InvariantCultureIgnoreCase)).Select(b => b.Value).ToList();
            //if(roles==null||roles.Count==0)
            //    return BadRequest(string.Empty);
            //foreach(var role in roles)
            //{
            //    userRoles.Add(role.Value);               
            //}

            var role2 = User.FindFirstValue(ClaimTypes.Role);
            var name = User.FindFirstValue(ClaimTypes.Name);
            var email = User.FindFirstValue(ClaimTypes.Email);
            var userName = User.Identity.Name;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var allClaimsValues =  User.Claims.Select(b => b.Value).ToList();
            var any = User.Claims.Select(b =>b.Value).Where(b=>b.Equals(userName)).ToList();
            var allClaims = User.Claims.ToList();

            // or...
           // var roles2 = claims.Where(c => c.Type == roleClaimType).ToList();

            return Ok(allClaims);
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(string name)
        {
            //var roleExist = await _roleManager.RoleExistsAsync(name);       

            //if (!roleExist)
            //{
            //   var addRole = await _roleManager.CreateAsync(new IdentityRole(name));
            //    if(addRole.Succeeded)
            //    return Ok(true);
            //    else
            //      return BadRequest (new { error = "Can not create role" });
            //}

            //return BadRequest(new { error = "role exist before" });
            return Ok(await _mediator.Send(new RoleCommand() { RoleName = name}));
        }

        [HttpPost("AddUserToRole")]
        public async Task<IActionResult> AddRoleToUser(string email , string role)
        {
            // //check if the user is exist
            // var user = await _userManager.FindByEmailAsync(email);

            // if(user == null)
            // {
            //     return BadRequest(new { error = "the user is not exist" });
            // }

            // //check if the role is exist
            // var roleExists = await _roleManager.RoleExistsAsync(role);
            // if (!roleExists)
            // {
            //     return BadRequest(new { error = "the role not exist" });
            // }

            //// var identityUser = await _userManager.FindByEmailAsync(email);


            // var addingRoleToUser = await _userManager.AddToRoleAsync(user, role);
            // if (addingRoleToUser.Succeeded)
            // {
            //     return Ok("the user added to role successfuly");
            // }
            // else
            //     return BadRequest(new { error = "can not add user to role correctly" });

            return Ok(await _mediator.Send(new UserToRoleCommand() { Email = email, RoleName = role }));

        }

        [HttpGet("getUserRoles")]
        public async Task<IActionResult> GetUserRoles(string email)
        {

            //var user = await _userManager.FindByEmailAsync(email);
            ////if user not found 
            //if (user == null)
            //    return BadRequest(new { error = "invalid email" });

            //var roles = await _userManager.GetRolesAsync(user);

            ////if the user does not have any role
            //if (!roles.Any())
            //    return BadRequest(new { error = "user does not have any role" });
            //return Ok(roles);

            return Ok(await _mediator.Send(new UserRoles() { Email = email}));
        }

        [HttpPost]
        [Route("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(string email,string userRole)
        {

            //    var user = await _userManager.FindByEmailAsync(email);
            //    //check if the user exist
            //    if (user == null)
            //    {
            //        return BadRequest(new { error = "the user is not exist" });
            //    }

            //    var roleExists = await _roleManager.RoleExistsAsync(userRole);
            //    //check if the role is exist
            //    if (!roleExists)
            //    {
            //        return BadRequest(new { error = "the role not exist" });
            //    }

            //    //if the Role have a User
            //    var userExistInTheRole = await _userManager.IsInRoleAsync(user,userRole);
            //    if(userExistInTheRole)
            //    {
            //        //remove the user from the role
            //        var removeUserFromRole = await _userManager.RemoveFromRoleAsync(user, userRole);
            //        if (removeUserFromRole.Succeeded)
            //        {
            //            return Ok($"The User Removed From The {userRole} Role");
            //        }
            //        return BadRequest($"The User Does Not Removed From The {userRole} Role");
            //    }
            //    return BadRequest($"The {user} Does Not Have The {userRole} Role");

            return Ok(await _mediator.Send(new UserFromRoleCommand() { Email = email,UserRole = userRole}));
        }


    }
}
