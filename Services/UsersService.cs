using System.Collections.Generic;
using System.Linq;
using _3DModels.Models;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace _3DModels.Services
{
    public class UsersService
    {
        private readonly ModelDbContext _context;

        public UsersService(ModelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _context.users.ToList();
        }

        public Users GetUserById(int id)
        {
            return _context.users.Find(id);
        }

        public void AddUser(Users user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(int id, Users user)
        {
            if (id != user.user_id)
            {
                throw new ArgumentException("Invalid User ID.");
            }

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.users.Find(id);
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            _context.users.Remove(user);
            _context.SaveChanges();
        }
    }
}
