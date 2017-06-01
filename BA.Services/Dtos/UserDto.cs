namespace BA.Services.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserDto()
        {
        }

        public UserDto(int id, string firstName, string lastName, string email,
            string userName, string passWord)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = passWord;
        }
    }
}
