namespace DemoAPI.Models.Request
{
    public class PositionRequest
    {
        public int PositionId { get; set; }
        public string PositionNameKh { get; set; }
        public string PositionNameEn { get; set; }
        public int IsAvtive { get; set; }
        public string CreateBy { get; set; }
        public string CUD { get; set; }


    }
}
