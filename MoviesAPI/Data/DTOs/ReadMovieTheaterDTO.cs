using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTOs
{
    public class ReadMovieTheaterDTO
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required ReadAddressDTO Address {  get; set; }

        public required ICollection<ReadSessionDTO> Sessions { get; set; }
    }
}
