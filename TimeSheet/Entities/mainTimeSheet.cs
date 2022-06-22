using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Entities
{
    public class mainTimeSheet
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string projectid { get; set; }
        public string workTypeid { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime createdTime { get; set; }
        public decimal? hours { get; set; }
        public string description { get; set; }
        public bool isDeleted { get; set; }
    }
}
