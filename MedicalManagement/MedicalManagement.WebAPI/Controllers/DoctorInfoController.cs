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
    public class DoctorInfoController : ControllerBase, ICrudController<long, DoctorInfoDto, DoctorInfoUpdateDto, DoctorInfoCreateDto>
    {
        private readonly IDoctorInfoService _DoctorInfoService;

        public DoctorInfoController(IDoctorInfoService DoctorInfoService)
        {
            _DoctorInfoService = DoctorInfoService;
        }



        [HttpGet("{id}")]
        public async Task<ApiResult<DoctorInfoDto>> GetAsync(long id)
        {
            return await _DoctorInfoService.GetAsync(id);
        }

        [HttpPost]
        public async Task<ApiResult<PagedListDto<DoctorInfoDto>>> GetPagedListAsync(GetPagedListDto getPaged)
        {
            return await _DoctorInfoService.GetPagedListAsync(getPaged,"DoctorInfos");
        }

        [HttpPost]
        public async Task<ApiResult> InsertAsync(DoctorInfoCreateDto dto)
        {
            return await _DoctorInfoService.InsertAsync(dto);
        }

        [HttpPut]
        public async Task<ApiResult> UpdateAsync(DoctorInfoUpdateDto dto)
        {
            return await _DoctorInfoService.UpdateAsync(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> DeleteAsync(long id)
        {
            return await _DoctorInfoService.DeleteAsync(id);
        }
    }
}