using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Interfaces;
using PhoneBook.Model;
using System.Threading.Tasks;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (_userRepository.UserExists(user.Id))
            {
                ModelState.AddModelError("", "User already exists");
                return StatusCode(409, ModelState);
            }

            if (!_userRepository.CreateUser(user))
            {
                ModelState.AddModelError("", "Something went wrong while saving the user");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
    }
}
