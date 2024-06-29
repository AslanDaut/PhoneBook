using PhoneBook.Data;
using PhoneBook.Interfaces;
using PhoneBook.Model;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(u => u.Id).ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        public bool CreateUser(User user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
