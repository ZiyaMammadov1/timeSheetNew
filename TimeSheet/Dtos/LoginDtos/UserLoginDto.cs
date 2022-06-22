using FluentValidation;

namespace TimeSheet.Dtos.LoginDtos
{
    public class UserLoginDto
    {
        public string key { get; set; }
        public string password { get; set; }
    }

    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(x => x.key).MaximumLength(150);
            RuleFor(x => x.password).NotEmpty().MaximumLength(150);
        }
    }
}
