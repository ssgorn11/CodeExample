using DataLoader.DBCore.BL;
using DataLoader.Service.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLoader.DBCore.DTS
{
    internal class TagService : ITagService
    {
        private readonly ITagCollection _tagCollection;

        public TagService(ITagCollection tagCollection)
        {
            _tagCollection = tagCollection;
        }

        public async Task<IEnumerable<TagDto>> GetTagsAsync()
        {
            return await _tagCollection.GetTagsAsync();
        }

        /// <summary>
        /// Получить список всех расписаний
        /// </summary>
        /// <returns>Список всех расписаний</returns>
        public async Task<IEnumerable<ScheduleTagDto>> GetTagsByScheduleAsync(int idSchedule)
        {
            return await _tagCollection.GetTagsDtoByScheduleAsync(idSchedule);
        }

        public async Task<IEnumerable<ScheduleTagDto>> GetTagsNotInScheduleAsync(int idSchedule)
        {
            return await _tagCollection.GetTagsNotInScheduleAsync(idSchedule);
        }

        public async Task BoundTagsAsync(int idSchedule, IEnumerable<ScheduleTagDto> tags)
        {
            await _tagCollection.BoundTagsAsync(idSchedule, tags);
        }

        public async Task UnBoundTagsAsync(int idSchedule, IEnumerable<ScheduleTagDto> tags)
        {
            await _tagCollection.UnBoundTagsAsync(idSchedule, tags);
        }

        public async Task DeleteAsync(int idTag)
        {
            await _tagCollection.DeleteAsync(idTag);
        }

        public async Task AddAsync(TagDto tagDto)
        {
            await _tagCollection.AddAsync(tagDto);
        }

        public async Task UpdateAsync(TagDto tagDto)
        {
            await _tagCollection.UpdateAsync(tagDto);
        }
    }
}
