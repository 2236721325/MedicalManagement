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
    public class PatientInfoService : CrudService<PatientInfo, long, PatientInfoDto, PatientInfoUpdateDto, PatientInfoCreateDto>,
        IPatientInfoService,
        IDependency
    {
        public PatientInfoService(MyDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<ApiResult> CanInsertAsync(PatientInfoCreateDto dto)
        {
            return await Task.FromResult(ApiResult.Ok());
        }

        public override async Task<ApiResult> CanUpdateAsync(PatientInfoUpdateDto dto)
        {
            return await Task.FromResult(ApiResult.Ok());
        }
    }
}
