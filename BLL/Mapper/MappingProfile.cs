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
        }
    }
}
