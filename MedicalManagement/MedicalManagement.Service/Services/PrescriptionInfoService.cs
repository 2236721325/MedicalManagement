using AutoMapper;
using Base.Shared;
using Base.Shared.Dtos;
using Base.Shared.IServices;
using Base.Shared.Services;
using MedicalManagement.Domain.Models;
using MedicalManagement.EntityFramework.Datas;
using MedicalManagement.Service.Dtos;
using MedicalManagement.Service.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagement.Service.Services
{
    public class PrescriptionInfoService : CrudService<PrescriptionInfo, long, PrescriptionInfoDto, PrescriptionInfoUpdateDto, PrescriptionInfoCreateDto>,
        IPrescriptionInfoService,
        IDependency
    {
        public PrescriptionInfoService(MyDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public override async Task<ApiResult> CanInsertAsync(PrescriptionInfoCreateDto dto)
        {
            var e1 = await _DbContext.Set<DoctorAdviceInfo>().FindAsync(dto.DoctorAdviceInfoId);
            var e2 = await _DbContext.Set<MedicineInfo>().FindAsync(dto.MedicineInfoId);
            if (e1 != null && e2 != null)
            {
                return ApiResult.Ok();
            }
            return ApiResult.OhNo("外键对应主键不存在");
        }

        public override async Task<ApiResult> CanUpdateAsync(PrescriptionInfoUpdateDto dto)
        {
            var e1 = await _DbContext.Set<DoctorAdviceInfo>().FindAsync(dto.DoctorAdviceInfoId);
            var e2 = await _DbContext.Set<MedicineInfo>().FindAsync(dto.MedicineInfoId);
            if (e1 != null && e2 != null)
            {
                return ApiResult.Ok();
            }
            return ApiResult.OhNo("外键对应主键不存在");
        }
    }
}
