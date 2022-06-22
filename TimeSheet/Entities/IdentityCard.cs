using System;

namespace TimeSheet.Entities
{
    public class IdentityCard
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string fin { get; set; }
        public bool status { get; set; }
        public string series { get; set; }
        public DateTime deliveryTime{ get; set; }
        public DateTime expiredTime { get; set; }
        public string govermentName { get; set; }
        public string Address { get; set; }

        public int userId { get; set; }
        public User User { get; set; }
    }
}
