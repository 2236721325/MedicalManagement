using Base.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.IControllers
{
    public interface ICrudController<TKey, TEnityDto, TUpdateDto, TCreateDto>
    {
        Task<ApiResult<TEnityDto>> GetAsync(TKey id);
        Task<ApiResult<PagedListDto<TEnityDto>>> GetPagedListAsync(GetPagedListDto getPaged);
        Task<ApiResult> InsertAsync(TCreateDto dto);
        Task<ApiResult> UpdateAsync(TUpdateDto dto);
        Task<ApiResult> DeleteAsync(TKey id);
    }
}
