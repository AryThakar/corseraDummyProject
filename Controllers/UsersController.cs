using Microsoft.AspNetCore.Mvc;
using MyUserApi.Models;

namespace MyUserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "Admin User", Email = "admin@api.com", Age = 25 }
        };

        [HttpGet]
        public IActionResult GetAll() => Ok(_users);

        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
            return CreatedAtAction(nameof(GetAll), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User updatedUser)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Age = updatedUser.Age;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            _users.Remove(user);
            return NoContent();
        }
    }
}
