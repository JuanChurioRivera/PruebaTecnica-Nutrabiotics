using PruebaTenicaTodos.Interface;
using PruebaTenicaTodos.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PruebaTenicaTodos.Dto;

namespace PruebaTenicaTodos.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        UserInterface _user;
        TodoInterface _todo;
        IMapper _mapper;
        public UserController(UserInterface user, TodoInterface todo, IMapper mapper)
        {
            _user = user;
            _todo = todo;
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAllUsers() {

            var users = _user.GetAllUsers();

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var mapped = _mapper.Map<List<UserDto>>(users);

            return Ok(mapped);

        }

        [HttpGet("GetUserById/{id}")]
        [ProducesResponseType(200)]
        public IActionResult GetUserById(int id) {


            var user = _user.GetUserById(id);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return StatusCode(404, ModelState);
            }

           
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var mapped = _mapper.Map<UserDto>(user);
            return Ok(mapped);

        }

        [HttpGet("GetUsersByRole/{role}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetUsersByRole(string role) {

            var users = _user.GetUserByRole(role);

            if (users == null) {

                return NotFound($"{role} wasnt found");
            }

            if (!ModelState.IsValid) {

                return BadRequest(ModelState);
            }
            var mapped = _mapper.Map<List<UserDto>>(users);
            return Ok(mapped);

        }

        [HttpGet("GetTodosFromUser/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetTodosFromUser(int id)
        {

            var user = _user.GetUserById(id);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return StatusCode(404, ModelState);
            }

            var todos = _user.GetTodosFromUser(id);

            if (todos == null || !todos.Any())
            {
                return NotFound("No todos found for this user.");
            }

            var mapped = _mapper.Map<List<TodoDto>>(todos);

            return Ok(mapped);
        }


        [HttpPost("CreateUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateUser([FromBody] User user) {

            if (user == null)
                return BadRequest(ModelState);

            
            var mapped = _mapper.Map<User>(user);

            if (!_user.CreateUser(mapped)) {

                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("User created!");
        }

        [HttpDelete("DeleteUser/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteUser(int id) {

            var user = _user.GetUserById(id);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return StatusCode(404, ModelState);
            }

           
            if (! _user.DeleteUser(user)) {

                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("User deleted successfully");

        }

        [HttpPut("UpdateUser/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateUser([FromBody] User user, int id)
        {
            
            var tmp_user = _user.GetUserById(id);
            if (tmp_user == null)
            {
                ModelState.AddModelError("", "User not found");
                return StatusCode(404, ModelState);
            }

            tmp_user.name = user.name;  
            tmp_user.password = user.password;
            tmp_user.role = user.role;
           
            if (!_user.UpdateUser(tmp_user))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("User updated successfully");
        }




        [HttpPut("AssignTodo/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult AssingTodo(int id, [FromQuery] int TodoId) {
        
            var user = _user.GetUserById(id);
            var todo = _todo.GetTodoById(TodoId);


            if (todo == null || user == null)
            {

                ModelState.AddModelError("", "User or Todo wasnt found");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (user.Todos == null) {

                user.Todos = new List<Todo>();
            }
            user.Todos.Add(todo);


            if (!_user.UpdateUser(user)) {

                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(404, ModelState);
            }

            return Ok("Todo assigned successfully");
        }



    }
}
