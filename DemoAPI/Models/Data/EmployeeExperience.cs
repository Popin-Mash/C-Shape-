using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models.Data
{
    public class EmployeeExperience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeExperiendId { get; set; }
        public string EmployeeId { get; set; }
        public string Position { get; set; }
        public string Salary { get; set; }
        public DateTime DateJoin { get; set; }
        public DateTime DateResign { get; set; }

    }
}

