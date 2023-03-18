using AutoMapper;
using MusicManager.API.DTOs;
using MusicManager.Application.Models;
using MusicManager.Domain.Entities;

namespace MusicManager.API.Mapper
{
    /// <summary>
    /// Mapping profile between DTOs and Domain Entities, DTOs and ResponseModels
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // DTOS and Domain Entities
            CreateMap<CreateArtistDTO, Artist>();
            CreateMap<UpdateArtistDTO, Artist>();
            CreateMap<GenreDTO, Genre>();
            CreateMap<CreateSongDTO, Song>();
            CreateMap<UpdateSongDTO, Song>();
            CreateMap<CreateAlbumDTO, Album>();
            CreateMap<UpdateAlbumDTO, Album>();
            CreateMap<ArtistDTO, Artist>();
            CreateMap<AlbumDTO, Album>();


            // Domain Entities and ResponseModel
            CreateMap<Song, GetSongResponseModel>()
                .ForMember(dest => dest.Artists, opt => opt.MapFrom(src => src.Artists.Select(c => new ArtistResponseModel { Id = c.Id, Name = c.Name }).ToList()))
                .ForMember(dest => dest.Albums, opt => opt.MapFrom(src => src.Albums.Select(c => new AlbumResponseModel { Id = c.Id, Name = c.Name }).ToList()))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(c => new GenreResponseModel { Id = c.Id, Name = c.Name }).ToList()));

            CreateMap<Artist, GetArtistResponseModel>()
                .ForMember(dest => dest.Albums, opt => opt.MapFrom(src => src.Albums.Select(c => new AlbumResponseModel { Id = c.Id, Name = c.Name }).ToList()))
                .ForMember(dest => dest.Songs, opt => opt.MapFrom(src => src.Songs.Select(c => new SongResponseModel { Id = c.Id, Name = c.Name }).ToList()));

            CreateMap<Album, GetAlbumResponseModel>()
               .ForMember(dest => dest.Artists, opt => opt.MapFrom(src => src.Artists.Select(c => new ArtistResponseModel { Id = c.Id, Name = c.Name }).ToList()))
               .ForMember(dest => dest.Songs, opt => opt.MapFrom(src => src.Songs.Select(c => new SongResponseModel { Id = c.Id, Name = c.Name }).ToList()))
               .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(c => new GenreResponseModel { Id = c.Id, Name = c.Name }).ToList()));

            CreateMap<Artist, ArtistResponseModel>();
            CreateMap<Album, AlbumResponseModel>();
            CreateMap<Genre, GenreResponseModel>();
            CreateMap<Song, SongResponseModel>();
        }
    }
}
