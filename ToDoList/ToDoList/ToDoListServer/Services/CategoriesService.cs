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

        public ResponseMessage CreateCategory(CreateCategoryRequest request)
        {
            ResponseMessage responseMessage = new ResponseMessage();

            try
            {
                if (string.IsNullOrEmpty(request.Name))
                {
                    responseMessage.Errors.Add("Name is empty or null");
                }
                else
                {
                    _context.Category.Add(new CategoryEntity { Name = request.Name });
                    _context.SaveChanges();
                }
                if (!responseMessage.IsOk)
                    return responseMessage;
            }
            catch (Exception msg)
            {
                responseMessage.Errors.Add(msg.Message);
            }
            if (!responseMessage.IsOk)
                return responseMessage;

            return responseMessage;
        }

        public ResponseMessage DeleteCategory(DeleteCategoryRequest request)
        {
            ResponseMessage responseMessage = new ResponseMessage();

            try
            {
                if (request.Id <= 0)
                {
                    responseMessage.Errors.Add("The Id value is 0 or less");
                }
                else
                {
                    _context.Category.Remove(new CategoryEntity { Id = request.Id });
                    _context.SaveChanges();
                }
                if (!responseMessage.IsOk)
                    return responseMessage;
            }
            catch (Exception msg)
            {
                responseMessage.Errors.Add(msg.Message);
            }
            if (!responseMessage.IsOk)
                return responseMessage;

            return responseMessage;
        }

        public ResponseMessage UpdateCategory(UpdateCategoryRequest request)
        {
            var response = new CreateCategoryRequest();

            try
            {
                var category = _context.Category.FirstOrDefault(x => x.Id == request.Id);

                if (category == null)
                {
                    response.Errors.Add("The category is null");
                }
                else
                {
                    category.Name = request.Name;
                    _context.SaveChanges();
                }    
                if (!response.IsOk)
                    return response;
            }
            catch (Exception msg)
            {
                response.Errors.Add(msg.Message);
            }
            if (!response.IsOk)
                return response;

            return response;
        }
    }

}

