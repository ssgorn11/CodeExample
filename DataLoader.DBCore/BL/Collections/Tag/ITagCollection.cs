using DataLoader.Service.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLoader.DBCore.BL
{
    /// <summary>
    /// Интерйефс бизнес объкта работы с ТЭГами
    /// </summary>
    public interface ITagCollection
    {
        Task<IEnumerable<TagDto>> GetTagsAsync();

        /// <summary>
        /// Получить список ТЭГов привязанных к расписанию
        /// </summary>
        /// <param name="idScedule">Ключ расписания</param>
        /// <returns>Список ТЭГов расписания</returns>
        IEnumerable<TagBO> GetTagsBOBySchedule(int idScedule);

        /// <summary>
        /// Асинхронно получить список ТЭГов привязанных к расписанию
        /// </summary>
        /// <param name="idScedule">Ключ расписания</param>
        /// <returns>Список ТЭГов расписания</returns>
        Task<IEnumerable<TagBO>> GetTagsBOByScheduleAsync(int idScedule);

        /// <summary>
        /// Асинхронно получить список ТЭГов привязанных к расписанию
        /// </summary>
        /// <param name="idScedule">Ключ расписания</param>
        /// <returns>Список ТЭГов расписания</returns>
        Task<IEnumerable<ScheduleTagDto>> GetTagsDtoByScheduleAsync(int idScedule);

        Task<IEnumerable<ScheduleTagDto>> GetTagsNotInScheduleAsync(int idScedule);

        Task BoundTagsAsync(int idSchedule, IEnumerable<ScheduleTagDto> tags);

        Task UnBoundTagsAsync(int idSchedule, IEnumerable<ScheduleTagDto> tags);

        Task DeleteAsync(int idTag);
        Task AddAsync(TagDto tagDto);
        Task UpdateAsync(TagDto tagDto);
    }
}
