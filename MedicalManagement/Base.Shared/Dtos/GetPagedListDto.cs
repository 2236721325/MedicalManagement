using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Base.Shared.Dtos
{
    public class GetPagedListDto
    {
        [Range(0, int.MaxValue, ErrorMessage = "不能是负数！")]
        public int SkipCount { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "不能是负数！")]
        public int TakeCount { get; set; }
        public Dictionary<string, JsonElement>? Searchs { get; set; }
    }
}
