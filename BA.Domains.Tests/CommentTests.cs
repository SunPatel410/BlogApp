using NUnit.Framework;
using System;

namespace BA.Domains.Tests
{
    [TestFixture]
    public class CommentTests : BaseTest
    {
        [Test]
        public void Initialize_Comment_Tests()
        {
            var comment = Comment;

            Assert.AreEqual(User.UserName, comment.User.UserName);
            Assert.AreEqual(CommentDescription, comment.CommentDescription);
        }

        [TestCase(
             "testingstestingstestingstestingstestingstestingstestingstestingstestingstestingstestingstestingstestingstestings",
             TestName = "Comment cannot be more than 50")]
        [TestCase("oki", TestName = "Comment must be more than 3")]
        public void Initialize_Comment_Validation_Error(string comment)
        {
            Assert.Throws<InvalidOperationException>(
                delegate { new Comment(User, comment); });
        }

        [TestCase("DDD you are always on my mind", TestName = "Updated successfully")]
        public void Updating_Comment_Success(string commentDescrpt)
        {
            var comment = Comment;
            comment.Update(commentDescrpt);

            Assert.AreEqual(comment.CommentDescription, commentDescrpt);
        }

        [Test]
        public void AddLike_Success()
        {
            var like = new Like(User);

            Comment.AddLike(like);

            Assert.AreEqual(1, Comment.Likes.Count);
        }

        [Test]
        public void AddLike_NullError()
        {
            Assert.Throws<ArgumentNullException>(delegate { Comment.AddLike(null); });
        }

        [Test]
        public void AddLike_CannotLikeTwice()
        {
            var like = new Like(User);

            Comment.AddLike(like);

            Assert.Throws<InvalidOperationException>(delegate { Comment.AddLike(like); });
        }

        [Test]
        public void AddLike_CannotLikeOwnComment()
        {
            var comment = new Comment(User, "Test");
            var like = new Like(User);

            Assert.Throws<InvalidOperationException>(delegate { comment.AddLike(like);});
        }

        [Test]
        public void RemoveLike()
        {
            var like = new Like(User);

            Comment.AddLike(like);

            Comment.RemoveLike(like);

            Assert.AreEqual(0, Comment.Likes.Count);
        }
    }
}
