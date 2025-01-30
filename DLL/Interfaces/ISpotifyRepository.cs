using DAL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISpotifyRepository
    {
        Task<IEnumerable<UserEntity>> GetAllUsers();
        Task AddUser(UserEntity user);
    }
}
