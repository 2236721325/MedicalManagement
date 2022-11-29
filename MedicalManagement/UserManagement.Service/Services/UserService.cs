using AutoMapper;
using Base.Shared;
using Base.Shared.Commons;
using Base.Shared.Dtos;
using LinqSharp.EFCore;
using MedicalManagement.EntityFramework.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Models;
using UserManagement.Service.Dtos;
using UserManagement.Service.IServices;

namespace UserManagement.Service.Services
{
    public class UserService : IUserService,IDependency
    {
        public DbContext _DbContext { get; set; }
        public DbSet<User> _Enitity { get; set; }
        public IMapper _Mapper { get; set; }

        public UserService(MyDbContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _Enitity = dbContext.Users;
            _Mapper = mapper;
        }
        public async Task<ApiResult<UserDto>> LoginAsync(UserLoginDto dto)
        {
            var pwdHash = MD5Helper.MD5Encrypt32(dto.Password);
            var user =await _Enitity.Where(e => e.Account == dto.Account && e.PasswordHash == pwdHash)
                .FirstOrDefaultAsync();
            if(user == null)
            {
                return ApiResult.OhNo<UserDto>("账号或密码错误！");
            }
            return ApiResult.Ok(_Mapper.Map<User, UserDto>(user));
        }

        public async Task<ApiResult> RegisteAsync(UserRegisteDto dto)
        {
            var u =await _Enitity.Where(e => e.Account == dto.Account)
                .FirstOrDefaultAsync();
            if (u != null) return ApiResult.OhNo("账号已存在！");
            var user = new User(dto.Name, dto.Account,
                MD5Helper.MD5Encrypt32(dto.Password));
            await _Enitity.AddAsync(user);
            await _DbContext.SaveChangesAsync();
            return ApiResult.Ok();


        }
    }
}
