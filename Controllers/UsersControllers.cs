using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // In-memory list to simulate database
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
            new User { Id = 2, Name = "Bob", Email = "bob@example.com" }
        };

        // GET: api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(users);
        }

        // GET: api/users/1
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound($"User with ID {id} not found.");
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            newUser.Id = users.Max(u => u.Id) + 1;
            users.Add(newUser);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }

        // PUT: api/users/1
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
                return NotFound($"User with ID {id} not found.");

            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;

            return NoContent(); // 204 No Content
        }

        // DELETE: api/users/1
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound($"User with ID {id} not found.");

            users.Remove(user);
            return NoContent();
        }
    }

    // User model
    public class User
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.EmailAddress]
        public string Email { get; set; }
    }
}
