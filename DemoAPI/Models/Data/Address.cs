using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models.Data
{
    public class Address
    {
        [Key]
        public string Id { get; set; }
        public string NameKh { get; set; }
        public string NameEn { get; set; }
        public string ParentId { get; set; }
    }
}
