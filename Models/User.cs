using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phoenix.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O campo nome aceita no mínimo {1} caracteres!")]
        [MaxLength(20, ErrorMessage = "O campo nome aceita no máximo {1} caracteres!")]
        public string? Name { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O campo senha aceita no mínimo {1} caracteres!")]
        [MaxLength(50, ErrorMessage = "O campo senha aceita no máximo {1} caracteres!")]
        public string? Password { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(60, ErrorMessage = "O campo e-mail aceita no máximo {1} caracteres!")]
        public string? Email { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        [ForeignKey("Fk_user_userProfile")]
        public int UsersProfileId { get; set; }

        public UsersProfile? UsersProfile { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

    }

}
