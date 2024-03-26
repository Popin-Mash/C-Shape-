using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models.Data
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }
        public string PositionNameKh { get; set; }
        public string PositionNameEn { get; set; }
        public int IsAvtive { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }

    }
}
