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

        private UserEntity GetUser(UserEntity user)
        {
            return _context.Users.Where(x => x.Email == user.Email && x.Login == user.Login && x.Password == user.Password
            && x.ClientID == user.ClientID && x.ClientSecret == user.ClientSecret).FirstOrDefault();
        }

        public async Task<IEnumerable<MusicEntity>> GetUserMusic(UserEntity user)
        {
            var userMusics = await Task.Run(() => this._context.UserMusic.Include(x => x.MusicId).Include(x => x.UserId));

            UserEntity newUser = _context.Users.Where(x => x.Email == user.Email && x.Login == user.Login && x.Password == user.Password
            && x.ClientID == user.ClientID && x.ClientSecret == user.ClientSecret).FirstOrDefault();

            List<MusicEntity> res = new List<MusicEntity>();
            foreach (var music in userMusics)
            {
                if (music.UserId == newUser)
                    res.Add(music.MusicId);
            }
            return res;
        }

        public async Task AddUserMusic(UserEntity user, MusicEntity music)
        {
            UserEntity newUser = _context.Users.Where(x => x.Email == user.Email && x.Login == user.Login && x.Password == user.Password
            && x.ClientID == user.ClientID && x.ClientSecret == user.ClientSecret).FirstOrDefault();

            MusicEntity newMusic = _context.Music.Where(x => x.Artists == music.Artists && x.Album == music.Album &&
            x.Duration == music.Duration && x.Name == music.Name && x.Picture == music.Picture).FirstOrDefault();

            newMusic ??= music;

            await _context.UserMusic.AddAsync(new UserMusicEntity() { UserId = newUser, MusicId = newMusic });
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUserMusic(UserEntity user, MusicEntity music)
        {
            UserEntity newUser = _context.Users.Where(x => x.Email == user.Email && x.Login == user.Login && x.Password == user.Password
           && x.ClientID == user.ClientID && x.ClientSecret == user.ClientSecret).FirstOrDefault();

            MusicEntity newMusic = _context.Music.Where(x => x.Artists == music.Artists && x.Album == music.Album &&
            x.Duration == music.Duration && x.Name == music.Name && x.Picture == music.Picture).FirstOrDefault();

            UserMusicEntity userMusicEntity = _context.UserMusic.Where(x => x.MusicId == newMusic && x.UserId == newUser).FirstOrDefault();
            
            _context.UserMusic.Remove(userMusicEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AlbumEntity>> GetUserAlbum(UserEntity user)
        {
            var userAlbum = await Task.Run(() => this._context.UserAlbums.Include(x => x.AlbumId).Include(x => x.UserId));

            UserEntity newUser = GetUser(user);

            List<AlbumEntity> res = new List<AlbumEntity>();
            foreach (var music in userAlbum)
            {
                if (music.UserId == newUser)
                    res.Add(music.AlbumId);
            }
            return res;
        }

        public async Task AddUserAlbum(UserEntity user, AlbumEntity album)
        {
            UserEntity newUser = GetUser(user);

            AlbumEntity newAlbum = _context.Albums.Where(x => x.Artist == album.Artist && x.Name == album.Name &&
            x.ReleaseDate == album.ReleaseDate && x.TotalTracks == album.TotalTracks && x.Picture == album.Picture).FirstOrDefault();

            newAlbum ??= album;

            await _context.UserAlbums.AddAsync(new UserAlbumEntity() { UserId = newUser, AlbumId = newAlbum });
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUserAlbum(UserEntity user, AlbumEntity album)
        {
            UserEntity newUser = GetUser(user);

            AlbumEntity newAlbum = _context.Albums.Where(x => x.Artist == album.Artist && x.Name == album.Name &&
            x.ReleaseDate == album.ReleaseDate && x.TotalTracks == album.TotalTracks && x.Picture == album.Picture).FirstOrDefault();

            UserAlbumEntity userAlbumEntity = _context.UserAlbums.Where(x => x.AlbumId == newAlbum && x.UserId == newUser).FirstOrDefault();

            _context.UserAlbums.Remove(userAlbumEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ArtistEntity>> GetUserArtist(UserEntity user)
        {
            var userArtist = await Task.Run(() => this._context.UserArtists.Include(x => x.ArtistId).Include(x => x.UserId));

            UserEntity newUser = GetUser(user);

            List<ArtistEntity> res = new List<ArtistEntity>();
            foreach (var artist in userArtist)
            {
                if (artist.UserId == newUser)
                    res.Add(artist.ArtistId);
            }
            return res;
        }

        public async Task AddUserArtist(UserEntity user, ArtistEntity artist)
        {
            UserEntity newUser = GetUser(user);

            ArtistEntity newArtist = _context.Artists.Where(x => x.Name == artist.Name && x.ListGenres == artist.ListGenres &&
            x.NumberSubscribers == artist.NumberSubscribers && x.Picture == artist.Picture).FirstOrDefault();

            newArtist ??= artist;

            await _context.UserArtists.AddAsync(new UserArtistEntity() { UserId = newUser, ArtistId = newArtist });
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUserArtist(UserEntity user, ArtistEntity artist)
        {
            UserEntity newUser = GetUser(user);

            ArtistEntity newArtist = _context.Artists.Where(x => x.Name == artist.Name && x.ListGenres == artist.ListGenres &&
            x.NumberSubscribers == artist.NumberSubscribers && x.Picture == artist.Picture).FirstOrDefault();

            UserArtistEntity userArtistEntity = _context.UserArtists.Where(x => x.ArtistId == newArtist && x.UserId == newUser).FirstOrDefault();

            _context.UserArtists.Remove(userArtistEntity);
            await _context.SaveChangesAsync();
        }
    }
}
