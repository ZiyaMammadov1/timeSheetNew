using FluentValidation;

namespace TimeSheet.Dtos.ProjectDtos
{
    public class ProjectUpdateDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string code { get; set; }

    }

    public class ProjectUpdateDtoValidator : AbstractValidator<ProjectUpdateDto>
    {
        public ProjectUpdateDtoValidator()
        {
            RuleFor(x => x.id).NotEmpty().MaximumLength(50);
            RuleFor(x => x.name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.code).NotEmpty().MaximumLength(150);
        }
    }
}
