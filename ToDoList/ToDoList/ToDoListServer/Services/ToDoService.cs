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

        public ResponseMessage CreateToDo(CreateToDoRequest request)
        {
            ResponseMessage responseMessage = new ResponseMessage();

            var category = _context.Category.FirstOrDefault(x => x.Id == request.Category.Id);

            var tag = _context.Tag.FirstOrDefault(x => x.Id == request.Tag.Id);

            try
            {
                if (string.IsNullOrEmpty(request.Name))              
                {
                    responseMessage.Errors.Add("Name is empty or null");
                }
                if (string.IsNullOrEmpty(request.Description))
                {
                    responseMessage.Errors.Add("Description is empty or null");
                }
                if (request.Category == null)
                {
                    responseMessage.Errors.Add("Category is null");
                }
                if (request.EventDate == null)
                {
                    responseMessage.Errors.Add("EventDate is null");
                }
                if (request.IsDone == null)
                {
                    responseMessage.Errors.Add("IsDone is null");
                }
                if (request.ReminderDate == null)
                {
                    responseMessage.Errors.Add("ReminderDate is null");
                }
                if (request.Tag == null)
                {
                    responseMessage.Errors.Add("Tag is null");
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

        public ResponseMessage DeleteToDo(DeleteToDoRequest request)
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
                    _context.ToDo.Remove(new ToDoEntity { Id = request.Id });
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
            if (!response.IsOk)
                return response;

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
                    if (!response.IsOk)
                        return response;
                }
            }
            catch (Exception msg)
            {
                response.Errors.Add(msg.Message);
            }

            response.Errors.Add("Something went wrong");
            if (!response.IsOk)
                return response;

            return response;
        }

        public ResponseMessage UpdateToDo(UpdateToDoRequest request)
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
    }
}
