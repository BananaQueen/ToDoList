using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.DTO.Todos
{
    public interface IToDoService
    {
        GetToDosResponse GetToDos();
        GetToDosResponse GetToDos(GetToDosRequest request);
        ResponseMessage CreateToDo(CreateToDoRequest request);
        ResponseMessage DeleteToDo(DeleteToDoRequest request);
        ResponseMessage UpdateToDo(UpdateToDoRequest request);
    }
}
