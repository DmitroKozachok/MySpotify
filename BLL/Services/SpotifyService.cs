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

        public async Task<IEnumerable<MusicDTO>> GetUserMusic(UserDTO user)
        {
            return (await _repository.GetUserMusic(_mapper.Map<UserEntity>(user))).Select(x => _mapper.Map<MusicDTO>(x)).ToList();
        }

        public async Task AddUserMusic(UserDTO user, MusicDTO music)
        {
            await _repository.AddUserMusic(_mapper.Map<UserEntity>(user), _mapper.Map<MusicEntity>(music));
        }

        public async Task RemoveUserMusic(UserDTO user, MusicDTO music)
        {
            await _repository.RemoveUserMusic(_mapper.Map<UserEntity>(user), _mapper.Map<MusicEntity>(music));
        }

        public async Task<IEnumerable<AlbumDTO>> GetUserAlbum(UserDTO user)
        {
            return (await _repository.GetUserAlbum(_mapper.Map<UserEntity>(user))).Select(x => _mapper.Map<AlbumDTO>(x)).ToList();
        }

        public async Task AddUserAlbum(UserDTO user, AlbumDTO album)
        {
            await _repository.AddUserAlbum(_mapper.Map<UserEntity>(user), _mapper.Map<AlbumEntity>(album));
        }

        public async Task RemoveUserAlbum(UserDTO user, AlbumDTO album)
        {
            await _repository.RemoveUserAlbum(_mapper.Map<UserEntity>(user), _mapper.Map<AlbumEntity>(album));
        }

        public async Task<IEnumerable<ArtistDTO>> GetUserArtist(UserDTO user)
        {
            return (await _repository.GetUserArtist(_mapper.Map<UserEntity>(user))).Select(x => _mapper.Map<ArtistDTO>(x)).ToList();
        }

        public async Task AddUserArtist(UserDTO user, ArtistDTO artist)
        {
            await _repository.AddUserArtist(_mapper.Map<UserEntity>(user), _mapper.Map<ArtistEntity>(artist));
        }

        public async Task RemoveUserArtist(UserDTO user, ArtistDTO music)
        {
            await _repository.RemoveUserArtist(_mapper.Map<UserEntity>(user), _mapper.Map<ArtistEntity>(music));
        }
    }
}
