using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DataLoader.DBCore.DBModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLoader.Service.Contract;

namespace DataLoader.DBCore.BL
{
    /// <summary>
    /// Бизнес объкта работы с расписаниями
    /// </summary>
    internal class ScheduleCollection: IScheduleCollection
    {
        private readonly IScheduleDao _scheduleDao;
        private readonly IMapper _mapper;
        private ITag2ScheduleDao _tag2ScheduleDao;

        /// <summary>
        /// Бизнес объкта работы с расписаниями
        /// </summary>
        /// <param name="scheduleDao">Объект доступа к расписаниям из БД</param>
        /// <param name="mapper">Мапер данных</param>
        public ScheduleCollection(IScheduleDao scheduleDao, IMapper mapper, ITag2ScheduleDao tag2ScheduleDao)
        {
            _scheduleDao = scheduleDao;
            _mapper = mapper;
            _tag2ScheduleDao = tag2ScheduleDao;
        }

        /// <summary>
        /// Асинхронно получить список всех активных расписаний
        /// </summary>
        /// <returns>Список активных расписаний</returns>
        public async Task<IEnumerable<ScheduleBO>> GetActiveSchedulesAsync()
        {
            var scedules = await _scheduleDao.GetSchedules(x => x.IsActive == 1).ToListAsync();
            return scedules.Select(x => _mapper.Map<ScheduleBO>(x));
        }

        /// <summary>
        /// Получить список всех расписаний
        /// </summary>
        /// <returns>Список всех расписаний</returns>
        public async Task<IEnumerable<ScheduleDto>> GetAllSchedulesAsync()
        {
            var res = new List<ScheduleDto>();
            var sceduless = await _scheduleDao.GetSchedules().ToListAsync();
            var schedules = sceduless.Select(x => _mapper.Map<ScheduleBO>(x));
            
            //#region mock
            //schedules = new List<ScheduleBO>() 
            //{ 
            //    new ScheduleBO() { Id = 1, Name = "Test1", TimeStart = new System.DateTime(2000, 1, 1, 0, 0, 0), IsActive = 1, RepeatInterval = 5, RepeatIntervalType = RepeatIntervalType.minutes, BorderSeachInterval = 10, BorderSeachIntervalType = BorderSeachIntervalType.seconds, BorderSeachIntervalDirection = BorderSeachIntervalDirection.all },
            //    new ScheduleBO() { Id = 2, Name = "Test2", TimeStart = new System.DateTime(2000, 1, 1, 2, 0, 0), IsActive = 1, RepeatInterval = 2, RepeatIntervalType = RepeatIntervalType.hours, BorderSeachInterval = 10, BorderSeachIntervalType = BorderSeachIntervalType.seconds, BorderSeachIntervalDirection = BorderSeachIntervalDirection.all }
            //};
            //#endregion mock

            res = schedules.Select(x => _mapper.Map<ScheduleDto>(x)).ToList();

            return res;
        }

        public async Task AddAsync(ScheduleDto scheduleDto)
        {
            await _scheduleDao.AddAsync(_mapper.Map<ScheduleEntity>(_mapper.Map<ScheduleBO>(scheduleDto)));
        }
        public async Task UpdateAsync(ScheduleDto scheduleDto)
        {
            await _scheduleDao.UpdateAsync(_mapper.Map<ScheduleEntity>(_mapper.Map<ScheduleBO>(scheduleDto)));
        }

        public async Task DeleteAsync(int idSchedule)
        {
            await _tag2ScheduleDao.DeleteByScheduleAsync(idSchedule);
            await _scheduleDao.DeleteAsync(idSchedule);
        }

        public async Task<IEnumerable<ScheduleDto>> GetSchedulesByTagAsync(int idTag)
        {
            var t2s = await _tag2ScheduleDao.GetTag2Schedules(x => x.IdTag == idTag).Select(x => _mapper.Map<Tag2ScheduleBO>(x)).ToListAsync();
            var scheIds = t2s.Select(x => x.IdSchedule).Distinct().ToList();
            var scedules = await _scheduleDao.GetSchedules(x => scheIds.Contains(x.Id)).ToListAsync();
            var scedulesBO = scedules.Select(x => _mapper.Map<ScheduleBO>(x)).ToList();

            return scedulesBO.Select(x => _mapper.Map<ScheduleDto>(x));
        }
    }
}
