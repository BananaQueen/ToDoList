using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.DTO.Tags
{
    public class UpdateTagRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
