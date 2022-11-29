using MedicalManagementWPF.Dtos;

namespace MedicalManagementWPF.Dtos
{
    public class PrescriptionInfoDto:BaseEntityDto<long>
    {
        public long DoctorAdviceInfoId { get; set; }
        public long MedicineInfoId { get; set; }

        public long Number { get; set; }
    }
    public class PrescriptionInfoCreateUpdateDto 
    {
        public long DoctorAdviceInfoId { get; set; }
        public long MedicineInfoId { get; set; }

        public long Number { get; set; }
    }
}
