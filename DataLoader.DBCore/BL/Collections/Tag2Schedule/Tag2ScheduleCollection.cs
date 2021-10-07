using AutoMapper;
using DataLoader.DBCore.DBModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLoader.DBCore.BL
{
    /// <summary>
    /// Бизнес объкт работы с пересечением ТЭГа и расписания
    /// </summary>
    internal class Tag2ScheduleCollection: ITag2ScheduleCollection
    {
        private ITag2ScheduleDao _tag2ScheduleDao;
        private IMapper _mapper;

        /// <summary>
        /// Бизнес объкта работы с расписаниями
        /// </summary>
        /// <param name="scheduleDao">Объект доступа к расписаниям из БД</param>
        /// <param name="mapper">Мапер данных</param>
        public Tag2ScheduleCollection(ITag2ScheduleDao tag2ScheduleDao, IMapper mapper)
        {
            _tag2ScheduleDao = tag2ScheduleDao;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить пересечение ТЭГа и расписания
        /// </summary>
        /// <param name="idTag">Ключ ТЭГа</param>
        /// <param name="idSchedule">Ключ расписания</param>
        /// <returns>Пересечение ТЭГа и расписания</returns>
        public Tag2ScheduleBO GetOne(int idTag, int idSchedule)
        {
            var t2s = _tag2ScheduleDao.GetTag2Schedules(x => x.IdTag == idTag && x.IdSchedule == idSchedule).FirstOrDefault();
            return _mapper.Map<Tag2ScheduleBO>(t2s);
        }

        public IEnumerable<Tag2ScheduleBO> GetBySchedule(int idSchedule)
        {
            var t2s = _tag2ScheduleDao.GetTag2Schedules(x => x.IdSchedule == idSchedule);
            return t2s.Select(x => _mapper.Map<Tag2ScheduleBO>(x));
        }

        public async Task<IEnumerable<Tag2ScheduleBO>> GetByScheduleAsync(int idSchedule)
        {
            var t2s = await _tag2ScheduleDao.GetTag2Schedules(x => x.IdSchedule == idSchedule).ToListAsync();
            return t2s.Select(x => _mapper.Map<Tag2ScheduleBO>(x));
        }
    }
}
