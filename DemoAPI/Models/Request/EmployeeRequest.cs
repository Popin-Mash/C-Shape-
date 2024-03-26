namespace DemoAPI.Models.Request
{
    public class EmployeeRequest
    {
        public string EmployeeId { get; set; }
        public string EmployeeNameKh { get; set; }
        public string EmployeeNameEn { get; set; }
        public string Gender { get; set; }
        public string PositionId { get; set; }
        public string DepartmentId { get; set; }
        public string VillageId { get; set; }
        public string CreateBy { get; set; }

        public List<EmployeeExperienceRequest> EmployeeExperienceRequests { get; set; }
        public List<EmployeeEductionRequest> EmployeeEductionRequests { get; set; }

    }
}
