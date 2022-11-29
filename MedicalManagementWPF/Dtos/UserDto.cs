using MedicalManagementWPF.Dtos;
using System.ComponentModel.DataAnnotations;

namespace MedicalManagementWPF.Dtos
{
    public class UserDto : BaseEntityDto<long>
    {
        public string Name { get; set; }
        public string Account { get; set; }
    }

    public class UserLoginDto
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }
    public class UserRegisteDto
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

    }
}
