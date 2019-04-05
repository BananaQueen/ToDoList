using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Entities;
using ToDoListServer.DTO.Todos;

namespace ToDoListServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        IToDoService _service;

        public ToDoController(IToDoService service)
        {
            _service = service;
        }


        // GET api/ToDo
        [HttpGet]
        public ActionResult<GetToDosResponse> Get()
        {
            return _service.GetToDos();
        }

        // GET api/ToDo
        [HttpGet("{id}")]
        public ActionResult<GetToDosResponse> Get(int id)
        {
            return _service.GetToDos(new GetToDosRequest { Id = id });
        }

        // POST api/ToDo
        [HttpPost]
        public bool Post([FromBody] ToDo todo)
        {
            return _service.CreateToDo(new CreateToDoRequest { Category = todo.Category, Description = todo.Description, EventDate = todo.EventDate, IsDone = todo.IsDone, Name = todo.Name, ReminderDate = todo.ReminderDate, Tag = todo.Tag });
        }

        // PUT api/ToDo
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] ToDo todo)
        {
            return _service.UpdateToDo(new UpdateToDoRequest { Id =id, Category = todo.Category, Description = todo.Description, EventDate = todo.EventDate, IsDone = todo.IsDone, Name = todo.Name, ReminderDate = todo.ReminderDate, Tag = todo.Tag });
        }

        // DELETE api/ToDo
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _service.DeleteToDo(new DeleteToDoRequest { Id = id });
        }
    }
}
