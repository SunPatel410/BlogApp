using AutoMapper;
using BA.Domains;
using BA.Infrastructure.Data.Interfaces;
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
        private readonly IBlogRepository _blogRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BlogService(IBlogRepository blogRepository, IUnitOfWork unitOfWork)
        {
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
        }


        public BlogDto Get(int blogId)
        {
            var blog = _blogRepository.Get(blogId);
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

            _blogRepository.Remove(comment);

            _unitOfWork.Complete();
        }

        public void AddLike(Request<LikeDto> request)
        {
            var blog = _blogRepository.Get(x => x.Id == request.EntityId).FirstOrDefault();

            if (blog == null)
                throw new ArgumentNullException(nameof(blog));

            var like = Mapper.Map<Like>(request.Details);

            blog.AddLike(like);

            _unitOfWork.Complete();
        }

        public void RemoveLike(Request<LikeDto> request)
        {
            var blog = _blogRepository.Get(x => x.Id == request.EntityId).FirstOrDefault();

            if (blog == null)
                throw new ArgumentNullException(nameof(blog));

            var like = Mapper.Map<Like>(request.Details);

            blog.RemoveLike(like);

            _unitOfWork.Complete();
        }

        public IEnumerable<BlogDto> Search(string query)
        {
            var search = _blogRepository.Get(x => x.Title == query);

            return Mapper.Map<IEnumerable<BlogDto>>(search);
        }

        public IEnumerable<BlogDetailsDto> GetBlogList()
        {
            var blogs = _blogRepository.Get();

            return Mapper.Map<IEnumerable<BlogDetailsDto>>(blogs);
        }
    }
}
