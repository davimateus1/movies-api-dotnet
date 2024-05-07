using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTOs
{
    public class UpdateMovieTheaterDTO
    {
        [Required(ErrorMessage = "The name field is mandatory.")]
        public required string Name { get; set; }
    }
}
