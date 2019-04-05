using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.DTO.TodosForMembers
{
    public interface IToDoForMembersService
    {
        GetToDosForMembersResponse GetToDosForMembers();
        GetToDosForMembersResponse GetToDosForMembers(GetToDosForMembersRequest request);
        bool CreateToDoForMembers(CreateToDoForMembers request);
        bool DeleteToDoForMembers(DeleteToDoForMembers request);
        bool UpdateToDoForMembers(UpdateToDoForMembers request);
    }
}
