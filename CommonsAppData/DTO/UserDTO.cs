using Lerkorin.Models;

namespace Lerkorin.CommonsAppData.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string? Login { get; set; }
        public string? Password { get; set; }
        public string ? Role { get; set; }
        public string? SNP { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumberOfLoginAttempts { get; set; }
        public DateTime DateAdd { get; set; }
     
    }
}
