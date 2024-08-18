using PruebaTenicaTodos.Data;
using PruebaTenicaTodos.Models;
using PruebaTenicaTodos.Interface;

namespace PruebaTenicaTodos.Repository
{

    public class UserRepository : UserInterface
    {
        private readonly DataContext _context;
        

        public UserRepository(DataContext context)
        {
            _context = context;
            
        }

        public ICollection<User> GetAllUsers() {

            return _context.Users.OrderBy(u => u.Id).ToList();

        }

        public User GetUserById(int id) {

            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public ICollection<User> GetUserByRole(string role) { 
        
            return _context.Users.Where(u => u.role == role).ToList();
        
        }

        public ICollection<Todo> GetTodosFromUser(int id)
        {
           
            return _context.Todos.Where(u => u.user.Id == id).ToList();

        }


        public bool DeleteUser(User user) {

            
            _context.Users.Remove(user);
            return Save();

        }

        public bool CreateUser(User user) {

            _context.Users.Add(user);
            return Save();
        }

        public bool UpdateUser(User user) {
        
            _context.Users.Update(user);
            return Save();
        
        }

       


        public bool Save() { 
        
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
