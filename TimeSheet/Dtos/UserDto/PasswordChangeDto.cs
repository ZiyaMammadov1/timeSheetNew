using FluentValidation;

namespace TimeSheet.Dtos.UserDto
{
    public class PasswordChangeDto
    {
        public int id { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class PasswordChangheDtoValidator : AbstractValidator<PasswordChangeDto>
    {
        public PasswordChangheDtoValidator()
        {
            RuleFor(x => x.id).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(x => x.NewPassword).NotEmpty().MaximumLength(150);
            RuleFor(x => x.ConfirmPassword).NotEmpty().MaximumLength(150);
        }
    }
}
