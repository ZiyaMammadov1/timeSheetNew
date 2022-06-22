using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Entities
{
    public class Salary
    {
        public int id { get; set; }
        public string uuid { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal salary { get; set; }
        public DateTime incrementTime { get; set; }


        public int userId { get; set; }
        public User User { get; set; }
    }
}
