using DataLoader.Service.Contract;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader.Admin.HTTP
{
    public class TagService : BaseService, ITagService
    {
        public async Task<IEnumerable<TagDto>> GetTagsAsync()
        {
            return await Url.AppendPathSegment("Tag/Get")
                .GetJsonAsync<IEnumerable<TagDto>>();
        }

        public async Task<IEnumerable<ScheduleTagDto>> GetTagsByScheduleAsync(int idSchedule)
        {
            return await Url.AppendPathSegment("Tag/GetBySchedule")
                .SetQueryParam("idSchedule", idSchedule)
                .GetJsonAsync<IEnumerable<ScheduleTagDto>>();
        }

        public async Task<IEnumerable<ScheduleTagDto>> GetTagsNotInScheduleAsync(int idSchedule)
        {
            return await Url.AppendPathSegment("Tag/GetNotInSchedule")
                .SetQueryParam("idSchedule", idSchedule)
                .GetJsonAsync<IEnumerable<ScheduleTagDto>>();
        }

        public async Task BoundTagsAsync(int idSchedule, IEnumerable<ScheduleTagDto> tags)
        {
            await Url.AppendPathSegment("Tag/BoundTags")
                .SetQueryParam("idSchedule", idSchedule)
                .PostJsonAsync(tags);
        }

        public async Task UnBoundTagsAsync(int idSchedule, IEnumerable<ScheduleTagDto> tags)
        {
            await Url.AppendPathSegment("Tag/UnBoundTags")
                .SetQueryParam("idSchedule", idSchedule)
                .PostJsonAsync(tags);
        }

        public async Task DeleteAsync(int idTag)
        {
            await Url.AppendPathSegment("Tag/Delete")
                .SetQueryParam("idTag", idTag)
                .DeleteAsync();
        }

        public async Task AddAsync(TagDto tagDto)
        {
            await Url.AppendPathSegment("Tag/Add")
                .PostJsonAsync(tagDto);
        }
        public async Task UpdateAsync(TagDto tagDto)
        {
            await Url.AppendPathSegment("Tag/Update")
                .PutJsonAsync(tagDto);
        }
    }
}
