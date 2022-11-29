using Base.Shared.Domains;

namespace MedicalManagement.Domain.Models
{
    //病人:病人ID,姓名，单位，社区，住址，联系电话。
    public class PatientInfo : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Community { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}
