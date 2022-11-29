using AutoMapper;
using MedicalManagement.Domain.Models;
using MedicalManagement.Service.Dtos;
using UserManagement.Domain.Models;

namespace MedicalManagement.Service.ObjectMaps
{
    public class MedicalManagementProfile : Profile
    {
        public MedicalManagementProfile()
        {

            CreateMap<DoctorInfoCreateDto, DoctorInfo>();
            CreateMap<DoctorInfoUpdateDto, DoctorInfo>();
            CreateMap<DoctorInfo, DoctorInfoDto>();

            CreateMap<DoctorAdviceInfoUpdateDto, DoctorAdviceInfo>();
            CreateMap<DoctorAdviceInfoCreateDto, DoctorAdviceInfo>();
            CreateMap<DoctorAdviceInfo, DoctorAdviceInfoDto>();

            CreateMap<PatientInfoCreateDto, PatientInfo>();
            CreateMap<PatientInfoUpdateDto, PatientInfo>();
            CreateMap<PatientInfo, PatientInfoDto>();

            CreateMap<MedicineInfoCreateDto, MedicineInfo>();
            CreateMap<MedicineInfoUpdateDto, MedicineInfo>();
            CreateMap<MedicineInfo, MedicineInfoDto>();

            CreateMap<PrescriptionInfoCreateDto, PrescriptionInfo>();
            CreateMap<PrescriptionInfoUpdateDto, PrescriptionInfo>();
            CreateMap<PrescriptionInfo, PrescriptionInfoDto>();



        }
    }
}
