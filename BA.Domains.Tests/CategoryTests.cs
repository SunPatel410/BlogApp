using NUnit.Framework;
using System;

namespace BA.Domains.Tests
{

    [TestFixture]
    public class CategoryTests : BaseTest
    {
        [Test]
        public void Initialize_Category_Success()
        {
            var cat = Category;

            Assert.AreEqual(Name, cat.Name);
            Assert.AreEqual(CatDescription, cat.CategoryDescription);
        }

        [TestCase("testtesttesttesto1111aaaaaaaa", CatDescription, TestName = "Name is to long")]
        [TestCase(Name, "testtesttesttesto8276theaaaaaaijdsoijfoisjfiosdjdf", TestName = "Description is to long")]
        public void Initialize_User_Validation_Error(string name, string description)
        {
            Assert.Throws<InvalidOperationException>(
                delegate { new Category(name, description);});
        }

        [TestCase("Sunnt test", "My bon bons", TestName = "Updated successfully")]
        public void Update_Category_Success(string name, string desciption)
        {
            var category = Category;
            category.Update(name, desciption);

            Assert.AreNotEqual(Name, name);
            Assert.AreNotEqual(CatDescription, desciption);
        }

        [TestCase(null, CatDescription, TestName = "Name cannot be null")]
        [TestCase(Name, null, TestName = "Description cannot be null")]
        public void Category_Cannot_Be_Null(string name, string description)
        {
            Assert.Throws<ArgumentNullException>(
                   delegate { new Category(name, description); });
        }

    }
}
