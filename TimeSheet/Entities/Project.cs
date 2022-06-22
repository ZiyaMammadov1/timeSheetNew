namespace TimeSheet.Entities
{
    public class Project
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public bool isDeleted { get; set; }
    }
}
