using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListServer.DTO.TodosForMembers;

namespace ToDoListServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoForMembersController : ControllerBase
        {

        IToDoForMembersService _service;

        public ToDoForMembersController(IToDoForMembersService service)
        {
            _service = service;
        }

        // GET: api/ToDoForMembers
        [HttpGet]
        public ActionResult<GetToDosForMembersResponse> Get()
        {
            return _service.GetToDosForMembers();
        }

        // GET: api/ToDoForMembers/5
        [HttpGet("{id}")]
        public ActionResult<GetToDosForMembersResponse> Get(int id)
        {
            return _service.GetToDosForMembers(new GetToDosForMembersRequest { Id = id });
        }

        // POST: api/ToDoForMembers
        [HttpPost]
        public ResponseMessage Post([FromBody] ToDoForMembers toDoForMembers)
        {
            return _service.CreateToDoForMembers(new CreateToDoForMembers { Email = toDoForMembers.Email, Tag = toDoForMembers.Tag, ToDo = toDoForMembers.ToDo });
        }

        // PUT: api/ToDoForMembers/5
        [HttpPut("{id}")]
        public ResponseMessage Put(int id, [FromBody] ToDoForMembers toDoForMembers)
        {
            return _service.UpdateToDoForMembers(new UpdateToDoForMembers { Email = toDoForMembers.Email, Id = id, Tag = toDoForMembers.Tag, ToDo = toDoForMembers.ToDo });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ResponseMessage Delete(int id)
        {
            return _service.DeleteToDoForMembers(new DeleteToDoForMembers { Id = id });
        }
    }
}
