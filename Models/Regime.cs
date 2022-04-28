using System.ComponentModel.DataAnnotations;

namespace Phoenix.Models
{
    public class Regime
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60, ErrorMessage = "O campo nome aceita no máximo {1} caracteres!")]
        public string? Name { get; set; }
    }

}
