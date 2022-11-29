using MedicalManagementWPF.Dtos;
using System.ComponentModel.DataAnnotations;

namespace MedicalManagementWPF.Dtos
{
    public class PatientInfoDto:BaseEntityDto<long>
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Community { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class PatientInfoCreateUpdateDto 
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Community { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
