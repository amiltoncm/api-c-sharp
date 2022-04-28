using System.ComponentModel.DataAnnotations;

namespace Phoenix.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O campo nome aceita no mínimo {1} caracteres!")]
        [MaxLength(20, ErrorMessage = "O campo nome aceita no máximo {1} caracteres!")]

        public string? Name { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "O campo Alpha3 aceita no mínimo {1} caracteres!")]
        [MaxLength(3, ErrorMessage = "O campo Alpha3 aceita no máximo {1} caracteres!")]
        public string? Alpha3 { get; set; }

    }

}
