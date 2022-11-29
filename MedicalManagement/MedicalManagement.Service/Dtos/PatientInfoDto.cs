using Base.Shared.Dtos;
using System.ComponentModel.DataAnnotations;

namespace MedicalManagement.Service.Dtos
{
    public class PatientInfoDto : BaseEntityDto<long>
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Community { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class PatientInfoCreateDto
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Community { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class PatientInfoUpdateDto : BaseEntityDto<long>
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Community { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
