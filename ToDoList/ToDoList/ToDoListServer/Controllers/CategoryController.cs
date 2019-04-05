using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListServer.DTO.Categories;

namespace ToDoListServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoriesService _service;

        public CategoryController(ICategoriesService service)
        {
            _service = service;
        }

        // GET: api/Category
        [HttpGet]
        public ActionResult<GetCategoriesResponse> Get()
        {
            return _service.GetCategories();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public ActionResult<GetCategoriesResponse> Get(int id)
        {
            return _service.GetCategories(new GetCategoriesRequest { Id = id});
        }

        // POST: api/Category
        [HttpPost]
        public bool Post([FromBody] Category category)
        {
            return _service.CreateCategory(new CreateCategoryRequest { Name = category.Name });
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] string value)
        {
            return _service.UpdateCategory(new UpdateCategoryRequest { Id = id, Name = value });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _service.DeleteCategory(new DeleteCategoryRequest { Id = id });
        }
    }
}
