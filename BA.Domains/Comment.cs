using System;
using System.Collections.Generic;
using System.Linq;

namespace BA.Domains
{
    public class Comment : TEntity
    {
        public string User { get; private set; }
        public string CommentDescription { get; private set; }
        public IList<Like> Likes { get; }

        public Comment()
        {
            Likes = new List<Like>();
        }

        public Comment(string user, string comment)
        {
            User = user;
            CommentDescription = comment;

            CommentValidation(comment);
        }

        public void CommentValidation(string commentDescript)
        {
            if (string.IsNullOrWhiteSpace(commentDescript) || (commentDescript.Length <= 3))
                throw new InvalidOperationException("Comment cannot be less than 3 characters");

            if (commentDescript.Length > 50)
                throw new InvalidOperationException("Comment be more than 50");

            CommentDescription = commentDescript;
        }

        public void Update(string commentDescrpt)
        {
            CommentDescription = commentDescrpt;
        }

        public void AddLike(Like like)
        {
            if (like == null)
                throw new ArgumentNullException(nameof(like));

            if (Likes.Any(x => x.UserId == like.UserId))
                throw new InvalidOperationException("Cannot like twice");

            if (like.UserId == Id)
                throw new InvalidOperationException("Cannot like your own comment");

            Likes.Add(like);
        }

        public void RemoveLike(Like like)
        {
            if (Likes.All(x => x.UserId != like.UserId))
                throw new InvalidOperationException(nameof(like));

            var unLike = Likes.First(x => x.UserId == like.UserId);

            Likes.Remove(unLike);
        }
    }
}
