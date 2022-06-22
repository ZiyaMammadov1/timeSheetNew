using FluentValidation;

namespace TimeSheet.Dtos.DepartmentDtos
{
    public class DepartmentPostDto
    {
        public string name { get; set; }
    }

    public class DepartmentPostDtoValidator : AbstractValidator<DepartmentPostDto>
    {
        public DepartmentPostDtoValidator()
        {
            RuleFor(x => x.name).NotEmpty().MaximumLength(100);
        }
    }
}
