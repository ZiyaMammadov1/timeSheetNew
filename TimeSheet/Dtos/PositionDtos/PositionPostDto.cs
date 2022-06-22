using FluentValidation;

namespace TimeSheet.Dtos.PositionDtos
{
    public class PositionPostDto
    {
        public string name { get; set; }
    }
    public class PositionPostDtoValidator : AbstractValidator<PositionPostDto>
    {
        public PositionPostDtoValidator()
        {
            RuleFor(x => x.name).NotEmpty().MaximumLength(100);
        }
    }
}
