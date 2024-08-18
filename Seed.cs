using PruebaTenicaTodos.Data;
using PruebaTenicaTodos.Models;


namespace PokemonReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            var Users = new List<User>()
            {
                new User() {

                    name = "admin",
                    password = "1234",
                    role = "admin",
                    Todos = new List<Todo>(){

                        new Todo{ title = "tarea 1" , created_date = DateTime.Now, completed_date = default, description = "description", priority = 5}

                    }
                },

                new User() {

                    name = "empleado 1",
                    password = "1234",
                    role = "empleado",
                    Todos = new List<Todo>(){

                        new Todo{ title = "tarea 2" , created_date = DateTime.Now, completed_date = default, description = "description", priority = 3},
                        new Todo{ title = "tarea 3" , created_date = DateTime.Now, completed_date = default, description = "description", priority = 2},
                        new Todo{ title = "tarea 4" , created_date = DateTime.Now, completed_date = default, description = "description", priority = 1},
                    }
                },

                new User() {

                    name = "empleado 2",
                    password = "1234",
                    role = "empleado",
                    Todos = new List<Todo>(){

                        new Todo{ title = "tarea 5" , created_date = DateTime.Now, completed_date = default, description = "description", priority = 1},
                        new Todo{ title = "tarea 6" , created_date = DateTime.Now, completed_date = default, description = "description", priority = 2},
                        new Todo{ title = "tarea 7" , created_date = DateTime.Now, completed_date = default, description = "description", priority = 3},
                    }
                },

                new User() {

                    name = "empleado 3",
                    password = "1234",
                    role = "junior",
                    Todos = new List<Todo>(){

                        new Todo{ title = "tarea 8" , created_date = DateTime.Now, completed_date = default, description = "description", priority = 1},
                        new Todo{ title = "tarea 9" , created_date = DateTime.Now, completed_date = default, description = "description", priority = 2},
                        new Todo{ title = "tarea 10" , created_date = DateTime.Now, completed_date = default, description = "description", priority = 3},
                    }
                },

            };




            dataContext.Users.AddRange(Users);
            dataContext.SaveChanges();
            
        }
    }
}