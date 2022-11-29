using Base.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Models;

namespace UserManagement.Service.Dtos
{
    public class UserDto:BaseEntityDto<long>
    {
        public string Name { get; set; }
        public string Account { get; set; }
    }
    public class UserRegisteDto
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
    }
    public class UserLoginDto
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }

}
