using FluentValidation;

namespace TimeSheet.Dtos.DepartmentDtos
{
    public class DepartmentUpdateDto
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    public class DepartmentUpdateDtoValidator : AbstractValidator<DepartmentUpdateDto>
    {
        public DepartmentUpdateDtoValidator()
        {
            RuleFor(x => x.id).NotEmpty().MaximumLength(100);
            RuleFor(x => x.name).NotEmpty().MaximumLength(100);
        }
    }
}
