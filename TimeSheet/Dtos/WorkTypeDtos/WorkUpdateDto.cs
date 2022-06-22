using FluentValidation;

namespace TimeSheet.Dtos.WorkTypeDtos
{
    public class WorkUpdateDto
    {
        public string id { get; set; }
        public string info { get; set; }
        public string value { get; set; }
        public string color { get; set; }
        public string description { get; set; }
    }

    public class WorkUpdateDtoValidator : AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateDtoValidator()
        {
            RuleFor(x => x.id).NotEmpty().MaximumLength(100);
            RuleFor(x => x.info).NotEmpty().MaximumLength(100);
            RuleFor(x => x.value).NotEmpty().MaximumLength(20);
            RuleFor(x => x.description).NotEmpty().MaximumLength(2000);
            RuleFor(x => x.color).MaximumLength(50);
        }
    }
}
