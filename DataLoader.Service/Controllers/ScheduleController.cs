using DataLoader.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLoader.DBCore;

namespace DataLoader.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : IScheduleService
    {
        private IDBCoreObjectFactory _dBCoreObjectFactory;
        private IScheduleService _scheduleService;

        public ScheduleController(IDBCoreObjectFactory dBCoreObjectFactory)
        {
            _dBCoreObjectFactory = dBCoreObjectFactory;
            _scheduleService = _dBCoreObjectFactory.Resolve<IScheduleService>();
        }

        [HttpGet("Get")]
        public async Task<IEnumerable<ScheduleDto>> GetAsync()
        {
            return await _scheduleService.GetAsync();
        }

        [HttpPost("Add")]
        public async Task AddAsync([FromBody] ScheduleDto scheduleDto)
        {
            await _scheduleService.AddAsync(scheduleDto);
        }

        [HttpPut("Update")]
        public async Task UpdateAsync([FromBody] ScheduleDto scheduleDto)
        {
            await _scheduleService.UpdateAsync(scheduleDto);
        }

        [HttpDelete("Delete")]
        public async Task DeleteAsync([FromQuery(Name = "idSchedule")] int idSchedule)
        {
            await _scheduleService.DeleteAsync(idSchedule);
        }

        [HttpGet("GetByTag")]
        public async Task<IEnumerable<ScheduleDto>> GetSchedulesByTagAsync([FromQuery(Name = "idTag")] int idTag)
        {
            return await _scheduleService.GetSchedulesByTagAsync(idTag);
        }
    }
}
