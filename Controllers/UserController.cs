using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using UserManagement.Repository.Interfaces;
using UserManagement.Entities;
using UserManagement.Models;
using System.Security.Cryptography;

namespace UserManagement.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static User user = new User();
        private readonly IUserRepository _repository;
        private readonly ILogger<UserController> _logger;
        private IMapper _mapper;

        public UserController(IUserRepository repository, ILogger<UserController> logger, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpPost]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;
            user.PasswordHash = passwordHash;
            user.Salt = passwordSalt;

            var userData = await _repository.CreateUser(user);

            return CreatedAtRoute("GetUser", new { email = user.Email }, userData);
        }
        [HttpGet("{email:length(100)}", Name = "GetUser")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<User>> GetUser(string email)
        {
            var product = await _repository.GetUser(email);

            if (product == null)
            {
                _logger.LogError($"User with email: {email}, not found.");
                return NotFound();
            }

            return Ok(product);
        }
        [HttpPut]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            return Ok(await _repository.UpdateUser(user));
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())

            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password)
        {

            using (var hmac = new HMACSHA512(user.Salt))
            {
                var ComputedPasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return ComputedPasswordHash.SequenceEqual(user.PasswordHash);
            }

        }

        [HttpDelete("{email:length(100)}", Name = "DeleteUser")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUser(string email)
        {
            return Ok(await _repository.DeleteUser(email));
        }
    }
}