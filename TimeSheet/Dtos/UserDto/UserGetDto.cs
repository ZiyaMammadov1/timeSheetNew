using System;
using TimeSheet.Dtos.PositionDtos;

namespace TimeSheet.Dtos.UserDto
{
    public class UserGetDto
    {
        public string uuid { get; set; }
        public string cid { get; set; }
        public string fin { get; set; }
        public string email { get; set; }
        public string fullName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int positionId { get; set; }
        public PositionGetDto Position { get; set; }
        public DateTime createdTime { get; set; }
    }
}
