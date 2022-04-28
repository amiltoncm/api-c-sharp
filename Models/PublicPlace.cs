using System.ComponentModel.DataAnnotations;

namespace Phoenix.Models
{
    public class PublicPlace
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "O campo nome aceita no mínimo {1} caracteres!")]
        [MaxLength(20, ErrorMessage = "O campo nome aceita no máximo {1} caracteres!")]
        public string? Name { get; set; }

    }

}
