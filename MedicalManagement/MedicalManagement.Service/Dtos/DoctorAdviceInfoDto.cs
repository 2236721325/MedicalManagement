
using Base.Shared.Dtos;

namespace MedicalManagement.Service.Dtos
{
    public class DoctorAdviceInfoDto : BaseEntityDto<long>
    {
        public DateTimeOffset CreateDate { get; set; }
        public long DoctorInfoId { get; set; }

        public long PatientInfoId { get; set; }

        public string RecordContent { get; set; }
    }
    public class DoctorAdviceInfoCreateDto
    {
        public DateTimeOffset? CreateDate { get; set; }=DateTimeOffset.Now;

        public long DoctorInfoId { get; set; }

        public long PatientInfoId { get; set; }

        public string RecordContent { get; set; }
    }
    public class DoctorAdviceInfoUpdateDto: BaseEntityDto<long>
    {
        public DateTimeOffset CreateDate { get; set; }

        public long DoctorInfoId { get; set; }

        public long PatientInfoId { get; set; }

        public string RecordContent { get; set; }
    }
}
