using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Entities;
using ToDoListServer.DTO.Tags;
using ToDoListServer.DTO.Todos;

namespace ToDoListServer.DTO.TodosForMembers
{
    public class CreateToDoForMembers
    {
        public ToDo ToDo { get; set; }
        public string Email { get; set; }
        public Tag Tag { get; set; }
    }
}
