﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.DTO.Todos
{
    public class GetToDosResponse : ResponseMessage
    {
        public List<ToDo> ToDos { get; set; }
    }
}
