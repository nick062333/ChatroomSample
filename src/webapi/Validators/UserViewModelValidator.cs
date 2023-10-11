using DataClass.DTOs;
using FluentValidation;
using webapi.ViewModels.Users;

namespace webapi.Validators
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel> 
    {
        public UserViewModelValidator()
        {
            RuleFor(x => x.Account)
                .NotEmpty().WithMessage("帳號為必填")
                .Length(0, 20).WithMessage("帳號長度需小於20字元");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("密碼為必填");
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("姓名為必填")
                .Length(0, 20).WithMessage("帳號長度需小於20字元");
        }
    }
}
