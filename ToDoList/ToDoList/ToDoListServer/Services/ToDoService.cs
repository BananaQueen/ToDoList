using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListServer.DTO.Todos;
using ToDoList.Entities;
using ToDoListServer.DTO.Categories;

namespace ToDoListServer.Services
{
    public class ToDoService : IToDoService
    {
        ToDoContext _context;

        public ToDoService(ToDoContext context)
        {
            _context = context;
        }

        public bool CreateToDo(CreateToDoRequest request)
        {
            ResponseMessage responseMessage = new ResponseMessage();

            var category = _context.Category.FirstOrDefault(x => x.Id == request.Category.Id);

            var tag = _context.Tag.FirstOrDefault(x => x.Id == request.Tag.Id);

            try
            {
                if (string.IsNullOrEmpty(request.Name))              
                {
                    responseMessage.Errors.Add("Name is empty or null");
                    return responseMessage.IsOk;
                }
                if (string.IsNullOrEmpty(request.Description))
                {
                    responseMessage.Errors.Add("Description is empty or null");
                    return responseMessage.IsOk;
                }
                if (request.Category == null)
                {
                    responseMessage.Errors.Add("Category is null");
                    return responseMessage.IsOk;
                }
                if (request.EventDate == null)
                {
                    responseMessage.Errors.Add("EventDate is null");
                    return responseMessage.IsOk;
                }
                if (request.IsDone == null)
                {
                    responseMessage.Errors.Add("IsDone is null");
                    return responseMessage.IsOk;
                }
                if (request.ReminderDate == null)
                {
                    responseMessage.Errors.Add("ReminderDate is null");
                    return responseMessage.IsOk;
                }
                if (request.Tag == null)
                {
                    responseMessage.Errors.Add("Tag is null");
                    return responseMessage.IsOk;
                }

                _context.ToDo.Add(new ToDoEntity
                {
                    Name = request.Name,
                    Category = category,
                    Description = request.Description,
                    EventDate = request.EventDate,
                    IsDone = request.IsDone,
                    ReminderDate = request.ReminderDate,
                    Tag = tag
                });
                    _context.SaveChanges();

                return responseMessage.IsOk;
            }
            catch (Exception msg)
            {
                responseMessage.Errors.Add(msg.Message);
            }
            return responseMessage.IsOk;
        }

        public bool DeleteToDo(DeleteToDoRequest request)
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
                    _context.ToDo.Remove(new ToDoEntity { Id = request.Id });
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

        //checking
        public GetToDosResponse GetToDos()
        {
            var response = new GetToDosResponse();

            try
            {
                response.ToDos = _context.ToDo.Select(x => new ToDo
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Category = new Category { Name = x.Category.Name },
                    EventDate = x.EventDate,
                    IsDone = x.IsDone,
                    ReminderDate = x.ReminderDate,
                    Tag = new DTO.Tags.Tag { Name = x.Tag.Name }

                }).ToList();
            }
            catch (Exception msg)
            {
                response.Errors.Add(msg.Message);
            }

            return response;
        }

        //checking
        public GetToDosResponse GetToDos(GetToDosRequest request)
        {
            var response = new GetToDosResponse();

            try
            {
                if(request.Id <= 0)
                {
                    response.Errors.Add("The Id value is 0 or lower");
                    return response;
                }
                else
                {
                    response.ToDos = _context.ToDo.Where(x => x.Id == request.Id).Select(x => new ToDo
                    {
                        Name = x.Name,
                        Id = x.Id,
                        Category = new Category { Name = x.Category.Name},
                        Description = x.Description,
                        EventDate = x.EventDate,
                        IsDone = x.IsDone,
                        ReminderDate = x.ReminderDate,
                        Tag = new DTO.Tags.Tag { Name = x.Tag.Name}

                    }).ToList();
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

        public bool UpdateToDo(UpdateToDoRequest request)
        {
            ResponseMessage responseMessage = new ResponseMessage();

            var category = _context.Category.FirstOrDefault(x => x.Id == request.Category.Id);

            var tag = _context.Tag.FirstOrDefault(x => x.Id == request.Tag.Id);

            try
            {
                var todo = _context.ToDo.FirstOrDefault(x => x.Id == request.Id);
                if (todo == null)
                {
                    responseMessage.Errors.Add("ToDo is null");
                    return responseMessage.IsOk;
                }
                else
                {
                    todo.Name = request.Name;
                    todo.Category = category;
                    todo.Description = request.Description;
                    todo.EventDate = request.EventDate;
                    todo.IsDone = request.IsDone;
                    todo.ReminderDate = request.ReminderDate;
                    todo.Tag = tag;
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
    }
}
