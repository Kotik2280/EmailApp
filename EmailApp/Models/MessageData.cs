using System.ComponentModel.DataAnnotations;

namespace EmailApp.Models
{
    public class MessageData
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Не указано сообщение")]
        [StringLength(200, ErrorMessage = "Слишком длинное сообщение")]
        public string Message { get; set; }
        public string SenderEmail { get; set; }
        [Required(ErrorMessage = "Не указан получатель сообщения")]
        public string ReceiverEmail { get; set; }
    }
}
