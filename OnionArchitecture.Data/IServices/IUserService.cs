using OnionArchitecture.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Data.IServices
{
    public interface IUserService
    {
        Task<UserResponseDto> RegisterUser(UserRegisterDto userRegisterDto);
    }
}
