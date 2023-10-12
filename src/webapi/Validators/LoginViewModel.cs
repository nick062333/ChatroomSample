using FluentValidation;
using webapi.ViewModels.Auth;

namespace webapi.Validators
{
    public class LoginViewModelValidator :  AbstractValidator<LoginViewModel> 
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Account)
                .NotEmpty().WithMessage("帳號為必填")
                .Length(0, 20).WithMessage("帳號長度需小於20字元");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("密碼為必填");
        }
    }
}