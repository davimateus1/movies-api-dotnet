using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTOs
{
    public class CreateMovieTheaterDTO
    {
        [Required(ErrorMessage = "The name field is mandatory.")]
        public required string Name { get; set; }

        public int AddressId { get; set; }
    }
}
