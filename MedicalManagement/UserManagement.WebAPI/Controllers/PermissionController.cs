using AutoMapper;
using Base.Shared.Dtos;
using LinqSharp.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement.Domain.Models;
using UserManagement.Service.Dtos;
using UserManagement.Service.IServices;
using UserManagement.WebAPI.Settings;

namespace UserManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _PermissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _PermissionService = permissionService;
        }

        [HttpPost]
        public async Task<ApiResult> AddPermission(PermissionCommonDto dto)
        {
            return await _PermissionService.AddPermission(dto);
        }

        [HttpPost]
        public async Task<ApiResult> CheckPermission(PermissionCommonDto dto)
        {
            return await _PermissionService.CheckPermission(dto);
        }
    }
}
       

