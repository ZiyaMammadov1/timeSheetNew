using FluentValidation;
using System;

namespace TimeSheet.Dtos.TimeİntervalDtos
{
    public class TimeIntervalGetDto
    {
        public DateTime? startDate{ get; set; }
        public DateTime? endDate{ get; set; }
    }
    public class TimeIntervalGetDtoValidator : AbstractValidator<TimeIntervalGetDto>
    {
        public TimeIntervalGetDtoValidator()
        {
               
        }
    }
}
