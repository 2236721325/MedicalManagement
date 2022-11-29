using MedicalManagementWPF.Dtos;
using System;

namespace MedicalManagementWPF.Dtos
{
    public class DoctorAdviceInfoDto:BaseEntityDto<long>
    {
        public DateTimeOffset CreateDate { get; set; }
        public long DoctorInfoId { get; set; }

        public long PatientInfoId { get; set; }

        public string RecordContent { get; set; }
    }
    public class DoctorAdviceInfoCreateUpdateDto
    {
        public long DoctorInfoId { get; set; }

        public long PatientInfoId { get; set; }

        public string RecordContent { get; set; }
    }
}
