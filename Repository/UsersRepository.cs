using System.Collections.Generic;
using System.Linq;
using _3DModels.Models;
using Microsoft.EntityFrameworkCore;

namespace _3DModels.Repositories
{
    public class UsersRepository
    {
        private readonly ModelDbContext _context;

        public UsersRepository(ModelDbContext context)
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

        public void UpdateUser(Users user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(Users user)
        {
            _context.users.Remove(user);
            _context.SaveChanges();
        }
    }
}
