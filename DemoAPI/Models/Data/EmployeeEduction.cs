using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models.Data
{
    public class EmployeeEduction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeEducationId { get; set; }
        public string EmployeeId { get; set; }
        public string EducationLevel { get; set; }
        public string Majo { get; set; }
        public string SchoolName { get; set; }
        public string YearStart { get; set; }
        public string YearEnd { get; set; }

    }
}
