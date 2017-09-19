using AutoMapper;
using BA.Domains;
using BA.Infrastructure.Data.Interfaces;
using BA.Services.Dtos;
using BA.Services.Interfaces;
using BA.Services.Requests;
using System;
using System.Linq;

namespace BA.Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Update(CommentDto commentDto)
        {
            var comment = _commentRepository.Get(commentDto.Id);
            _commentRepository.Update(comment);
            _commentRepository.Save();
            //comment.Update(commentDto.CommentDescription);
        }

        public void AddLike(Request<LikeDto> request)
        {
            var comment = _commentRepository.Get(x => x.Id == request.EntityId).FirstOrDefault();

            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            var like = Mapper.Map<Like>(request.Details);

            comment.AddLike(like);
            _commentRepository.Save();
        }

        public void RemoveLike(Request<LikeDto> request)
        {
            var comment = _commentRepository.Get(x => x.Id == request.EntityId).FirstOrDefault();

            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            var like = Mapper.Map<Like>(request.Details);

            comment.RemoveLike(like);
            _commentRepository.Save();
        }
    }
}
