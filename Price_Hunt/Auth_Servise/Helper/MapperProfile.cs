using Auth_Servise.Dto;
using Auth_Servise.Model;
using Profile = AutoMapper.Profile;

namespace Auth_Servise.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserRegestryDto>().ReverseMap();
        }
    }
}
