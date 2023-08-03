using System.Security.Cryptography;
using System.Text;

public class PasswordHashingService
{
    public string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        string hashedInput = HashPassword(password);
        return hashedInput == hashedPassword;
    }
}
