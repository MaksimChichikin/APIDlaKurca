using Lerkorin.Models;

namespace Lerkorin.CommonsAppData.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string? Login { get; set; }

        public string? Role { get; set; }
        public string? Activity { get; set; }

        public DateTime DateAdd { get; set; }
        public bool IsFirstLogin { get; set; }

        public string? UserStatus { get; set; }

    }
}
