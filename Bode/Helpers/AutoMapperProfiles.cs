using AutoMapper;
using Bode.DTOs;
using Bode.Models;

namespace Bode.Helpers
{
    class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Users
            CreateMap<ProvinceDto, Province>();
            CreateMap<Province, ProvinceDto>();
        }
    }
}
