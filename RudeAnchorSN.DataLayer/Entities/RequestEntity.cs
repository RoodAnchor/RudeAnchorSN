namespace RudeAnchorSN.DataLayer.Entities
{
    public class RequestEntity
    {
        public Guid Guid { get; set; }
        public DateTime DateTime { get; set; }
        public Guid FromUserGuid { get; set; }
        public Guid ToUserGuid { get; set; }
        public bool IsAccepted { get; set; } = false;
    }
}
