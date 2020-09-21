using System;

namespace Chat.API.Models.Message
{
    public class MessageVM
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
