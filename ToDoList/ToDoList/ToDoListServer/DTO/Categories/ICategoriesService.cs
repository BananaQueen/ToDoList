using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.DTO.Categories
{
    public interface ICategoriesService
    {
        GetCategoriesResponse GetCategories();
        GetCategoriesResponse GetCategories(GetCategoriesRequest request);
        ResponseMessage CreateCategory(CreateCategoryRequest request);
        ResponseMessage DeleteCategory(DeleteCategoryRequest request);
        ResponseMessage UpdateCategory(UpdateCategoryRequest request);
    }
}
