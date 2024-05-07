using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTOs
{
    public class ReadMovieDTO
    {
        public required string Title { get; set; }
        
        public required string Gender { get; set; }
        
        public int Duration { get; set; }
        
        public required string Creator { get; set; }
        
        public DateTime QueryHour { get; set; } = DateTime.Now;

        public required ICollection<ReadSessionDTO> Sessions { get; set; }
    }
}
