using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.DTO.Tags
{
    public class CreateTagRequest : ResponseMessage
    {
        public string Name { get; set; }
    }
}
