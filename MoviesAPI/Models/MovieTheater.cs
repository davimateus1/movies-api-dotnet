using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class MovieTheater
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name field is mandatory.")]
        public required string Name { get; set; }

        public int AddressId { get; set; }

        public virtual required Address Address { get; set; }

        public virtual required ICollection<Session> Sessions { get; set; }
    }
}
