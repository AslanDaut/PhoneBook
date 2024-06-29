using PhoneBook.Model;
using System.Collections.Generic;

namespace PhoneBook.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        bool UserExists(int id);
        bool CreateUser(User user);
        bool Save();
    }
}
