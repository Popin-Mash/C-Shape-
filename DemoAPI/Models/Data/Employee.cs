using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models.Data
{
    public class Employee
    {
        [Key]
        public string EmployeeId { get; set; }
        public string EmployeeNameKh { get; set; }
        public string EmployeeNameEn { get; set; }
        public string Gender { get; set; }
        public string PositionId { get; set; }
        public string DepartmentId { get; set; }
        public string VillageId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
