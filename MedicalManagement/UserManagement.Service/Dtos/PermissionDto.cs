using Base.Shared.Dtos;
using UserManagement.Domain.Models;

namespace UserManagement.Service.Dtos
{
    public class PermissionDto : BaseEntityDto<long>
    {
        public string Name { get; set; }
        public long UserId { get; set; }
    }
    public class PermissionCommonDto
    {
        public string Name { get; set; }
        public long UserId { get; set; }
    }

}
