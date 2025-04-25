using System.ComponentModel.DataAnnotations;

namespace EmailApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress(ErrorMessage = "Некорректный Email")]
        [StringLength(32, MinimumLength = 6, ErrorMessage = "Длина Email должна быть от 6 до 50 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(32, MinimumLength = 6, ErrorMessage = "Длина пароля должна быть от 6 до 32 символов")]
        public string Password { get; set; }
    }
}
