using Lerkorin.CommonsAppData.DTO;

namespace Lerkorin.Interface
{
    public interface IUsers
    {
        public List<UserDTO> FirstOfDefault(string UserLogin, string UserPassword);
    }
}
