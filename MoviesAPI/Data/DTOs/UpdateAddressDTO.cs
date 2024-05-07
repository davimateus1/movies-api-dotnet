using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTOs
{
    public class UpdateAddressDTO
    {
        public string PublicPlace { get; set; }
        public int Number { get; set; }
    }
}
