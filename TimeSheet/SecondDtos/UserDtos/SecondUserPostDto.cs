using FluentValidation;
using System;

namespace TimeSheet.SecondDtos.UserDtos
{
    public class SecondUserPostDto
    {
        public string cid { get; set; }
        public string fin { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string position { get; set; }
        public DateTime createdTime { get; set; }
        public string department { get; set; }
        public DateTime dateOfBirthday { get; set; }
    }
    public class SecondUserPostDtoValidator : AbstractValidator<SecondUserPostDto>
    {
        public SecondUserPostDtoValidator()
        {
            RuleFor(x => x.fin).NotEmpty().MaximumLength(10);
            RuleFor(x => x.email).MaximumLength(150);
            RuleFor(x => x.firstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.lastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.position).NotEmpty().MaximumLength(200);
            RuleFor(x => x.department).NotEmpty().MaximumLength(300);
        }
    }
}
