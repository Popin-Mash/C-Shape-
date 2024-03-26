namespace DemoAPI.Models.Request
{
    public class EmployeeExperienceRequest
    {
        public int EmployeeExperiendId { get; set; }
        public string Position { get; set; }
        public string Salary { get; set; }
        public DateTime DateJoin { get; set; }
        public DateTime DateResign { get; set; }
    }
}
