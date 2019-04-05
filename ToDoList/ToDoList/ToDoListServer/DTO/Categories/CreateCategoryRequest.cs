using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.DTO.Categories
{
    public class CreateCategoryRequest : ResponseMessage
    {
        public string Name { get; set; }
    }
}
