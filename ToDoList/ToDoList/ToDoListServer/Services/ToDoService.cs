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
            var response = new CreateToDoRequest();

            var category = _context.Category.FirstOrDefault(x => x.Id == request.Category.Id);

            var tag = _context.Tag.FirstOrDefault(x => x.Id == request.Tag.Id);

            try
            {
                if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Description) || request.Category == null || request.EventDate == null || request.IsDone == null || request.ReminderDate == null || request.Tag == null)              
                {
                    return false;
                }
                else
                {
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
                }
                return true;
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
            return false;
        }

        public bool DeleteToDo(DeleteToDoRequest request)
        {
            var response = new DeleteToDoRequest();

            try
            {
                if (request.Id == 0)
                {
                    return false;
                }
                else
                {
                    _context.ToDo.Remove(new ToDoEntity { Id = request.Id });
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
                Console.WriteLine(msg.Message);
            }

            return response;
        }

        //checking
        public GetToDosResponse GetToDos(GetToDosRequest request)
        {
            var response = new GetToDosResponse();

            try
            {
                if(request.Id < 0)
                {
                    response = null;
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
                Console.WriteLine(msg.Message);
            }

            response = null;
            return response;
        }

        public bool UpdateToDo(UpdateToDoRequest request)
        {
            var response = new UpdateToDoRequest();

            var category = _context.Category.FirstOrDefault(x => x.Id == request.Category.Id);

            var tag = _context.Tag.FirstOrDefault(x => x.Id == request.Tag.Id);

            try
            {
                var todo = _context.ToDo.FirstOrDefault(x => x.Id == request.Id);
                if (todo == null)
                {
                    return false;
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
