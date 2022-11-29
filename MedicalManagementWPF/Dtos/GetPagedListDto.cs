using System.ComponentModel.DataAnnotations;

namespace MedicalManagementWPF.Dtos;

public class GetPagedListDto
{
    [Range(0, int.MaxValue, ErrorMessage = "不能是负数！")]
    public int SkipCount { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "不能是负数！")]
    public int TakeCount { get; set; }
}

