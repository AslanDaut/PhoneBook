using PhoneBook.Data;
using PhoneBook.Model;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            return _context.Users.SingleOrDefault(x => x.Name == username && x.Password == password);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }
    }
}
