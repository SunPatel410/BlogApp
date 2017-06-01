using BA.Services.Dtos;

namespace BA.Services.Interfaces
{
    public interface IUserService
    {
        //bool IsEmailAvailable(string email);
        UserDto GetUser(int userId);
        void AddUser(UserDto userDto);
        void UpdateUser(UserDto userDto);
    }
}
