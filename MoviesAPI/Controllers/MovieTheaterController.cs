using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Data.DTOs;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieTheaterController(MovieContext context, IMapper mapper) : ControllerBase
    {
        private readonly MovieContext _context = context;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public IActionResult AddMovieTheater([FromBody] CreateMovieTheaterDTO movieTheaterDto)
        {
            MovieTheater? movieTheater = _mapper.Map<MovieTheater>(movieTheaterDto);
            _context.MovieTheaters.Add(movieTheater);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMovieTheaterById), new { movieTheater.Id }, movieTheaterDto);
        }

        [HttpGet]
        public IEnumerable<ReadMovieTheaterDTO> GetMovieTheaters([FromQuery] int? addressId = null)
        {
            if (addressId == null)
            {
                return _mapper.Map<List<ReadMovieTheaterDTO>>
                    (_context.MovieTheaters.ToList());
            }

            return _mapper.Map<List<ReadMovieTheaterDTO>>
                (_context.MovieTheaters
                .FromSql($"SELECT ID, NAME, ADDRESSID FROM MOVIETHEATERS WHERE ADDRESSID = {addressId}")
                .ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieTheaterById(int id)
        {
            MovieTheater? movieTheater = _context.MovieTheaters.FirstOrDefault(x => x.Id == id);

            if(movieTheater != null)
            {
                ReadMovieTheaterDTO readMovieTheaterDTO = _mapper.Map<ReadMovieTheaterDTO>(movieTheater);
                return Ok(readMovieTheaterDTO);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovieTheater(int id, [FromBody] UpdateMovieDTO movieTheaterDto)
        {
            MovieTheater? movieTheater = _context.MovieTheaters.FirstOrDefault(x => x.Id == id);

            if(movieTheater != null)
            {
                _mapper.Map(movieTheaterDto, movieTheater);
                _context.SaveChanges();
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovieTheater(int id)
        {
            MovieTheater? movieTheater = _context.MovieTheaters.FirstOrDefault(x => x.Id == id);

            if( movieTheater != null )
            {
                _context.Remove(movieTheater);
                _context.SaveChanges();
                return NoContent();
            }

            return NotFound();
        }

    }
}
