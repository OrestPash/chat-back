namespace Entities.Message
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
