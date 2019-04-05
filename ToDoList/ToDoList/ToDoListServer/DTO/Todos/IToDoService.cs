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
        bool CreateToDo(CreateToDoRequest request);
        bool DeleteToDo(DeleteToDoRequest request);
        bool UpdateToDo(UpdateToDoRequest request);
    }
}
