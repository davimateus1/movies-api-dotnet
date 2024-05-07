using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.DTOs;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController(IMapper mapper, MovieContext context) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly MovieContext _context = context;

        [HttpPost]
        public IActionResult AddAddress([FromBody] CreateAddressDTO addressDTO)
        {
            Address address = _mapper.Map<Address>(addressDTO);
            _context.Addresses.Add(address);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAddressById),
                new { id = address.Id }, address);
        }

        [HttpGet]
        public IEnumerable<ReadAddressDTO> ReadAddresses()
        {
            return _mapper.Map<List<ReadAddressDTO>>(_context.Addresses);
        }

        [HttpGet("{id}")]
        public IActionResult GetAddressById(int id)
        {
            var address = _context.Addresses.FirstOrDefault(x => x.Id == id);

            if(address != null)
            {
                ReadAddressDTO addressDTO = _mapper.Map<ReadAddressDTO>(address);

                return Ok(addressDTO);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAddress (int id, [FromBody] UpdateAddressDTO addressDTO)
        {
            var address = _context.Addresses.FirstOrDefault(x => x.Id == id);

            if(address != null)
            {
                _mapper.Map(addressDTO,address);
                _context.SaveChanges();
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(int id)
        {
            var address = _context.Addresses.FirstOrDefault(x => x.Id == id);

            if(address != null)
            {
                _context.Remove(address);
                _context.SaveChanges();
                return NoContent();
            }

            return NotFound();
        }
    }
}
