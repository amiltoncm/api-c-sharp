using System.ComponentModel.DataAnnotations;

namespace Phoenix.Models
{
    public class PersonType
    {
        private string id;

        [Key]
        public string Id { get => id; set => id = value; }

        [Required]
        [MaxLength(1, ErrorMessage = "O campo nome aceita no máximo {1} caracteres!")]
        public string? Name { get; set; }

    }

}
