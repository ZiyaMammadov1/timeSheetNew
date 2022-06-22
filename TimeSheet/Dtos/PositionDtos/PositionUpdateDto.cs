using FluentValidation;

namespace TimeSheet.Dtos.PositionDtos
{
    public class PositionUpdateDto
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class POsitionUpdateDtoValidator : AbstractValidator<PositionUpdateDto>
    {
        public POsitionUpdateDtoValidator()
        {
            RuleFor(x => x.id).NotEmpty().MaximumLength(100);
            RuleFor(x => x.name).NotEmpty().MaximumLength(100);
        }
    }
}
