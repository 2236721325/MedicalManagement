using Base.Shared.IServices;
using MedicalManagement.Service.Dtos;

namespace MedicalManagement.Service.IServices
{
    public interface IPatientInfoService : ICrudService<long, PatientInfoDto, PatientInfoUpdateDto, PatientInfoCreateDto>
    {

    }
}