using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models.Data
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentNameKh { get; set; }
        public string DepartmentNameEn { get; set; }
        public int IsActive { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime lastUpdateDate { get; set; }
    }
}
