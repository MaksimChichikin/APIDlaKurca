using Lerkorin.CommonsAppData.DTO;
using Lerkorin.Interface;
using Lerkorin.Models;
using Microsoft.EntityFrameworkCore;

namespace Lerkorin.CommonsAppData.User
{
    public class UsersClass : IUsers
    {
        private readonly _130123_ChichikinContext _context;
        public UsersClass(_130123_ChichikinContext context)
        {
            _context = context;
        }

        public List<UserDTO> FirstOfDefault(string Login, string Password)
        {
            List<UserDTO> data = _context.Users.Include(x=>x.IdRoleNavigation)
                .Select(
                        x => new UserDTO
                        {
                            Login = x.Login,
                            Password = x.Password,
                            Role =x.IdRoleNavigation.Name
                            
                            
                            
                        }
                ).ToList();

            if (data != null)
            {
                return data;
            }
            else
            {
                return new List<UserDTO>() {
                new UserDTO
                {
                    SNP = "строка",
                }
                };
            }
        }

    }
}
