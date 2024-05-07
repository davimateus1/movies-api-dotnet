using AutoMapper;
using MoviesAPI.Models;
using MoviesAPI.Data.DTOs;

namespace MoviesAPI.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<Session, ReadSessionDTO>();
            CreateMap<CreateSessionDTO, Session>();
        }
    }
}
