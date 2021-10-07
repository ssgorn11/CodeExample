using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLoader.Service.Contract
{
    public interface ITagService
    {
        Task<IEnumerable<TagDto>> GetTagsAsync();

        /// <summary>
        /// Получить список тэгов расписания
        /// </summary>
        /// <param name="idSchedule"></param>
        /// <returns>Список тэгов расписания</returns>
        Task<IEnumerable<ScheduleTagDto>> GetTagsByScheduleAsync(int idSchedule);

        /// <summary>
        /// Получить список ТЭГов не входящих в расписание
        /// </summary>
        /// <param name="idSchedule"></param>
        /// <returns></returns>
        Task<IEnumerable<ScheduleTagDto>> GetTagsNotInScheduleAsync(int idSchedule);

        Task BoundTagsAsync(int idSchedule, IEnumerable<ScheduleTagDto> tags);

        Task UnBoundTagsAsync(int idSchedule, IEnumerable<ScheduleTagDto> tags);
        Task DeleteAsync(int idTag);
        Task AddAsync(TagDto tagDto);
        Task UpdateAsync(TagDto tagDto);
    }
}
