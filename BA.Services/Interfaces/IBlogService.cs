using BA.Services.Dtos;
using BA.Services.Requests;
using System.Collections.Generic;

namespace BA.Services.Interfaces
{
    public interface IBlogService
    {
        BlogDto Get(int blogId);
        void Create(BlogDto blog);
        void Edit(BlogDto blog);
        void AddComment(Request<CommentDto> request);
        void RemoveComment(Request<CommentDto> request);
        void AddLike(Request<LikeDto> like);
        void RemoveLike(Request<LikeDto> like);
        IEnumerable<BlogDto> Search(string query);
        IEnumerable<BlogDto> GetBlogList();

    }
}