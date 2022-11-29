
using Base.Shared.Dtos;

namespace MedicalManagement.Service.Dtos
{
    public class PrescriptionInfoDto : BaseEntityDto<long>
    {
        public long DoctorAdviceInfoId { get; set; }
        public long MedicineInfoId { get; set; }

        public long Number { get; set; }
    }
    public class PrescriptionInfoCreateDto
    {
        public long DoctorAdviceInfoId { get; set; }
        public long MedicineInfoId { get; set; }

        public long Number { get; set; }
    }
    public class PrescriptionInfoUpdateDto : BaseEntityDto<long>
    {
        public long DoctorAdviceInfoId { get; set; }
        public long MedicineInfoId { get; set; }

        public long Number { get; set; }
    }
}
