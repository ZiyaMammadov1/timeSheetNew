namespace TimeSheet.Entities
{
    public class WorkType
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string info { get; set; }
        public string value { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public bool isDeleted { get; set; }
    }
}
