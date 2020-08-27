using Commands.DTOs;
using Commands.Models;
using AutoMapper;

namespace Commands.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
            CreateMap<Platform, PlatformUpdateDto>();
            CreateMap<PlatformUpdateDto, Platform>();
        }
    }
}