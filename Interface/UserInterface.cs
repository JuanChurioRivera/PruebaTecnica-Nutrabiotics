using PruebaTenicaTodos.Models;

namespace PruebaTenicaTodos.Interface
{
    public interface UserInterface
    {
        public ICollection<User> GetAllUsers();
        public User GetUserById(int id);
        public ICollection<User> GetUserByRole(string role);
        public ICollection<Todo> GetTodosFromUser(int id);
        public bool UserExist(int id);
        public bool CreateUser(User user);
        public bool DeleteUser(int id);
        public bool UpdateUser(User user);
       
        public bool Save();
        
    }
}
