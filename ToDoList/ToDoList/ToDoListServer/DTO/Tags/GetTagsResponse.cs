using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.DTO.Tags
{
    public class GetTagsResponse : ResponseMessage
    {
        public List<Tag> Tags { get; set; }
    }
}
