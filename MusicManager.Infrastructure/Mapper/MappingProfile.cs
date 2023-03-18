using AutoMapper;
using MusicManager.Domain.DTOs;
using MusicManager.Domain.Entities;

namespace MusicManager.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Artist, CreateArtistDTO>().ReverseMap();
        }
    }
}
