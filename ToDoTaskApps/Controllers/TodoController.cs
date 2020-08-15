using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoTaskApps.Services;

namespace ToDoTaskApps.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository ??
                throw new ArgumentNullException(nameof(todoRepository));

        }
        [HttpGet]
        public IActionResult GetTodo()
        {
            var TodoFromRepo = _todoRepository.GetTodo();
            return new JsonResult(TodoFromRepo);
        }

    }
}
