using Base.Shared.Domains;

namespace MedicalManagement.Domain.Models
{
    //医嘱:医嘱ID,日期，医生ID,病人ID,遗属记录。
    public class DoctorAdviceInfo : BaseEntity<long>
    {
        public DateTimeOffset CreateDate { get; set; }
        public long DoctorInfoId { get; set; }
        public DoctorInfo DoctorInfo { get; set; }

        public long PatientInfoId { get; set; }
        public PatientInfo PatientInfo { get; set; }

        public string RecordContent { get; set; }

        public void SetDateTime()
        {
            CreateDate = DateTimeOffset.Now;
        }
    }
}
