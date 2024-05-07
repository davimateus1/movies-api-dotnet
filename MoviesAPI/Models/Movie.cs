using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "The movie title is required")]
        [StringLength(255, ErrorMessage = "The movie title length cannot be greater than 255")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "The movie gender is required")]
        [MaxLength(50, ErrorMessage = "The movie gender length cannot be greater than 50")]
        public required string Gender  { get; set; }

        [Required(ErrorMessage = "The movie duration is required")]
        [Range(70, 600, ErrorMessage = "The movie durantion must be between 70 and 600")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "The movie creator is required")]
        public required string Creator { get; set; }

        public virtual required ICollection<Session> Sessions { get; set; }
    }
}
