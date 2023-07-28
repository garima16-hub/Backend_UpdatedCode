using Microsoft.AspNetCore.Mvc;
using _3DModels.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UserRegistrationController : ControllerBase
{
    private readonly UserRegistrationService _userRegistrationService;
    private readonly ModelDbContext _context;

    public UserRegistrationController(UserRegistrationService userRegistrationService, ModelDbContext context)
    {
        _userRegistrationService = userRegistrationService;
        _context = context;
    }

    // POST: api/UserRegistration/Register
    [HttpPost("Register")]
    public IActionResult Register([FromBody] UserRegistrationModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid registration data.");
        }

        // Call the UserRegistrationService to register the new user
        _userRegistrationService.RegisterUser(model.Username, model.Pass, model.Email, model.City, model.Gender, model.Phonenumber);

        // Redirect to a success page or return a success message
        return Ok("User registration successful!");
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


    // PUT: api/Users/5
    [HttpPut("{id}")]
    public IActionResult PutUsers(int id, Users user)
    {
        if (id != user.user_id)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
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






