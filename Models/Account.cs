using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phoenix.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O campo descrição aceita no mínimo {1} caracteres!")]
        [MaxLength(30, ErrorMessage = "O campo descrição aceita no máximo {1} caracteres!")]
        public string? Description { get; set; }

        [Required]
        [ForeignKey("Fk_account_bank")]
        public int BankId { get; set; }

        public Bank? Bank { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public int Cash { get; set; }

    }

}
