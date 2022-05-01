using System.ComponentModel.DataAnnotations;

namespace Phoenix.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "O campo nome aceita no mínimo {1} caracteres!")]
        [MaxLength(50, ErrorMessage = "O campo nome aceita no máximo {1} caracteres!")]
        public string? Name { get; set; }

        [Required]
        public int stateId { get; set; }

        public State? State { get; set; }

        [MinLength(8, ErrorMessage = "O campo Cep padrão aceita no mínimo {1} caracteres!")]
        [MaxLength(9, ErrorMessage = "O campo Cep padrão aceita no máximo {1} caracteres!")]
        public string? defaultZip { get; set; }

    }

}
