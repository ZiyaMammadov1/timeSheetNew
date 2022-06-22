using FluentValidation;
using System;

namespace TimeSheet.Dtos.TimeSheetDtos
{
    public class TimeSheetUpdateDto
    {
        public string id { get; set; } 
        public string title { get; set; }
        public string projectid { get; set; }
        public string workTypeId { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public DateTime forWhen { get; set; }
        public string description { get; set; }
    }

    public class TimeSheetUpdateDtoValidator : AbstractValidator<TimeSheetUpdateDto>
    {
        public TimeSheetUpdateDtoValidator()
        {
            RuleFor(x => x.id).NotEmpty().MaximumLength(50);
            RuleFor(x => x.title).NotEmpty().MaximumLength(400);
            RuleFor(x => x.projectid).NotEmpty().MaximumLength(50);
            RuleFor(x => x.workTypeId).NotEmpty().MaximumLength(50);
            RuleFor(x => x.startDate).NotEmpty();
            RuleFor(x => x.endDate).NotEmpty();
            RuleFor(x => x.forWhen).NotEmpty();
            RuleFor(x => x.description).NotEmpty().MaximumLength(3000);
        }
    }
}
