using FluentValidation;

namespace TimeSheet.Dtos.WorkTypeDtos
{
    public class WorkPostDto
    {
        public string info { get; set; }
        public string value { get; set; }
        public string color { get; set; }
        public string description { get; set; }
    }

    public class WorkPostDtoValidator : AbstractValidator<WorkPostDto>
    {
        public WorkPostDtoValidator()
        {
            RuleFor(x => x.info).NotEmpty().MaximumLength(100);
            RuleFor(x => x.value).NotEmpty().MaximumLength(20);
            RuleFor(x => x.description).NotEmpty().MaximumLength(2000);
            RuleFor(x => x.color).MaximumLength(50);
        }
    }
}
