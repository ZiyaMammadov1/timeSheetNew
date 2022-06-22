using System;

namespace TimeSheet.Helper
{
    public class GuidManager
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
