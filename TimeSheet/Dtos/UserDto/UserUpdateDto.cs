using FluentValidation;

namespace TimeSheet.Dtos.UserDto
{
    public class UserUpdateDto
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string cid { get; set; }
        public string fin { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int positionId { get; set; }
    }

    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            RuleFor(x => x.id).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(x => x.uuid).NotEmpty().MaximumLength(20);
            RuleFor(x => x.fin).NotEmpty().MaximumLength(10);
            RuleFor(x => x.cid).MaximumLength(50);
            RuleFor(x => x.email).NotEmpty().MaximumLength(150);
            RuleFor(x => x.firstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.lastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.positionId).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
