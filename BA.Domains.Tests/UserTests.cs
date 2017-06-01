using NUnit.Framework;
using System;

namespace BA.Domains.Tests
{

    [TestFixture]
    public class UserTests : BaseTest
    {
        [Test]
        public void Initialize_User_Success()
        {
            var user = User;

            Assert.AreEqual(FirstName, user.FirstName);
            Assert.AreEqual(LastName, user.LastName);
            Assert.AreEqual(Email, user.Email);
            Assert.AreEqual(UserName, user.UserName);
            Assert.AreEqual(Password, user.Password);
        }

        [TestCase("12345678901234651", LastName, Email, UserName, Password, TestName = "Fails with too long firstname")]
        [TestCase(FirstName, "12345678901234651", Email, UserName, Password, TestName = "Fails with too long lastName")]
        [TestCase(FirstName, LastName, "12345678901234651234567890123465", UserName, Password, TestName = "Fails with too long email")]
        [TestCase(FirstName, LastName, Email, "12345678901234651234567890123465", Password, TestName = "Fails with too long username")]
        [TestCase(FirstName, LastName, Email, UserName, "12345678901234651234567890123465", TestName = "Fails with too long password")]
        public void Initialize_User_Validation_Error(string firstName, string lastName, string email, string userName, string password)
        {
            Assert.Throws<InvalidOperationException>(
                delegate { new User(firstName, lastName, email, userName, password); });
        }

        [TestCase("Sunny", "Patel", "sunny.patel@experian.com", TestName = "Updated successfully")]
        public void Update_Current_User_Success(string firstName, string lastName, string email)
        {
            var user = User;
            user.Update(firstName, lastName, email);

            Assert.AreEqual(user.FirstName, firstName);
            Assert.AreEqual(user.LastName, lastName);
            Assert.AreEqual(user.Email, email);
        }

        [TestCase(FirstName, LastName, null, UserName, Password, TestName = "Email cannot be null")]
        [TestCase(FirstName, LastName, Email, null, Password, TestName = "User name cannot be null")]
        [TestCase(FirstName, LastName, Email, UserName, null, TestName = "Password cannot be null")]
        public void Initialize_Cannot_Be_Null(string firstName, string lastName, string email, string userName, string password)
        {
            Assert.Throws<ArgumentNullException>(
                delegate { new User(firstName, lastName, email, userName, password); });
        }

    }
}
