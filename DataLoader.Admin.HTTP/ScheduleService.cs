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
    public class ScheduleService : BaseService, IScheduleService
    {
        public async Task<IEnumerable<ScheduleDto>> GetAsync()
        {
            return await Url.AppendPathSegment("Schedule/Get")
                .GetJsonAsync<IEnumerable<ScheduleDto>>();
        }

        public async Task AddAsync(ScheduleDto scheduleDto)
        {
            await Url.AppendPathSegment("Schedule/Add")
                .PostJsonAsync(scheduleDto);
        }
        public async Task UpdateAsync(ScheduleDto scheduleDto)
        {
            await Url.AppendPathSegment("Schedule/Update")
                .PutJsonAsync(scheduleDto);
        }
        public async Task DeleteAsync(int idSchedule)
        {
            await Url.AppendPathSegment("Schedule/Delete")
                .SetQueryParam("idSchedule", idSchedule)
                .DeleteAsync();
        }

        public async Task<IEnumerable<ScheduleDto>> GetSchedulesByTagAsync(int idTag)
        {
            return await Url.AppendPathSegment("Schedule/GetByTag")
                .SetQueryParam("idTag", idTag)
                .GetJsonAsync<IEnumerable<ScheduleDto>>();
        }
    }
}
