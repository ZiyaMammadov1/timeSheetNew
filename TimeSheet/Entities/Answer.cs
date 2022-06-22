using System.Collections.Generic;

namespace TimeSheet.Entities
{
    public class Answer<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        #nullable enable
        public List<T> Result { get; set; }

        public Answer(int statusCode, string message, List<T> ?result)
        {
            StatusCode = statusCode;
            Message = message;
            Result = result ?? new List<T>();
        }  
     
    }
}
