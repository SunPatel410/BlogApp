using AutoMapper;
using BA.Domains;
using BA.Infrastructure.Data.Interfaces.Helpers;
using BA.Services.Dtos;
using BA.Services.Interfaces;
using BA.Services.Requests;
using System.Collections.Generic;
using System.Linq;

namespace BA.Services.Services
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<Blog> _blogRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BlogService(IRepository<Blog> blogRepository, IUnitOfWork unitOfWork)
        {
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
        }


        public BlogDto Get(int blogId)
        {
            var blog = _blogRepository.Get(x => x.Id == blogId).FirstOrDefault();

            return Mapper.Map<BlogDto>(blog);
        }

        public void Create(BlogDto blog)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(BlogDto blog)
        {
            throw new System.NotImplementedException();
        }

        public void AddComment(Request<CommentDto> request)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveComment(Request<CommentDto> request)
        {
            throw new System.NotImplementedException();
        }

        public void AddLike(Request<LikeDto> like)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveLike(Request<LikeDto> like)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<BlogDto> Search(string query)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<BlogDto> GetBlogList()
        {
            var blogs = _blogRepository.Get();

            //? add a new blog dto just for details with no like or comments ? 

            throw new System.NotImplementedException();
        }
    }
}
