using AutoMapper;
using BA.Domains;
using BA.Infrastructure.Data.Interfaces;
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

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }


        public BlogDto Get(int blogId)
        {
            var blog = _blogRepository.Get(blogId);
            return Mapper.Map<BlogDto>(blog);
        }

        public int Create(CreateBlogRequest request)
        {
            var blog = Mapper.Map<Blog>(request);
            _blogRepository.Add(blog);

            return blog.Id;
        }

        public void Edit(BlogDto blogDto)
        {
            var blog = _blogRepository.Get(blogDto.Id);

            blog.Update(blog.Title, blog.Description, blog.Category);
        }

        public void AddComment(Request<CommentDto> request)
        {
            var comment = _blogRepository.Get(x => x.Id == request.EntityId).FirstOrDefault();

            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            var commentDto = Mapper.Map<Comment>(request.Details);

            comment.AddComment(commentDto);
        }

        public void RemoveComment(Request<CommentDto> request)
        {
            var comment = _blogRepository.Get(x => x.Id == request.EntityId).FirstOrDefault();

            _blogRepository.Remove(comment);
           
        }

        public void AddLike(Request<LikeDto> request)
        {
            var blog = _blogRepository.Get(x => x.Id == request.EntityId).FirstOrDefault();

            if (blog == null)
                throw new ArgumentNullException(nameof(blog));

            var like = Mapper.Map<Like>(request.Details);

            blog.AddLike(like);

        }

        public void RemoveLike(Request<LikeDto> request)
        {
            var blog = _blogRepository.Get(x => x.Id == request.EntityId).FirstOrDefault();

            if (blog == null)
                throw new ArgumentNullException(nameof(blog));

            var like = Mapper.Map<Like>(request.Details);

            blog.RemoveLike(like);
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
