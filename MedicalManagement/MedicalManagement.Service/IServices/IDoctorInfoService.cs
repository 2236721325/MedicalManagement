using Base.Shared.IServices;
using MedicalManagement.Service.Dtos;

namespace MedicalManagement.Service.IServices
{
    public interface IDoctorInfoService : ICrudService<long, DoctorInfoDto, DoctorInfoUpdateDto, DoctorInfoCreateDto>
    {

    }
}