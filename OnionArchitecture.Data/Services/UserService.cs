using OnionArchitecture.Data.IServices;
using OnionArchitecture.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Data.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserResponseDto> RegisterUser(UserRegisterDto userRegisterDto)
        {
            // we use manuall mapping
            //we cam use automapper here to map the dto to user entity but for now we will do it manually
            var user = new Domain.User
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Role = userRegisterDto.Role,
                UserName = userRegisterDto.UserName,
                Password = userRegisterDto.Password,
                ConfirmPassword = userRegisterDto.ConfirmPassword
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return new UserResponseDto
            {
               
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                UserName = user.UserName
            };
        }
    }
}
