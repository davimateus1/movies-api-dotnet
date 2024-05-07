using AutoMapper;
using MoviesAPI.Data.DTOs;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class MovieTheaterProfile : Profile
    {
        public MovieTheaterProfile()
        {
            CreateMap<CreateMovieTheaterDTO, MovieTheater>();
            CreateMap<MovieTheater, ReadMovieTheaterDTO>()
                .ForMember(movieTheaterDTO => movieTheaterDTO.Address,
                    opt => opt.MapFrom(movieTheater => movieTheater.Address))
                .ForMember(movieTheaterDTO => movieTheaterDTO.Sessions,
                    opt => opt.MapFrom(movieTheater => movieTheater.Sessions));
            CreateMap<UpdateMovieTheaterDTO, MovieTheater>();
        }
    }
}
