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
    public class PatientInfoController : ControllerBase, ICrudController<long, PatientInfoDto, PatientInfoUpdateDto, PatientInfoCreateDto>
    {
        private readonly IPatientInfoService _PatientInfoService;

        public PatientInfoController(IPatientInfoService PatientInfoService)
        {
            _PatientInfoService = PatientInfoService;
        }



        [HttpGet("{id}")]
        public async Task<ApiResult<PatientInfoDto>> GetAsync(long id)
        {
            return await _PatientInfoService.GetAsync(id);
        }

        [HttpPost]
        public async Task<ApiResult<PagedListDto<PatientInfoDto>>> GetPagedListAsync(GetPagedListDto getPaged)
        {
            return await _PatientInfoService.GetPagedListAsync(getPaged,"PatientInfos");
        }

        [HttpPost]
        public async Task<ApiResult> InsertAsync(PatientInfoCreateDto dto)
        {
            return await _PatientInfoService.InsertAsync(dto);
        }

        [HttpPut]
        public async Task<ApiResult> UpdateAsync(PatientInfoUpdateDto dto)
        {
            return await _PatientInfoService.UpdateAsync(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> DeleteAsync(long id)
        {
            return await _PatientInfoService.DeleteAsync(id);
        }
    }
}