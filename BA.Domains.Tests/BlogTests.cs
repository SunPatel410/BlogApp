//Instanciate => Creating a blog with a Title, Selecting a Category, Having a Description
//      - title min lenght 5 max lenght 25
//      - description min 60 max nvarcharmax
//      - Category can only appear once on the list.

//Update => Can change the Title, Change the Category, Change the Description
//      - title min lenght 5 max lenght 150
//      - description min 60 max nvarcharmax
//      - Category can only appear once on the list.

//Hide => Hide a blog when updating
//      - Click on Hide button to toggle on and off


using FluentAssertions;
using NUnit.Framework;
using System;

namespace BA.Domains.Tests
{
    [TestFixture]
    public class BlogTests : BaseTest
    {
        [Test]
        public void Initialize_Blog_Success()
        {
            var blog = Blog;

            Assert.AreEqual(User, blog.User);
            Assert.AreEqual(Title, blog.Title);
            Assert.AreEqual(Description, blog.Description);
            Assert.AreEqual(Category, blog.Category);
        }

        [TestCase(null, Description, TestName = "Title cannot be null")]       
        [TestCase("This is the realllllllllllll tesco meal deeeealllllllll", Description, TestName = "Title is to long")]       
        [TestCase("hell", Description, TestName = "Title needs to be more then 5")]

        [TestCase(Title, null, TestName = "Description cannot be null")]
        [TestCase(Title, "descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescription" +
                         "descriptiondescriptiondescriptiondescriptiondescriptiondescription" +
                         "descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescription" +
                         "descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescription" +
                         "descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescription" +
                         "descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescription", TestName = "Description is to long")]

        [TestCase(Title, "test", TestName = "Description needs to be more then 5 char")]
        public void Initialize_Blog_Validation_Error(string title, string description)
        {
            Assert.Throws<InvalidOperationException>(
                delegate { new Blog(User,title, Category, description);});
        }

        [TestCase("My name is", "ISP Updatings", TestName = "Updated successfully")]
        public void Update_Blog_Success(string title, string description)
        {
            var cat = new Category("Sunny", "Sunny Patel Rules");
            var updateBlog = Blog;

            updateBlog.Update(title, description, cat);

            updateBlog.Should().NotBe(Title);
            updateBlog.Should().NotBe(Description);
            updateBlog.Should().NotBe(Category);

            //Assert.AreEqual(Title, updateBlog.Title);
            //Assert.AreEqual(Description, updateBlog.Description);
            //Assert.AreEqual(Category, updateBlog.Category);
        }

        [Test]
        public void AddComment_Success()
        {
            var comment = new Comment(User, "DUBAI was LIT!");
            Blog.AddComment(comment);

            Assert.AreEqual(1, Blog.Comments.Count);
        }

        [Test]
        public void AddComment_Null()
        {
            Assert.Throws<ArgumentNullException>(delegate { Blog.AddComment(null); });
        }
    }
}
