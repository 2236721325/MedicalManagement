using AutoMapper;
using Base.Shared.Dtos;
using Base.Shared.IControllers;
using MedicalManagement.Domain.Models;
using MedicalManagement.Service.Dtos;
using MedicalManagement.Service.IServices;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace MedicalManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DoctorAdviceInfoController : ControllerBase,ICrudController<long,DoctorAdviceInfoDto,DoctorAdviceInfoUpdateDto,DoctorAdviceInfoCreateDto>
    {
        private readonly IDoctorAdviceInfoService _DoctorAdviceInfoService;

        public DoctorAdviceInfoController(IDoctorAdviceInfoService doctorAdviceInfoService)
        {
            _DoctorAdviceInfoService = doctorAdviceInfoService;
        }

      

        [HttpGet("{id}")]
        public async Task<ApiResult<DoctorAdviceInfoDto>> GetAsync(long id)
        {
            return await _DoctorAdviceInfoService.GetAsync(id);
        }

        [HttpPost]
        public async Task<ApiResult<PagedListDto<DoctorAdviceInfoDto>>> GetPagedListAsync(GetPagedListDto getPaged)
        {
            return await _DoctorAdviceInfoService.GetPagedListAsync(getPaged,"DoctorAdviceInfos");
        }

        [HttpPost]
        public async Task<ApiResult> InsertAsync(DoctorAdviceInfoCreateDto dto)
        {
            return await _DoctorAdviceInfoService.InsertAsync(dto);
        }

        [HttpPut]
        public async Task<ApiResult> UpdateAsync(DoctorAdviceInfoUpdateDto dto)
        {
            return await _DoctorAdviceInfoService.UpdateAsync(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> DeleteAsync(long id)
        {
            return await _DoctorAdviceInfoService.DeleteAsync(id);
        }
    }
}