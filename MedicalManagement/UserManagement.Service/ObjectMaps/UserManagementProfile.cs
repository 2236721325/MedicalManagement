using AutoMapper;
using MedicalManagement.Domain.Models;
using UserManagement.Domain.Models;
using UserManagement.Service.Dtos;

namespace UserManagement.Service.ObjectMaps
{
    public class UserManagementProfile : Profile
    {
        public UserManagementProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Permission, PermissionDto>();


        }
    }
}
