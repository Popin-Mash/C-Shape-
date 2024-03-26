namespace DemoAPI.Models.Request
{
    public class DepartmentRequest
    {
        public int DepartmentId { get; set; }
        public string DepartmentNameKh { get; set; }
        public string DepartmentNameEn { get; set; }
        public int IsActive { get; set; }
        public string CreateBy { get; set; }
    }
}
