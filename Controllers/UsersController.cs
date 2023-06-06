using Lerkorin.CommonsAppData.DTO;
using Lerkorin.Interface;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<List<UserDTO>>> Get(string UserLogin, string UserPassword) => await Task.FromResult(_users.FirstOfDefault(UserLogin, UserPassword));
}
}
