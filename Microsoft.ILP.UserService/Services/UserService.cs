using AutoMapper;
using System;
using Microsoft.ILP.UserService.DTOs;
using Microsoft.ILP.UserService.Models;
using Microsoft.ILP.UserService.Repositories;

namespace Microsoft.ILP.UserService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<UserDto> GetAll()
        {
            var users = _repository.GetAllUsers();
            return _mapper.Map<List<UserDto>>(users);
        }

        public UserDto GetById(int id)
        {
            var user = _repository.GetUserById(id);
            return _mapper.Map<UserDto>(user);
        }

        public UserDto Create(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.Id = _repository.GetNextUserId();
            _repository.AddUser(user);
            return _mapper.Map<UserDto>(user);
        }

        public void Update(int id, UpdateUserDto dto)
        {
            var existing = _repository.GetUserById(id);
            if (existing == null) return;

            existing.Name = dto.Name;
            existing.Email = dto.Email;
            existing.Role = dto.Role;

            _repository.UpdateUser(existing);
        }

        public void Delete(int id)
        {
            _repository.DeleteUser(id);
        }

        public User? Authenticate(string email, string password)
        {
            var user = _repository
                .GetAllUsers()
                .FirstOrDefault(u => string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase)
                                  && u.Password == password);

            return user;
        }
    }
}
