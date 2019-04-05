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
        bool CreateCategory(CreateCategoryRequest request);
        bool DeleteCategory(DeleteCategoryRequest request);
        bool UpdateCategory(UpdateCategoryRequest request);
    }
}
