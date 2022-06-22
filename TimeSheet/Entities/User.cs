using System;
using System.Collections.Generic;

namespace TimeSheet.Entities
{
    public class User
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string cid { get; set; }
        public string fin { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public string fullName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool isDeleted { get; set; }
        public DateTime dateOfBirthday { get; set; }
        public int age { get; set; }
        public DateTime createdTime { get; set; }
        public string photo { get; set; }

        public int positionId { get; set; }
        public Position Position { get; set; }

        public int departmentId { get; set; }
        public Department Department { get; set; }

        public List<Salary> userSalaries { get; set; } = new List<Salary>();
        public List<IdentityCard> userIdentityCards { get; set; } = new List<IdentityCard>();


    }

}
