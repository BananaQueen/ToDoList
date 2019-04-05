using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.DTO.Categories
{
    public class GetCategoriesResponse : ResponseMessage
    {
        public List<Category> Categories { get; set; }
    }
}
