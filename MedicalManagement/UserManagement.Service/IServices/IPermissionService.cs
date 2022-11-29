using Base.Shared.Dtos;
using UserManagement.Service.Dtos;

namespace UserManagement.Service.IServices
{
    public interface IPermissionService
    {
        Task<ApiResult> AddPermission(PermissionCommonDto dto);
        Task<ApiResult> CheckPermission(PermissionCommonDto dto);
    }
}
