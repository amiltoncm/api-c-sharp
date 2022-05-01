using System.ComponentModel.DataAnnotations;

namespace Phoenix.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O campo nome aceita no mínimo {1} caracteres!")]
        [MaxLength(50, ErrorMessage = "O campo nome aceita no máximo {1} caracteres!")]
        public string? Name { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "O campo nome fantasia aceita no mínimo {1} caracteres!")]
        [MaxLength(50, ErrorMessage = "O campo nome fantasia aceita no máximo {1} caracteres!")]
        public string? FantasyName { get; set; }

        [Required]
        [MinLength(15, ErrorMessage = "O campo Inscrição Estadual aceita no mínimo {1} caracteres!")]
        [MaxLength(15, ErrorMessage = "O campo Inscrição Estadual aceita no máximo {1} caracteres!")]
        public string? Identification { get; set; }

        [Required]
        [MinLength(18, ErrorMessage = "O campo CNPJ aceita no mínimo {1} caracteres!")]
        [MaxLength(18, ErrorMessage = "O campo CNPJ aceita no máximo {1} caracteres!")]
        public string? Document { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "O campo Inscrição Municipal aceita no mínimo {1} caracteres!")]
        [MaxLength(10, ErrorMessage = "O campo Inscrição Municipal aceita no máximo {1} caracteres!")]
        public string? Inscription { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O campo Endereço aceita no mínimo {1} caracteres!")]
        [MaxLength(50, ErrorMessage = "O campo Endereço aceita no máximo {1} caracteres!")]
        public string? Address { get; set; }

        [Required]
        public int Number { get; set; }

        public string? Complement { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O campo bairro aceita no mínimo {1} caracteres!")]
        [MaxLength(30, ErrorMessage = "O campo bairro aceita no máximo {1} caracteres!")]
        public string? Neighborhood { get; set; }

        [Required]
        public int cityId { get; set; }

        public City? City { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "O campo CEP aceita no mínimo {1} caracteres!")]
        [MaxLength(9, ErrorMessage = "O campo CEP aceita no máximo {1} caracteres!")]
        public string? Zip { get; set; }

        [Required]
        [MinLength(9, ErrorMessage = "O campo telefone aceita no mínimo {1} caracteres!")]
        [MaxLength(12, ErrorMessage = "O campo telefone aceita no máximo {1} caracteres!")]
        public string? Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "O valor informado não é um e-mail válido!")]
        [MinLength(7, ErrorMessage = "O campo e-mail aceita no mínimo {1} caracteres!")]
        [MaxLength(50, ErrorMessage = "O campo e-mail aceita no máximo {1} caracteres!")]
        public string? Email { get; set; }

        [DataType(DataType.Url, ErrorMessage = "O valor informado não é um endereço válido!")]
        [MinLength(7, ErrorMessage = "O campo Home-Page aceita no mínimo {1} caracteres!")]
        [MaxLength(50, ErrorMessage = "O campo Home-Page aceita no máximo {1} caracteres!")]
        public string? Homepage { get; set; }

        [Required]
        public int regimeId { get; set; }

        public Regime? Regime { get; set; }

    }

}
