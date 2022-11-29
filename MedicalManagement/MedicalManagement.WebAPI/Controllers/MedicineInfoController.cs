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
    public class MedicineInfoController : ControllerBase, ICrudController<long, MedicineInfoDto, MedicineInfoUpdateDto, MedicineInfoCreateDto>
    {
        private readonly IMedicineInfoService _MedicineInfoService;

        public MedicineInfoController(IMedicineInfoService MedicineInfoService)
        {
            _MedicineInfoService = MedicineInfoService;
        }



        [HttpGet("{id}")]
        public async Task<ApiResult<MedicineInfoDto>> GetAsync(long id)
        {
            return await _MedicineInfoService.GetAsync(id);
        }

        [HttpPost]
        public async Task<ApiResult<PagedListDto<MedicineInfoDto>>> GetPagedListAsync(GetPagedListDto getPaged)
        {
            return await _MedicineInfoService.GetPagedListAsync(getPaged,"MedicineInfos");
        }

        [HttpPost]
        public async Task<ApiResult> InsertAsync(MedicineInfoCreateDto dto)
        {
            return await _MedicineInfoService.InsertAsync(dto);
        }

        [HttpPut]
        public async Task<ApiResult> UpdateAsync(MedicineInfoUpdateDto dto)
        {
            return await _MedicineInfoService.UpdateAsync(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> DeleteAsync(long id)
        {
            return await _MedicineInfoService.DeleteAsync(id);
        }
    }
}