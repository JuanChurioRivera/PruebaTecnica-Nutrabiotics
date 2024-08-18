using PruebaTenicaTodos.Data;
using PruebaTenicaTodos.Interface;
using PruebaTenicaTodos.Models;

namespace PruebaTenicaTodos.Repository
{
    public class TodoRepository : TodoInterface
    {
        private readonly DataContext _context;
      
        

        public TodoRepository(DataContext data)
        {
            _context = data;
            
        }

        public ICollection<Todo> GetAllTodos() {
        
            return _context.Todos.OrderBy(t => t.Id).ToList();
        
        }

        public Todo GetTodoById(int id) {

            return _context.Todos.Where(t => t.Id == id).FirstOrDefault();
        }

        public User GetUser(int id) { 
        
            return _context.Users.Where(u => u.Todos.Any(t => t.Id == id)).FirstOrDefault();

        }

        public bool CreateTodo(Todo todo) {

            

             _context.Todos.Add(todo);

            return Save();

        }

        public bool UpdateTodo(Todo todo )
        {
            
            _context.Update(todo);
            return Save();

        }

        public bool DeleteTodo(Todo todo)
        {
            _context.Todos.Remove(todo);
            return Save();
        }

        public bool Save()
        {

            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
