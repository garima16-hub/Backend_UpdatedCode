using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using _3DModels.Models;
using Microsoft.EntityFrameworkCore;

namespace _3DModels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ModelDbContext _context;

        public UsersController(ModelDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            return _context.users.ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<Users> GetUsers(int id)
        {
            var user = _context.users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

       

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public ActionResult<Users> DeleteUsers(int id)
        {
            var user = _context.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.users.Remove(user);
            _context.SaveChanges();

            return user;
        }
    }
}

