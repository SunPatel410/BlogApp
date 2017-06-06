using System;
using System.Collections.Generic;
using System.Linq;

namespace BA.Domains
{
    public class Blog : TEntity
    {
        public ApplicationUser User { get; private set; }
        public string Title { get; private set; }
        public Category Category { get; private set; }
        public string Description { get; private set; }
        public DateTime PostedDate { get; private set; }
        public IList<Comment> Comments { get; private set; }
        public IList<Like> Likes { get; set; }
        public bool Hide { get; private set; }

        protected Blog()
        {
            
        }

        public Blog(ApplicationUser user, string title, Category category, string description)
        {
            User = user;
            Title = title;
            Category = category;
            Description = description;
            PostedDate = DateTime.Now;

            TitleValidation(title);
            DescriptionValidation(description);

            Likes = new List<Like>();
            Comments = new List<Comment>();
        }

        public void Update(string title, string description, Category categories)
        {
            Title = title;
            Description = description;
            Category = categories;
        }

        private void TitleValidation(string title)
        {
            if (string.IsNullOrWhiteSpace(title) || title.Length < 5)
                throw new InvalidOperationException("Title cannot be less than 5 characters");

            if (title.Length > 25)
                throw new InvalidOperationException("Title cannot be more than 25 characters");
            Title = title;
        }

        private void DescriptionValidation(string description)
        {
            if (string.IsNullOrWhiteSpace(description) || description.Length < 5)
                throw new InvalidOperationException("Description cannot be less than 5 characters");

            if (description.Length > 120)
                throw new InvalidOperationException("Description cannot be more than 25 characters");
            Description = description;
        }
        public void AddComment(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            Comments.Add(comment);
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
