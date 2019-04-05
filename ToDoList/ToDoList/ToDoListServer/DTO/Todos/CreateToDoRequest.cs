using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListServer.DTO.Tags;
using ToDoListServer.DTO;
using ToDoList.Entities;
using ToDoListServer.DTO.Categories;

namespace ToDoListServer.DTO.Todos
{
    public class CreateToDoRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime ReminderDate { get; set; }
        public Category Category { get; set; }
        public Tag Tag { get; set; }
    }
}
