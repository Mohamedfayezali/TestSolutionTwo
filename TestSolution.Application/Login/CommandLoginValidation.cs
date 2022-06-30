using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution.Application.Login
{
    public class CommandLoginValidation : AbstractValidator<CommandLogin>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CommandLoginValidation(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MinimumLength(5)
                .MaximumLength(50)
                .Must(CheckEmail).WithMessage("Email Not Found")
                ;

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50)
                //.MustAsync(CheckPassword)
                ;
        }
        private bool CheckEmail(string email)
        {
            var user = _userManager.FindByEmailAsync(email);
            if (user != null)
                return true;
            return false;
        }

        //private async Task<bool> CheckPassword(CommandLogin command, string password,CancellationToken cancellationToken)
        //{
        //    var user = await _userManager.FindByEmailAsync(command.Email);
        //    var findPassword = await _userManager.CheckPasswordAsync(user, password);

        //    return findPassword;
        //}


    }
}
