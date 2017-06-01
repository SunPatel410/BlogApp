using AutoMapper;
using BA.Domains;
using BA.Infrastructure.Data.Interfaces;
using BA.Infrastructure.Data.Interfaces.Helpers;
using BA.Services.Dtos;
using BA.Services.Interfaces;
using System;
using System.Linq;

namespace BA.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public UserDto GetUser(int userId)
        {
            var user = _userRepository.Get(x => x.Id == userId).FirstOrDefault();

            if (user == null)
                throw new ArgumentNullException(nameof(userId));

            return Mapper.Map<UserDto>(user);
        }

        public void AddUser(UserDto userDto)
        {
            //do a check for exisiting users.
            var user = Mapper.Map<User>(userDto);

            _userRepository.Add(user);
            _unitOfWork.Complete();
        }

        public void UpdateUser(UserDto userDto)
        {
            var user = _userRepository.Get(userDto.Id);

            user.Update(userDto.FirstName, userDto.LastName, userDto.Email);
            _unitOfWork.Complete();
        }
    }
}
