using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ToDoListServer.DTO.Tags;

namespace ToDoListServer.Services
{
    public class TagsService : ITagService
    {
        ToDoContext _context;

        public TagsService(ToDoContext context)
        {
            _context = context;
        }

        public ResponseMessage CreateTag(CreateTagRequest request)
        {
            var response = new CreateTagRequest();

            try
            {
                if (string.IsNullOrEmpty(request.Name))
                {
                    response.Errors.Add("The name is empty or null");
                }
                else
                {
                    _context.Tag.Add(new ToDoList.Entities.TagEntity { Name = request.Name });
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

        public ResponseMessage DeleteTag(DeleteTagRequest request)
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
                    _context.Tag.Remove(new ToDoList.Entities.TagEntity { Id = request.Id });
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

        public GetTagsResponse GetTags()
        {
            var response = new GetTagsResponse();

            try
            {
                response.Tags = _context.Tag.Select(x => new Tag
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

        public GetTagsResponse GetTags(GetTagsRequest request)
        {
            var response = new GetTagsResponse();

            try
            {
                if(request.Id <= 0)
                {
                    response.Errors.Add("The Id value is 0 or less");
                }
                else
                {
                    response.Tags = _context.Tag.Where(x => x.Id == request.Id).Select(x => new Tag { Name = x.Name, Id = x.Id }).ToList();
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

        public ResponseMessage UpdateTag(UpdateTagRequest request)
        {
            ResponseMessage responseMessage = new ResponseMessage();

            try
            {
                var tag = _context.Tag.FirstOrDefault(x => x.Id == request.Id);
                if (tag == null)
                {
                    responseMessage.Errors.Add("The Tag is null");
                }
                else
                {
                    tag.Name = request.Name;
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
