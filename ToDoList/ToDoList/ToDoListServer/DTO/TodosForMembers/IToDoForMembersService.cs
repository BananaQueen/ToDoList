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
        ResponseMessage CreateToDoForMembers(CreateToDoForMembers request);
        ResponseMessage DeleteToDoForMembers(DeleteToDoForMembers request);
        ResponseMessage UpdateToDoForMembers(UpdateToDoForMembers request);
    }
}
