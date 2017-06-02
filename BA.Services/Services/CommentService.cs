﻿using AutoMapper;
using BA.Domains;
using BA.Infrastructure.Data.Interfaces;
using BA.Infrastructure.Data.Interfaces.Helpers;
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
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public void Update(CommentDto commentDto)
        {
            var comment = _commentRepository.Get(commentDto.Id);

            comment.Update(commentDto.CommentDescription);
            _unitOfWork.Complete();
        }

        public void AddLike(Request<LikeDto> request)
        {
            var comment = _commentRepository.Get(x => x.Id == request.EntityId).FirstOrDefault();

            if (comment == null)
                throw new ArgumentNullException(nameof(comment));
            
            var like = Mapper.Map<Like>(request.Details);

            comment.AddLike(like);

            _unitOfWork.Complete();

        }

        public void RemoveLike(Request<LikeDto> request)
        {
            var comment = _commentRepository.Get(x => x.Id == request.EntityId).FirstOrDefault();

            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            var like = Mapper.Map<Like>(request.Details);

            comment.RemoveLike(like);

            _unitOfWork.Complete();


        }
    }
}
