using AutoMapper;
using Base.Shared;
using Base.Shared.Dtos;
using Base.Shared.IServices;
using Base.Shared.Services;
using MedicalManagement.Domain.Models;
using MedicalManagement.EntityFramework.Datas;
using MedicalManagement.Service.Dtos;
using MedicalManagement.Service.IServices;

namespace MedicalManagement.Service.Services
{
    public class MedicineInfoService : CrudService<MedicineInfo, long, MedicineInfoDto, MedicineInfoUpdateDto, MedicineInfoCreateDto> ,
        IMedicineInfoService,
        IDependency
    {
        public MedicineInfoService(MyDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<ApiResult> CanInsertAsync(MedicineInfoCreateDto dto)
        {
            return await Task.FromResult(ApiResult.Ok());
        }

        public override async Task<ApiResult> CanUpdateAsync(MedicineInfoUpdateDto dto)
        {
            return await Task.FromResult(ApiResult.Ok());
        }
    }
}
