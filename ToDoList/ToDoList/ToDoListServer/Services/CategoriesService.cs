using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ToDoListServer.DTO;
using ToDoListServer.DTO.Categories;


namespace ToDoListServer.Services
{
    public class CategoriesService : ICategoriesService
    {
        ToDoContext _context;

        public CategoriesService(ToDoContext context)
        {
            _context = context;
        }

        public GetCategoriesResponse GetCategories()
        {
            var response = new GetCategoriesResponse();

            try
            {
                response.Categories = _context.Category.Select(x => new Category
                {
                    Id = x.Id,
                    Name = x.Name,

                }).ToList();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }

            return response;
        }

        public GetCategoriesResponse GetCategories(GetCategoriesRequest request)
        {
            var response = new GetCategoriesResponse();
            
            try
            {
                if(request.Id < 0)
                {
                    response = null;
                    return response;
                }
                else
                {
                    response.Categories = _context.Category.Where(x => x.Id == request.Id).Select(x => new Category { Name = x.Name, Id = x.Id }).ToList();
                    return response;
                }
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }

            response = null;
            return response;
        }

        public bool CreateCategory(CreateCategoryRequest request)
        {
            var response = new CreateCategoryRequest();

            try
            {
                if (string.IsNullOrEmpty(request.Name))
                {
                    return false;
                }
                else
                {
                    _context.Category.Add(new CategoryEntity { Name = request.Name });
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
            return false;
        }

        public bool DeleteCategory(DeleteCategoryRequest request)
        {
            var response = new CreateCategoryRequest();

            try
            {
                if (request.Id == 0)
                {
                    return false;
                }
                else
                {
                    _context.Category.Remove(new CategoryEntity { Id = request.Id });
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
            return false;
        }

        public bool UpdateCategory(UpdateCategoryRequest request)
        {
            var response = new CreateCategoryRequest();

            try
            {
                var category = _context.Category.FirstOrDefault(x => x.Id == request.Id);
                if (category == null)
                {
                    return false;
                }
                else
                {
                    category.Name = request.Name;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
            return false;
        }
    }

}

