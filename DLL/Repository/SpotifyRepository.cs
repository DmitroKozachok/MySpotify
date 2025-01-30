using DAL.Data;
using DAL.Data.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SpotifyRepository : ISpotifyRepository
    {
        private SpotifyDbContext _context;

        public SpotifyRepository()
        {
            _context = new SpotifyDbContext();
        }

        public async Task AddUser(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsers()
        {
            return await Task.Run(() => this._context.Users);
        }
    }
}
