using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestSolution.Application.Commend;
using TestSolution.Application.Login;
using TestSolution.Application.Query;
using TestSolution.Application.Register;
using TestSolution.Domain;

namespace TestSolution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // api/User/Register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody]CommandRegister command)
        {           
            return Ok(await _mediator.Send(command));
        }


        //api/User/Login
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody]CommandLogin command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpGet]
        [Authorize(Roles = "AppUser")]
        public async Task<IActionResult> GetAll()
        {
            return Ok( await _mediator.Send(new GetUsersQuery()));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            return Ok( await _mediator.Send(new GetUserQuery() { Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand commend)
        {
            return Ok( await _mediator.Send(commend));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id,UpdateUserCommand update)
        {
            update.UserId=id;
            return Ok(await _mediator.Send(update));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute]Guid id)
        {
            return Ok( await _mediator.Send(new DeleteUserCommand() { UserId = id}));
        }
        
    }
}
