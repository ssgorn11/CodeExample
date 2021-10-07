using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLoader.DBCore.BL
{
    /// <summary>
    /// Интерйефс бизнес объкта работы с пересечением ТЭГа и расписания
    /// </summary>
    public interface ITag2ScheduleCollection
    {
        /// <summary>
        /// Получить пересечение ТЭГа и расписания
        /// </summary>
        /// <param name="idTag">Ключ ТЭГа</param>
        /// <param name="idSchedule">Ключ расписания</param>
        /// <returns>Пересечение ТЭГа и расписания</returns>
        Tag2ScheduleBO GetOne(int idTag, int idSchedule);

        IEnumerable<Tag2ScheduleBO> GetBySchedule(int idSchedule);
        Task<IEnumerable<Tag2ScheduleBO>> GetByScheduleAsync(int idSchedule);
    }
}
