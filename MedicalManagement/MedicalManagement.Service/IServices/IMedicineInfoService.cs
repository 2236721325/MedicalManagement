using Base.Shared.IServices;
using MedicalManagement.Service.Dtos;

namespace MedicalManagement.Service.IServices
{
    public interface IMedicineInfoService : ICrudService<long, MedicineInfoDto, MedicineInfoUpdateDto, MedicineInfoCreateDto>
    {

    }
}