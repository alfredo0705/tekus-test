using AutoMapper;
using Tekus.Application.DTOs.Providers;
using Tekus.Application.DTOs.Services;
using Tekus.Domain.Entities;

namespace Tekus.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Provider, ProviderDto>().ReverseMap();
            CreateMap<Service, ServiceDto>().ReverseMap();
        }
    }
}
