using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.DTO.Tags
{
    public interface ITagService
    {
        GetTagsResponse GetTags();
        GetTagsResponse GetTags(GetTagsRequest request);
        bool CreateTag(CreateTagRequest request);
        bool DeleteTag(DeleteTagRequest request);
        bool UpdateTag(UpdateTagRequest request);
    }
}
