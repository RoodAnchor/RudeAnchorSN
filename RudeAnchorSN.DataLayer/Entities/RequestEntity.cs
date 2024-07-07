namespace RudeAnchorSN.DataLayer.Entities
{
    public class RequestEntity
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public bool IsAccepted { get; set; } = false;
    }
}
