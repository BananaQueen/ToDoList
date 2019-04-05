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
        ResponseMessage CreateTag(CreateTagRequest request);
        ResponseMessage DeleteTag(DeleteTagRequest request);
        ResponseMessage UpdateTag(UpdateTagRequest request);
    }
}
