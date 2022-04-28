using System.ComponentModel.DataAnnotations;

namespace Phoenix.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string FantasyName { get; set; }

        public string Identification { get; set; }

        public string Document { get; set; }

        public string Inscription { get; set; }

        public  int DomPublicPlaceId { get; set; }
        
        public PublicPlace PublicPlace { get; set; }



    }
}
