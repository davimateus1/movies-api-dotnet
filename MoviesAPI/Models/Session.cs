using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Session
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int? MovieId { get; set; }

        public virtual required Movie Movie { get; set; }

        public int? MovieTheaterId { get; set; }

        public virtual required MovieTheater MovieTheater { get; set; }
    }
}
