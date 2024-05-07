using AutoMapper;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController(MovieContext context, IMapper mapper) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly MovieContext _context = context;

        [HttpPost]
        public IActionResult AddSession (CreateSessionDTO sessionDTO)
        {
            Session session = _mapper.Map<Session>(sessionDTO);

            _context.Sessions.Add(session);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSessionById), 
                new { movieId = session.MovieId, 
                    movieTheaterId = session.MovieTheaterId }, session);
        }

        [HttpGet]
        public IEnumerable<ReadSessionDTO> GetSessions()
        {
            return _mapper.Map<List<ReadSessionDTO>>(_context.Sessions.ToList());
        }

        [HttpGet("{movieId}/{movieTheaterId}")]
        public IActionResult GetSessionById(int movieId, int movieTheaterId)
        {
            var session = _context.Sessions.FirstOrDefault(x => x.MovieId == movieId
                && x.MovieTheaterId == movieTheaterId);

            if(session != null) { 
                ReadSessionDTO sessionDTO = _mapper.Map<ReadSessionDTO>(session);
                return Ok(sessionDTO);
            }

            return NotFound();
        }
    }
}
