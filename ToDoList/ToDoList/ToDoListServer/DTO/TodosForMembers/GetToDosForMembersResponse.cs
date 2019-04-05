using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.DTO.TodosForMembers
{
    public class GetToDosForMembersResponse : ResponseMessage
    {
        public List<ToDoForMembers> ToDosForMembers { get; set; }
    }
}
