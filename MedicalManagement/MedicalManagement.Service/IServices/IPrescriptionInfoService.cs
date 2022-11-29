using AutoMapper;
using Base.Shared.IServices;
using MedicalManagement.Domain.Models;
using MedicalManagement.Service.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagement.Service.IServices
{
    public interface IPrescriptionInfoService: ICrudService<long, PrescriptionInfoDto, PrescriptionInfoUpdateDto, PrescriptionInfoCreateDto>
    {

    }
}