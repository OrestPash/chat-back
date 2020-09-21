using System.ComponentModel.DataAnnotations;

namespace Chat.API.Models.Message
{
    public class UpdateMessageVM
    {
        [Required]
        public string Text { get; set; }
    }
}
