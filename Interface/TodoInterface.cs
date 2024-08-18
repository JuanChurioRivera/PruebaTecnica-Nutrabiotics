using PruebaTenicaTodos.Models;

namespace PruebaTenicaTodos.Interface
{
    public interface TodoInterface
    {
        public ICollection<Todo> GetAllTodos();
        public Todo GetTodoById(int id);
        public User GetUser(int id);
        public bool CreateTodo(Todo todo);
        public bool UpdateTodo(Todo todo);
        public bool DeleteTodo(Todo todo);
        public bool Save();

    }
}
