using AutoMapper;
using Base.Shared;
using Base.Shared.Dtos;
using MedicalManagement.EntityFramework.Datas;
using Microsoft.EntityFrameworkCore;
using System.Security;
using System.Xml;
using UserManagement.Domain.Models;
using UserManagement.Service.Dtos;
using UserManagement.Service.IServices;

namespace UserManagement.Service.Services
{
    public class PermissionService : IPermissionService,IDependency
    {
        public MyDbContext _DbContext { get; set; }
        public DbSet<Permission> _Enitity { get; set; }
        public IMapper _Mapper { get; set; }

        public PermissionService(MyDbContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _Enitity = dbContext.Permissions;
            _Mapper = mapper;
        }
        public async Task<ApiResult> AddPermission(PermissionCommonDto dto)
        {
            if ((await _DbContext.Users.FindAsync(dto.UserId)) == null)
            {
                return ApiResult.OhNo("对应主键不存在！");
            }
            var permission = new Permission(dto.Name, dto.UserId);
            await _Enitity.AddAsync(permission);
            await _DbContext.SaveChangesAsync();
            return ApiResult.Ok();
        }

        public async Task<ApiResult> CheckPermission(PermissionCommonDto dto)
        {
            var p=await _Enitity
                .Where(e => e.UserId == dto.UserId && e.Name == dto.Name)
                .FirstOrDefaultAsync();
            if (p == null) return ApiResult.OhNo("没有权限！");
            return ApiResult.Ok();
        }
    }
}
