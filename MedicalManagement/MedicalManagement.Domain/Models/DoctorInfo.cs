using Base.Shared.Domains;

namespace MedicalManagement.Domain.Models
{
    //医生:医生ID，姓名，身份证，学历，职称，科室，联系电话和住址。
    public class DoctorInfo : BaseEntity<long>
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
