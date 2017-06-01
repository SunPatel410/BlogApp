using System;

namespace BA.Domains
{
    public class User
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public User()
        {
            
        }

        public User(string firstName, string lastName, string email, string userName, string passWord)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = passWord;

            FirstNameValidation(firstName);
            LastNameValidation(lastName);
            EmailValidation(email);
            UsernameValidation(userName);
            PasswordValidation(passWord);
        }

        private void FirstNameValidation(string firstName)
        {
            if (firstName.Length > 15)
                throw new InvalidOperationException("Too long first name");
              FirstName = firstName;
        }

        private void LastNameValidation(string lastName)
        {
            if (lastName.Length > 15)
                throw new InvalidOperationException("Lastname name is too long");
              LastName = lastName;
        }

        private void EmailValidation(string email)
        {
            if (email != null)
                if (email.Length > 30)
                    throw new InvalidOperationException("email address is too long");
                else
                    Email = email;
            else
                throw new ArgumentNullException(nameof(email));
        }

        private void UsernameValidation (string userName)
        {
            if (userName != null)
                if (userName.Length > 20)
                    throw new InvalidOperationException("username is too long");
                else
                    UserName = userName;
            else
                throw new ArgumentNullException(nameof(userName));
        }

        private void PasswordValidation(string passWord)
        {
            if (passWord != null)
                if (passWord.Length > 8)
                    throw new InvalidOperationException("password is too long");
                else
                    Password = passWord;
            else
                throw new ArgumentNullException(nameof(passWord));
        }

        public void Update(string firstname, string lastname, string email)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
        }
        
    }
}
