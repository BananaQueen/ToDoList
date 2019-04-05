using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListServer.DTO.Tags;

namespace ToDoListServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        ITagService _service;

        public TagController(ITagService service)
        {
            _service = service;
        }

        // GET: api/Tag
        [HttpGet]
        public ActionResult<GetTagsResponse> Get()
        {
            return _service.GetTags();
        }

        // GET: api/Tag/5
        [HttpGet("{id}")]
        public ActionResult<GetTagsResponse> Get(int id)
        {
            return _service.GetTags(new GetTagsRequest { Id = id });
        }

        // POST: api/Tag
        [HttpPost]
        public bool Post([FromBody] Tag tag)
        {
            return _service.CreateTag(new CreateTagRequest { Name = tag.Name });
        }

        // PUT: api/Tag/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] string value)
        {
            return _service.UpdateTag(new UpdateTagRequest { Id = id, Name = value });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _service.DeleteTag(new DeleteTagRequest { Id = id });
        }
    }
}
