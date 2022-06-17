using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UserContext _context;
        public UsersController(UserContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            IList<User> users;
            users = _context.User.Select(s => new User()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Address = s.Address,
                EmailId = s.EmailId,
                DateOfBirth =Convert.ToDateTime(s.DateOfBirth.ToShortDateString()),
            }).ToList();
            if (users.Count == 0)
            {
                return NoContent();
            }
            return Ok(users);
        }

    }
}
