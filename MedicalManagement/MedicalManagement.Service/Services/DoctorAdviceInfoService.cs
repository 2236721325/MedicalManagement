using AutoMapper;
using Base.Shared;
using Base.Shared.Dtos;
using Base.Shared.IServices;
using Base.Shared.Services;
using LinqSharp;
using MedicalManagement.Domain.Models;
using MedicalManagement.EntityFramework.Datas;
using MedicalManagement.Service.Dtos;
using MedicalManagement.Service.IServices;

namespace MedicalManagement.Service.Services
{
    public class DoctorAdviceInfoService : CrudService<DoctorAdviceInfo, long, DoctorAdviceInfoDto, DoctorAdviceInfoUpdateDto, DoctorAdviceInfoCreateDto>,
        IDoctorAdviceInfoService,
        IDependency
    {
        public DoctorAdviceInfoService(MyDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<ApiResult> CanInsertAsync(DoctorAdviceInfoCreateDto dto)
        {
            var e1 = await _DbContext.Set<PatientInfo>().FindAsync(dto.PatientInfoId);
            var e2 = await _DbContext.Set<DoctorInfo>().FindAsync(dto.DoctorInfoId);
            if (e1 != null && e2 != null)
            {
                return ApiResult.Ok();
            }
            return ApiResult.OhNo("外键对应主键不存在");
          
        }

        public override async Task<ApiResult> CanUpdateAsync(DoctorAdviceInfoUpdateDto dto)
        {
            var e1 = await _DbContext.Set<PatientInfo>().FindAsync(dto.PatientInfoId);
            var e2 = await _DbContext.Set<DoctorInfo>().FindAsync(dto.DoctorInfoId);
            if (e1 != null && e2 != null)
            {
                return ApiResult.Ok();
            }
            return ApiResult.OhNo("外键对应主键不存在");
        }
    }
}
