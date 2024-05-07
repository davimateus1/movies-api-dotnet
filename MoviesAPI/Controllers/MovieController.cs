using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController(MovieContext context, IMapper mapper) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly MovieContext _context = context;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddMovie([FromBody] CreateMovieDTO movieDTO)
        {
            Movie movie = _mapper.Map<Movie>(movieDTO);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMovieById),
                new { id = movie.Id }, 
                movie);
        }

        [HttpGet]
        public IEnumerable<ReadMovieDTO> GetMovies(
            [FromQuery] int take = 10,
            [FromQuery] int skip = 0,
            [FromQuery] string? movieTheaterName = null)
        {
            if(movieTheaterName == null)
            {
                return _mapper.Map<List<ReadMovieDTO>>(
                _context.Movies.Skip(skip).Take(take).ToList());
            }

            return _mapper.Map<List<ReadMovieDTO>>(
                _context.Movies
                .Skip(skip)
                .Take(take)
                .Where(movie => movie.Sessions.Any(
                    session => session.MovieTheater.Name == movieTheaterName))
                .ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
           var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

           if (movie == null) return NotFound();

           var movieDTO = _mapper.Map<ReadMovieDTO>(movie);

           return Ok(movieDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDTO movieDTO)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie == null) return NotFound();

            _mapper.Map(movieDTO, movie);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdatePartialMovie(int id, 
            JsonPatchDocument<UpdateMovieDTO> patchMovie)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            var movieToUpdate = _mapper.Map<UpdateMovieDTO>(movie);

             patchMovie.ApplyTo(movieToUpdate, ModelState);

            if (!TryValidateModel(movieToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(movieToUpdate, movie);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            
            if (movie == null) return NotFound();

            _context.Remove(movie);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
