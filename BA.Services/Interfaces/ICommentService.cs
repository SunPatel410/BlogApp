using BA.Services.Dtos;
using BA.Services.Requests;

namespace BA.Services.Interfaces
{
    public interface ICommentService
    {
        void Update(CommentDto commentDto);
        void AddLike(Request<LikeDto> request);
        void RemoveLike(Request<LikeDto> request);
    }
}
