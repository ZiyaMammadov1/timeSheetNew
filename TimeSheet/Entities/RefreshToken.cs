using System;

namespace TimeSheet.Entities
{
    public class RefreshToken
    {
        public int id { get; set; }
        public int Userid { get; set; }
        public User User { get; set; }
        public string RefreshTokenString { get; set; }
        public DateTime RefreshTokenEndDate { get; set; }
    }
}
