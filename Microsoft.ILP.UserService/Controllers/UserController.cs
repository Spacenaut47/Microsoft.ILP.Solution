using Microsoft.AspNetCore.Mvc;
using Microsoft.ILP.UserService.DTOs;
using Microsoft.ILP.UserService.Models;
using Microsoft.ILP.UserService.Services;

namespace Microsoft.ILP.UserService.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ITokenService _tokenService;

        public UserController(IUserService service, ITokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }



        //public UserController(IUserService service)
        //{
        //    _service = service;
        //}

        [HttpGet]
        public ActionResult<List<UserDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetById(int id)
        {
            var user = _service.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<UserDto> Create(CreateUserDto dto)
        {
            var user = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateUserDto dto)
        {
            var existing = _service.GetById(id);
            if (existing == null) return NotFound();

            _service.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _service.GetById(id);
            if (existing == null) return NotFound();

            _service.Delete(id);
            return NoContent();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _service.Authenticate(dto.Email ?? string.Empty, dto.Password ?? string.Empty);
            if (user == null)
                return Unauthorized("Invalid email or password");

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }

    }
}
