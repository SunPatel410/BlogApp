namespace BA.Domains.Tests
{
    public abstract class BaseTest
    {
        //user
        //protected const string FirstName = "Obi";
        //protected const string LastName = "One";
        //protected const string Email = "ObiOneIsGreat1@starwars.co.uk";
        //protected const string UserName = "ObiOneHateDarth";
        //protected const string Password = "pass123";

        protected const string UserName = "ObiOneHateDarth";

        //category
        protected const string Name = "TestCategory";
        protected const string CatDescription = "Cat Description";

        //comment
        protected const string CommentDescription = "This is a Comment Description";

        //blog
        protected const string Title = "Title";
        protected const string Description = "This is a a Blog Description";

        //protected User User  { get; set; }
        protected ApplicationUser User  { get; set; }
        protected Category Category { get; set; }
        protected Comment Comment { get; set; }
        protected Blog Blog { get; set; }
        protected Like Like { get; set; }

        protected BaseTest()
        {
            //User = CreateUser();
            Category = CreateCategory();
            Comment = CreateComment();
            Blog = CreateBlog();
        }

        //private User CreateUser()
        //{
        //    return new User(FirstName, LastName, Email, UserName, Password);
        //}

        private Category CreateCategory()
        {
            return new Category(Name, CatDescription);
        }

        private Comment CreateComment()
        {
            return new Comment(User, CommentDescription);
        }

        private Blog CreateBlog()
        {
            return new Blog(User, Title, Category, Description);
        }
    }
}
