using FluentValidation;

namespace TimeSheet.Dtos.ProjectDtos
{
    public class ProjectGetDto
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
