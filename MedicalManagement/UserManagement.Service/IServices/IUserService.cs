using Base.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Service.Dtos;

namespace UserManagement.Service.IServices
{
    public interface IUserService
    {
        Task<ApiResult> RegisteAsync(UserRegisteDto dto);
        Task<ApiResult<UserDto>> LoginAsync(UserLoginDto dto);
    }
}
