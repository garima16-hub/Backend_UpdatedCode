using _3DModels.Models;
using _3DModels.Services;
using BCrypt.Net;

public class UserRegistrationService
{
    private readonly ModelDbContext _dbContext;
    private readonly PasswordHashingService _passwordHashingService;

    public UserRegistrationService(ModelDbContext dbContext, PasswordHashingService passwordHashingService)
    {
        _dbContext = dbContext;
        _passwordHashingService = passwordHashingService;
    }

    public void RegisterUser(string username, string pass, string email, string city, string gender, string phoneNumber)
    {
        // Hash the password
        string hashedPassword = _passwordHashingService.HashPassword(pass);

        // Create a new Users instance with hashed password
        var newUser = new Users
        {
            username = username,
            pass = hashedPassword,
            Email = email,
            City = city,
            Gender = gender,
            Phonenumber = phoneNumber
        };

        // Store the new user in the database
        _dbContext.users.Add(newUser);
        _dbContext.SaveChanges();
    }
    public bool AuthenticateUser(string username, string pass)
    {
        // Retrieve the stored hashed password from the database based on 'username'
        string hashedPasswordFromDb = "..."; // Get from the database

        // Use the 'VerifyPassword' method to compare the hashed passwords for authentication
        return _passwordHashingService.VerifyPassword(pass, hashedPasswordFromDb);
    }
}
