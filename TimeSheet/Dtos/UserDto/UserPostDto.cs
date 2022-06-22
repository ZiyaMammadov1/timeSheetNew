using FluentValidation;
using System;

namespace TimeSheet.Dtos.UserDto
{
    public class UserPostDto
    {
        public string cid { get; set; }
        public string fin { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int positionId { get; set; }
        public DateTime createdTime { get; set; }
        public int departmentId { get; set; }
        public DateTime dateOfBirthday { get; set; }
        public string imageUrl { get; set; }

    }

    public class UserPostDtoValidator : AbstractValidator<UserPostDto>
    {
        public UserPostDtoValidator()
        {
            RuleFor(x => x.fin).NotEmpty().MaximumLength(10);
            RuleFor(x => x.email).NotEmpty().MaximumLength(150);
            RuleFor(x => x.password).NotEmpty().MaximumLength(150);
            RuleFor(x => x.firstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.lastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.positionId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.departmentId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.dateOfBirthday).NotEmpty();
        }
    }

}
