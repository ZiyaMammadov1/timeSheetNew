using FluentValidation;

namespace TimeSheet.Dtos.RefreshTokenDtos
{
    public class RefreshTokenDto
    {
        public string refreshtoken { get; set; }
    }
    public class RefreshTokenDtoValidator : AbstractValidator<RefreshTokenDto>
    {
        public RefreshTokenDtoValidator()
        {
            RuleFor(x => x.refreshtoken).NotEmpty().MaximumLength(50);
        }
    }
}
