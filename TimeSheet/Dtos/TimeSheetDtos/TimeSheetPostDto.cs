using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TimeSheet.Entities;

namespace TimeSheet.Dtos.TimeSheetDtos
{
    public class TimeSheetPostDto
    {
        public string projectid { get; set; }
        public string workTypeId { get; set; }
        public DateTime? startDate { get; set; }
        public string description { get; set; }
        public bool isDeleted { get; set; }
        public decimal? hours{ get; set; }
        public DateTime createdTime { get; set; }
    }
    public class TimeSheetPostDtoValidator : AbstractValidator<TimeSheetPostDto>
    {
        public TimeSheetPostDtoValidator()
        {
            RuleFor(x => x.projectid).NotEmpty().MaximumLength(50);
            RuleFor(x => x.workTypeId).NotEmpty().MaximumLength(50);
            RuleFor(x => x.startDate).NotEmpty();
            RuleFor(x => x.hours).NotEmpty().GreaterThan(0);
            RuleFor(x => x.description).MaximumLength(3000);
        }
    }
}
