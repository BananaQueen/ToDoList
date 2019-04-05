using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListServer.DTO.TodosForMembers;

namespace ToDoListServer.Services
{
    public class ToDoForMembersService : IToDoForMembersService
    {

        ToDoContext _context;

        public ToDoForMembersService(ToDoContext context)
        {
            _context = context;
        }

        public ResponseMessage CreateToDoForMembers(CreateToDoForMembers request)
        {
            ResponseMessage responseMessage = new ResponseMessage();

            var tag = _context.Tag.FirstOrDefault(x => x.Id == request.Tag.Id);

            var todo = _context.ToDo.FirstOrDefault(x => x.Id == request.ToDo.Id);

            try
            {
                if (string.IsNullOrEmpty(request.Email)  )
                {
                    responseMessage.Errors.Add("The Email adress is null or empty");
                }
                if (request.ToDo == null)
                {
                    responseMessage.Errors.Add("The ToDo object is null");
                }
                if (request.Tag == null)
                {
                    responseMessage.Errors.Add("The Tag object is null");
                }
                
                
                _context.ToDoForMembers.Add(new ToDoForMembersEntity
                {
                    Email = request.Email,
                    Tag = tag,
                    ToDo = todo

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

        public ResponseMessage DeleteToDoForMembers(DeleteToDoForMembers request)
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
                    _context.ToDoForMembers.Remove(new ToDoForMembersEntity { Id = request.Id });
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

        public GetToDosForMembersResponse GetToDosForMembers()
        {
            var response = new GetToDosForMembersResponse();

            try
            {
                response.ToDosForMembers = _context.ToDoForMembers.Select(x => new ToDoForMembers
                {
                    Id = x.Id,
                    ToDo = new DTO.Todos.ToDo { Name = x.ToDo.Name},
                    Email = x.Email,
                    Tag = new DTO.Tags.Tag { Name = x.ToDo.Name}

                }).ToList();
            }
            catch (Exception msg)
            {
                response.Errors.Add(msg.Message);
            }

            return response;
        }

        public GetToDosForMembersResponse GetToDosForMembers(GetToDosForMembersRequest request)
        {
            var response = new GetToDosForMembersResponse();

            try
            {
                if (request.Id <= 0)
                {
                    response.Errors.Add("The Id value is 0 or less");
                }
                else
                {
                    response.ToDosForMembers = _context.ToDoForMembers.Where(x => x.Id == request.Id).Select(x => new ToDoForMembers
                    {
                        Email = x.Email,
                        Id = x.Id,
                        ToDo = new DTO.Todos.ToDo { Name = x.ToDo.Name},
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

        public ResponseMessage UpdateToDoForMembers(UpdateToDoForMembers request)
        {
            ResponseMessage responseMessage = new ResponseMessage();

            var tag = _context.Tag.FirstOrDefault(x => x.Id == request.Tag.Id);

            var todo = _context.ToDo.FirstOrDefault(x => x.Id == request.ToDo.Id);

            try
            {
                var toDoForMembers = _context.ToDoForMembers.FirstOrDefault(x => x.Id == request.Id);
                if (toDoForMembers == null)
                {
                    responseMessage.Errors.Add("ToDoForMembers is null");
                }
                else
                {
                    toDoForMembers.Email = request.Email;
                    toDoForMembers.ToDo = todo;
                    toDoForMembers.Id = request.Id;
                    toDoForMembers.Tag = tag;
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
