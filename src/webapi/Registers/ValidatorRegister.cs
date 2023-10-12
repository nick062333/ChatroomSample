using FluentValidation;
using FluentValidation.AspNetCore;
using webapi.Interceptors;
using webapi.Validators;

namespace webapi.Registers
{
    public static class ValidatorRegister
    {
        public static void RegisterValidator(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<UserViewModelValidator>();
            services.AddTransient<IValidatorInterceptor, CustomValidatorErrorInterceptor>();
        } 
    }
}
