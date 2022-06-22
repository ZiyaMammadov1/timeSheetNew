using FluentValidation;

namespace TimeSheet.Dtos.ProjectDtos
{
    public class ProjectPostDto
    {
        public string name { get; set; }
        public string code { get; set; }

    }

    public class ProjectPostDtoValidator : AbstractValidator<ProjectPostDto>
    {
        public ProjectPostDtoValidator()
        {
            RuleFor(x => x.name).NotEmpty().MaximumLength(100);
        }
    }
}
