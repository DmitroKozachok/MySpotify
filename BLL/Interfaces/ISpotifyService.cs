using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISpotifyService
    {
        Task<IEnumerable<UserDTO>> GetAllUser();
        Task AddUser(UserDTO user);

        Task<UserDTO> LoginAccount(string login, string password);
        Task<bool> IsAvailableEmail(string email);
        Task<bool> IsAvailableLogin(string login);
    }
}
