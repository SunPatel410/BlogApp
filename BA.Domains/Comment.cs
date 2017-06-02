using System;
using System.Collections.Generic;
using System.Linq;

namespace BA.Domains
{
    public class Comment : TEntity
    {
        public User User { get; private set; }
        public string CommentDescription { get; private set; }
        public IList<Like> Likes { get; }

        public Comment()
        {
            Likes = new List<Like>();
        }

        public Comment(User user, string comment) : this()
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

            if (Likes.Any(x => x.User.Id == like.User.Id))
                throw new InvalidOperationException("Cannot like twice");

            if (like.User.Id == User.Id)
                throw new InvalidOperationException("Cannot like your own comment");

            Likes.Add(like);
        }

        public void RemoveLike(Like like)
        {
            if (Likes.All(x => x.User.Id != like.User.Id))
                throw new InvalidOperationException(nameof(like));

            var unLike = Likes.First(x => x.User.Id == like.User.Id);

            Likes.Remove(unLike);
        }
    }
}
