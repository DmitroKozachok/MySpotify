using AutoMapper;
using BLL.ModelDTO;
using DAL.Data.Entities;

namespace BLL.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<UserEntity, UserDTO>();
            CreateMap<UserDTO, UserEntity>();

            CreateMap<MusicEntity, MusicDTO>();
            CreateMap<MusicDTO, MusicEntity>();

            CreateMap<ArtistEntity, ArtistDTO>();
            CreateMap<ArtistDTO, ArtistEntity>();

            CreateMap<AlbumEntity, AlbumDTO>();
            CreateMap<AlbumDTO, AlbumEntity>();
        }
    }
}
