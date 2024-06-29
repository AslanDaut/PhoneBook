using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Dto;
using PhoneBook.Interfaces;
using PhoneBook.Model;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var country = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }
        [HttpGet("{countId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int countId)
        {
            if (!_countryRepository.CountryExists(countId))
                return NotFound();

            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(countId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("{CountId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        
        public IActionResult GetCountryRating(int CountId)
        {
            if(!_countryRepository.CountryExists(CountId))
                return NotFound();

            var rating = _countryRepository.GetCountryRating(CountId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(rating);
        }
    }
}
