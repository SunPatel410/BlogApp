using BA.Services.Dtos;
using BA.Services.Requests;
using System.Collections.Generic;

namespace BA.Services.Interfaces
{
    public interface IBlogService
    {
        BlogDto Get(int blogId);
        void Create(BlogDto blogDto);
        void Edit(BlogDto blogDto);
        void AddComment(Request<CommentDto> request);
        void RemoveComment(Request<CommentDto> request);
        void AddLike(Request<LikeDto> likeDto);
        void RemoveLike(Request<LikeDto> likeDto);
        IEnumerable<BlogDto> Search(string query);
        IEnumerable<BlogDetailsDto> GetBlogList();

    }
}