using AutoMapper;
using BLL.Interfaces;
using BLL.Mapper;
using BLL.ModelDTO;
using DAL.Data.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SpotifyService: ISpotifyService
    {
        private SpotifyRepository _repository;
        private IMapper _mapper;

        public SpotifyService()
        {
            _repository = new SpotifyRepository();

            var config = new MapperConfiguration(con => { con.AddProfile<MappingProfile>(); });
            _mapper = config.CreateMapper();
        }

        public async Task AddUser(UserDTO user)
        {
            await _repository.AddUser(_mapper.Map<UserEntity>(user));
        }

        public async Task<IEnumerable<UserDTO>> GetAllUser()
        {
            return (await _repository.GetAllUsers()).Select(x => _mapper.Map<UserDTO>(x)).ToList();
        }

        public async Task<UserDTO> LoginAccount(string login, string password)
        {
            List<UserDTO> users = (await _repository.GetAllUsers()).Select(x => _mapper.Map<UserDTO>(x)).ToList();

            foreach (var user in users)
            {
                if ((user.Login == login && user.Password == password) || (user.Email == login && user.Password == password))
                    return user;
            }
            return null;
        }

        public async Task<bool> IsAvailableEmail(string email)
        {
            List<UserDTO> users = (await _repository.GetAllUsers()).Select(x => _mapper.Map<UserDTO>(x)).ToList();

            foreach (var user in users)
            {
                if (user.Email == email)
                    return false;
            }
            return true;
        }
        public async Task<bool> IsAvailableLogin(string login)
        {
            List<UserDTO> users = (await _repository.GetAllUsers()).Select(x => _mapper.Map<UserDTO>(x)).ToList();

            foreach (var user in users)
            {
                if (user.Login == login)
                    return false;
            }
            return true;
        }
    }
}
