using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TimeSheet.Entities;

namespace TimeSheet.Dtos.TimeSheetDtos
{
    public class TimeSheetGetDto
    {
        public string id { get; set; }
        public string projectid { get; set; }
        public string workTypeId { get; set; }
        public DateTime? start { get; set; }
        public DateTime createdTime { get; set; }
        public decimal? hours { get; set; }
        public string description { get; set; }


        [NotMapped]
        public string Calendar { get; set; }
    }
   
}
