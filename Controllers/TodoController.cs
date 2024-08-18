using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PruebaTenicaTodos.Dto;
using PruebaTenicaTodos.Models;
using PruebaTenicaTodos.Interface;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;


namespace PruebaTenicaTodos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TodoController : Controller
    {
        TodoInterface _todo;
        UserInterface _user;
        IMapper _mapper;
        public TodoController(TodoInterface todo, UserInterface user, IMapper mapper)
        {
            _todo = todo;
            _user = user;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAllTodos() {

            var todos = _todo.GetAllTodos();

            if (!ModelState.IsValid) {

                return BadRequest(ModelState);
            }

            var mapped = _mapper.Map<ICollection<TodoDto>>(todos);

            return Ok(mapped);

        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetTodoById(int id) {

            var todo = _todo.GetTodoById(id);

            if (todo == null) {

                ModelState.AddModelError("", "Todo not found");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid) {

                return BadRequest(ModelState);

            }

            var mapped = _mapper.Map<TodoDto>(todo);

            return Ok(mapped);

        }

        [HttpGet("GetUser/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetUser(int id) {

            var user = _todo.GetUser(id);
            if (user == null) {

                ModelState.AddModelError("", "User or Todo not found");
                return StatusCode(404, ModelState);

            }
            if (!ModelState.IsValid) {

                return BadRequest(ModelState);
            }

            var mapped = _mapper.Map<UserDto>(user);

            return Ok(mapped);
        }

        [HttpPost("CreateTodo")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult CreateTodo([FromBody] TodoDto todo, [FromQuery] int UserId) {

            var tmp_todo = _mapper.Map<Todo>(todo);

            var user = _user.GetUserById(UserId);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found, unable to create Todo");
                return StatusCode(404, ModelState);
            }
            tmp_todo.user = user;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_todo.CreateTodo(tmp_todo)) {

                ModelState.AddModelError("", "Something went wrong while creating todo");
                return StatusCode(500, ModelState);

            }

            return Ok("Todo created successfully");

        }

        [HttpPut("UpdateTodo")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult UpdateTodo([FromBody] TodoDto todo,[Required] [FromQuery] int id) {

            var old_todo = _todo.GetTodoById(id);

            if (old_todo == null) {

                ModelState.AddModelError("", "Todo not found");
                return StatusCode(404, ModelState);

            }

            if (id != todo.Id)
                return BadRequest(ModelState);

            old_todo.title = todo.title;
            old_todo.created_date = todo.created_date;
            old_todo.completed_date = todo.completed_date;
            old_todo.description = todo.description;
            old_todo.state = todo.state;
            old_todo.priority = todo.priority;
           
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_todo.UpdateTodo(old_todo)) {

                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return Ok("Todo updated successfully!");

        }

        [HttpDelete("DeleteTodo/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult DeleteTodo(int id) { 

           var todo = _todo.GetTodoById(id);

            if (todo == null) {

                ModelState.AddModelError("", "Todo not found");
                return StatusCode(404, ModelState);
            }

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_todo.DeleteTodo(todo)) {

                ModelState.AddModelError("", "Somethin went wrong while deleting");
                return StatusCode(404, ModelState);
            }

            return Ok("Todo deleted successfully");
               
        
        }



    }
}
