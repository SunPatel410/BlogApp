using AutoMapper;
using BA.Domains;
using BA.Infrastructure.Data.Interfaces.Helpers;
using BA.Services.Dtos;
using BA.Services.Interfaces;
using BA.Services.Requests;
using System;
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

        public void Create(BlogDto blogDto)
        {
            var blog = Mapper.Map<Blog>(blogDto);

            _blogRepository.Add(blog);
            _unitOfWork.Complete();
        }

        public void Edit(BlogDto blogDto)
        {
            var blog = _blogRepository.Get(blogDto.Id);

            blog.Update(blog.Title, blog.Description, blog.Category);
            _unitOfWork.Complete();
        }

        public void AddComment(Request<CommentDto> request)
        {
            var comment = _blogRepository.Get(x => x.Id == request.EntityId).FirstOrDefault();

            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            var commentDto = Mapper.Map<Comment>(request.Details);

            comment.AddComment(commentDto);
            _unitOfWork.Complete();
        }

        public void RemoveComment(Request<CommentDto> request)
        {
            var comment = _blogRepository.Get(x => x.Id == request.EntityId).FirstOrDefault();
            
            //_blogRepository.Remove()
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

        public IEnumerable<BlogDetailsDto> GetBlogList()
        {
            var blogs = _blogRepository.Get();

            return Mapper.Map<IEnumerable<BlogDetailsDto>>(blogs);
        }
    }
}
