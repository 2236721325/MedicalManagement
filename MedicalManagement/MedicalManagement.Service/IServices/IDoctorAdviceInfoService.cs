using Base.Shared.IServices;
using MedicalManagement.Service.Dtos;

namespace MedicalManagement.Service.IServices
{
    public interface IDoctorAdviceInfoService : ICrudService<long, DoctorAdviceInfoDto, DoctorAdviceInfoUpdateDto, DoctorAdviceInfoCreateDto>
    {

    }
}