using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTOs
{
    public class ReadAddressDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The public place field is mandatory.")]
        public required string PublicPlace { get; set; }

        [Required(ErrorMessage = "The number place field is mandatory.")]
        public int Number { get; set; }
    }
}
