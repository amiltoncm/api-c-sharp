using System.ComponentModel.DataAnnotations;

namespace Phoenix.Models
{
    public class UsersProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O campo descrição aceita no mínimo {1} caracteres!")]
        [MaxLength(20, ErrorMessage = "O campo descrição aceita no máximo {1} caracteres!")]
        public string? Description { get; set; }
    }

}
