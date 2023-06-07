using Lerkorin.CommonsAppData.DTO;
using Lerkorin.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lerkorin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _users;

        public UsersController(IUsers users)
        {
            _users = users;
        }

        [HttpGet]
        public ActionResult<List<UserDTO>> Get(string UserLogin, string UserPassword)
        {
            List<UserDTO> result = _users.FirstOfDefault(UserLogin, UserPassword);

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized(); // Возвращаем статус 401 (Unauthorized)
            }
        }
    }
}
