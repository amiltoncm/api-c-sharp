using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phoenix.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "O campo nome aceita no mínimo {1} caracteres!")]
        [MaxLength(20, ErrorMessage = "O campo nome aceita no máximo {1} caracteres!")]
        public string? Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "O campo sigla aceita no mínimo {1} caracteres!")]
        [MaxLength(2, ErrorMessage = "O campo sigla aceita no máximo {1} caracteres!")]
        public string? Acronym { get; set; }

        [Required]
        [ForeignKey("Fk_state_country")]
        public int CountryId { get; set; }

        public Country? Country { get; set; }

        public double InternalTax { get; set; }

    }

}
