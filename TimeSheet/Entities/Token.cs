using System;
using System.ComponentModel.DataAnnotations.Schema;
using TimeSheet.Dtos.UserDto;

namespace TimeSheet.Entities
{
    public class Token
    {
        public string token { get; set; }
        public DateTime ExpiredTime { get; set; }
        public string RefreshToken { get; set; }

        [NotMapped]
        public UserGetDto Detail { get; set; }
    }
}
    