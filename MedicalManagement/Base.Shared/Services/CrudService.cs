using AutoMapper;
using Base.Shared.Commons;
using Base.Shared.Domains;
using Base.Shared.Dtos;
using Base.Shared.IServices;
using LinqSharp;
using LinqSharp.EFCore;
using Microsoft.EntityFrameworkCore;
using NStandard;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Base.Shared.Services
{
    public abstract class CrudService<TEnity, TKey, TEnityDto, TUpdateDto, TCreateDto> :
        ICrudService<TKey, TEnityDto, TUpdateDto, TCreateDto> where TEnity : BaseEntity<TKey>
    {
        public DbContext _DbContext { get; set; }
        public DbSet<TEnity> _Enitity { get; set; }
        public  IMapper _Mapper { get; set; }

        public CrudService(DbContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _Enitity = dbContext.Set<TEnity>();
            _Mapper = mapper;
        }

      
        

        public async virtual Task<ApiResult> DeleteAsync(TKey id)
        {
            var e = await _Enitity.FindAsync(id);
            if (e == null) return ApiResult.OhNo("Id不存在！");
            _Enitity.Remove(e);
            await _DbContext.SaveChangesAsync();
            return ApiResult.Ok();

        }

        public async virtual Task<ApiResult<TEnityDto>> GetAsync(TKey id)
        {
            var e = await _Enitity.FindAsync(id);
            if (e == null) return ApiResult.OhNo <TEnityDto> ("Id不存在！");
            return ApiResult.Ok(_Mapper.Map<TEnity, TEnityDto>(e));
        }

        public async virtual Task<ApiResult<PagedListDto<TEnityDto>>> GetPagedListAsync(GetPagedListDto getPaged,string tableName)
        {
            var query = _Enitity.AsQueryable();
            if(getPaged.Searchs!=null&&getPaged.Searchs.Count>0)
            {

                var sql = @$"select * from {tableName} Where ";
                int k = 0;
                
                foreach (var item in getPaged.Searchs)
                {
                    
                    k++;
                    if (item.Value.ValueKind==JsonValueKind.String)
                    {
                        sql += $"{item.Key} LIKE\"%{item.Value}%\" ";
                    }
                    else 
                    {
                        sql += $"{item.Key}={item.Value} ";
                    }
                    if (k != getPaged.Searchs.Count)
                    {
                        sql += "And ";
                    }
                }

                query = _Enitity.FromSqlRaw(sql);

            }


            //if (getPaged.Searchs != null)
            //{
            //    query = _Enitity.Filter(h =>
            //    {
                  
            //        return h.And(getPaged.Searchs, s => h.Property(s.Key).Contains(s.Value));
                    
            //    });
            //}
            //_DbContext.Database.ExecuteSqlRawAsync
            //var p = _Enitity.XWhere(h =>
            //{
            //    var exp = h.CreateEmpty();
            //    foreach (var s in searches)
            //    {
            //        exp |= h.Where(x => x.TitleOfCourtesy == s.Item1 && x.City == s.Item2);
            //    }
            //    return exp;
            //});


            var count =await query.LongCountAsync();
            var enities=await query.OrderBy(e=>e.Id).Skip(getPaged.SkipCount).Take(getPaged.TakeCount).ToListAsync();
            var dtos = _Mapper.Map<List<TEnity>, List<TEnityDto>>(enities);
            return ApiResult.Ok(new PagedListDto<TEnityDto>(dtos, count));
        }

        public abstract  Task<ApiResult> CanInsertAsync(TCreateDto dto);
      
        public async virtual Task<ApiResult> InsertAsync(TCreateDto dto)
        {
            var r=await CanInsertAsync(dto);
            if (r.Status == false) return r;
            var entity=_Mapper.Map<TCreateDto, TEnity>(dto);
            await _Enitity.AddAsync(entity);
            await _DbContext.SaveChangesAsync();
            return ApiResult.Ok();
        }

        public async virtual Task<ApiResult> UpdateAsync(TUpdateDto dto)
        {
            var r = await CanUpdateAsync(dto);
            if (r.Status == false) return r;
            var entity = _Mapper.Map<TUpdateDto, TEnity>(dto);
            _Enitity.Update(entity);
            await _DbContext.SaveChangesAsync();
            return ApiResult.Ok();
        }



        public abstract Task<ApiResult> CanUpdateAsync(TUpdateDto dto);
        
    }
}
