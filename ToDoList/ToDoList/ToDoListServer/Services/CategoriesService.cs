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
                response.Errors.Add(msg.Message);
            }

            return response;
        }

        public GetCategoriesResponse GetCategories(GetCategoriesRequest request)
        {
            var response = new GetCategoriesResponse();
            
            try
            {
                if(request.Id <= 0)
                {
                    response.Errors.Add("The Id value is 0 or less");
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
                response.Errors.Add(msg.Message);
            }

            response.Errors.Add("Something went wrong");
            return response;
        }

        public bool CreateCategory(CreateCategoryRequest request)
        {
            ResponseMessage responseMessage = new ResponseMessage();

            try
            {
                if (string.IsNullOrEmpty(request.Name))
                {
                    responseMessage.Errors.Add("Name is empty or null");
                    return responseMessage.IsOk;
                }
                else
                {
                    _context.Category.Add(new CategoryEntity { Name = request.Name });
                    _context.SaveChanges();
                }
                return responseMessage.IsOk;
            }
            catch (Exception msg)
            {
                responseMessage.Errors.Add(msg.Message);
            }
            return responseMessage.IsOk;
        }

        public bool DeleteCategory(DeleteCategoryRequest request)
        {
            ResponseMessage responseMessage = new ResponseMessage();

            try
            {
                if (request.Id <= 0)
                {
                    responseMessage.Errors.Add("The Id value is 0 or less");
                    return responseMessage.IsOk;
                }
                else
                {
                    _context.Category.Remove(new CategoryEntity { Id = request.Id });
                    _context.SaveChanges();
                }
                return responseMessage.IsOk;
            }
            catch (Exception msg)
            {
                responseMessage.Errors.Add(msg.Message);
            }
            return responseMessage.IsOk;
        }

        public bool UpdateCategory(UpdateCategoryRequest request)
        {
            var response = new CreateCategoryRequest();

            try
            {
                var category = _context.Category.FirstOrDefault(x => x.Id == request.Id);
                if (category == null)
                {
                    response.Errors.Add("The category is null");
                    return response.IsOk;
                }
                else
                {
                    category.Name = request.Name;
                    _context.SaveChanges();
                }
                return response.IsOk;
            }
            catch (Exception msg)
            {
                response.Errors.Add(msg.Message);
            }
            return response.IsOk;
        }
    }

}

