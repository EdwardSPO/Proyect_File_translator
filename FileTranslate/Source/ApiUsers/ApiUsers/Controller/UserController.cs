using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApiUsers.Core.UserManager;
using ApiUsers.Data;
using ApiUsers.Models;

namespace ApiUsers.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

 
        public UserController( IUserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var usersResult = await _userManager.GetUsersAsync();
            if (usersResult.Success)
            {
                return Ok(usersResult.Value);
            }
            return NotFound(usersResult.Errors);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var ordenResult = await _userManager.GetByIdAsync(id);
            if (ordenResult.Success)
            {
                return Ok(ordenResult.Value);
            }
            return NotFound(ordenResult.Errors);
        }
        [HttpPost]
        public async Task<ActionResult> Post(User user)
        {
            var result = await _userManager.CreateAsync(user);
            if (result.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<ActionResult> PostLogin(User user)
        {
            var result = await _userManager.LoginAsync(user);
            if (result.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
            }
            return Ok(result.Errors);
        }
    }
}
