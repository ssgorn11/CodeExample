using DataLoader.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLoader.DBCore;

namespace DataLoader.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ITagService
    {
        private IDBCoreObjectFactory _dBCoreObjectFactory;
        private ITagService _tagService;

        public TagController(IDBCoreObjectFactory dBCoreObjectFactory)
        {
            _dBCoreObjectFactory = dBCoreObjectFactory;
            _tagService = _dBCoreObjectFactory.Resolve<ITagService>();
        }

        [HttpGet("Get")]
        public async Task<IEnumerable<TagDto>> GetTagsAsync()
        {
            return await _tagService.GetTagsAsync();
        }

        [HttpGet("GetBySchedule")]
        public async Task<IEnumerable<ScheduleTagDto>> GetTagsByScheduleAsync([FromQuery(Name = "idSchedule")] int idSchedule)
        {
            return await _tagService.GetTagsByScheduleAsync(idSchedule);
        }

        [HttpGet("GetNotInSchedule")]
        public async Task<IEnumerable<ScheduleTagDto>> GetTagsNotInScheduleAsync([FromQuery(Name = "idSchedule")] int idSchedule)
        {
            return await _tagService.GetTagsNotInScheduleAsync(idSchedule);
        }

        [HttpPost("BoundTags")]
        public async Task BoundTagsAsync([FromQuery(Name = "idSchedule")] int idSchedule, [FromBody] IEnumerable<ScheduleTagDto> tags)
        {
            await _tagService.BoundTagsAsync(idSchedule, tags);
        }

        [HttpPost("UnBoundTags")]
        public async Task UnBoundTagsAsync([FromQuery(Name = "idSchedule")] int idSchedule, [FromBody] IEnumerable<ScheduleTagDto> tags)
        {
            await _tagService.UnBoundTagsAsync(idSchedule, tags);
        }

        [HttpDelete("Delete")]
        public async Task DeleteAsync(int idTag)
        {
            await _tagService.DeleteAsync(idTag);
        }

        [HttpPost("Add")]
        public async Task AddAsync(TagDto tagDto)
        {
            await _tagService.AddAsync(tagDto);
        }

        [HttpPut("Update")]
        public async Task UpdateAsync(TagDto tagDto)
        {
            await _tagService.UpdateAsync(tagDto);
        }
    }
}
