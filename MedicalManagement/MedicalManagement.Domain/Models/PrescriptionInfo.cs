using Base.Shared.Domains;

namespace MedicalManagement.Domain.Models
{
    //处方:医嘱ID,药品ID,数量
    public class PrescriptionInfo : BaseEntity<long>
    {
        public long DoctorAdviceInfoId { get; set; }
        public DoctorAdviceInfo DoctorAdviceInfo { get; set; }
        public long MedicineInfoId { get; set; }
        public MedicineInfo MedicineInfo { get; set; }

        public long Number { get; set; }

    }
}
