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
    public class PrescriptionInfoController : ControllerBase, ICrudController<long, PrescriptionInfoDto, PrescriptionInfoUpdateDto, PrescriptionInfoCreateDto>
    {
        private readonly IPrescriptionInfoService _PrescriptionInfoService;

        public PrescriptionInfoController(IPrescriptionInfoService PrescriptionInfoService)
        {
            _PrescriptionInfoService = PrescriptionInfoService;
        }



        [HttpGet("{id}")]
        public async Task<ApiResult<PrescriptionInfoDto>> GetAsync(long id)
        {
            return await _PrescriptionInfoService.GetAsync(id);
        }

        [HttpPost]
        public async Task<ApiResult<PagedListDto<PrescriptionInfoDto>>> GetPagedListAsync(GetPagedListDto getPaged)
        {
            return await _PrescriptionInfoService.GetPagedListAsync(getPaged,"PrescriptionInfos");
        }

        [HttpPost]
        public async Task<ApiResult> InsertAsync(PrescriptionInfoCreateDto dto)
        {
            return await _PrescriptionInfoService.InsertAsync(dto);
        }

        [HttpPut]
        public async Task<ApiResult> UpdateAsync(PrescriptionInfoUpdateDto dto)
        {
            return await _PrescriptionInfoService.UpdateAsync(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> DeleteAsync(long id)
        {
            return await _PrescriptionInfoService.DeleteAsync(id);
        }
    }
}