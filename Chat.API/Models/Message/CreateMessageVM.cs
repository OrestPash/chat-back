using System.ComponentModel.DataAnnotations;

namespace Chat.API.Models.Message
{
    public class CreateMessageVM
    {
        [Required]
        public string Text { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
