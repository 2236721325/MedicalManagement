using Base.Shared.Dtos;

namespace MedicalManagement.Service.Dtos
{
    public class DoctorInfoDto : BaseEntityDto<long>
    {
        public string Name { get; set; }
        public string IdCard { get; set; }
        public string EducationalBackground { get; set; }
        public string ProfessionalTitle { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
    public class DoctorInfoCreateDto
    {
        public string Name { get; set; }
        public string IdCard { get; set; }
        public string EducationalBackground { get; set; }
        public string ProfessionalTitle { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
    public class DoctorInfoUpdateDto : BaseEntityDto<long>
    {
        public string Name { get; set; }
        public string IdCard { get; set; }
        public string EducationalBackground { get; set; }
        public string ProfessionalTitle { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
