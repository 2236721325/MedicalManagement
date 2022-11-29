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
    public class DoctorInfoService : CrudService<DoctorInfo, long, DoctorInfoDto, DoctorInfoUpdateDto, DoctorInfoCreateDto>, 
        IDoctorInfoService,
        IDependency
    {
        public DoctorInfoService(MyDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<ApiResult>  CanInsertAsync(DoctorInfoCreateDto dto)
        {
            return await Task.FromResult(ApiResult.Ok());
        }

        public override async Task<ApiResult> CanUpdateAsync(DoctorInfoUpdateDto dto)
        {
            return await Task.FromResult(ApiResult.Ok());
        }
    }
}
