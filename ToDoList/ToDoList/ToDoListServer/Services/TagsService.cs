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

        public bool CreateTag(CreateTagRequest request)
        {
            var response = new CreateTagRequest();

            try
            {
                if (string.IsNullOrEmpty(request.Name))
                {
                    return false;
                }
                else
                {
                    _context.Tag.Add(new ToDoList.Entities.TagEntity { Name = request.Name });
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

        public bool DeleteTag(DeleteTagRequest request)
        {
            var response = new DeleteTagRequest();

            try
            {
                if (request.Id == 0)
                {
                    return false;
                }
                else
                {
                    _context.Tag.Remove(new ToDoList.Entities.TagEntity { Id = request.Id });
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
                Console.WriteLine(msg.Message);
            }

            return response;
        }

        public GetTagsResponse GetTags(GetTagsRequest request)
        {
            var response = new GetTagsResponse();

            try
            {
                if(request.Id < 0)
                {
                    response = null;
                    return response;
                }
                else
                {
                    response.Tags = _context.Tag.Where(x => x.Id == request.Id).Select(x => new Tag { Name = x.Name, Id = x.Id }).ToList();
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

        public bool UpdateTag(UpdateTagRequest request)
        {
            var response = new UpdateTagRequest();

            try
            {
                var tag = _context.Tag.FirstOrDefault(x => x.Id == request.Id);
                if (tag == null)
                {
                    return false;
                }
                else
                {
                    tag.Name = request.Name;
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
