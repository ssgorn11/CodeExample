using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Интерфейс работы с БД для заданной реализации BaseEntity
    /// </summary>
    /// <typeparam name="TData">класс модели БД - наследник BaseEntity</typeparam>
    internal interface IDao<TData> where TData : BaseEntity
    {
        /// <summary>
        /// Получить наследник BaseEntity по ключу
        /// </summary>
        /// <param name="id">Ключ</param>
        /// <returns>Найденный экземпляр наследника BaseEntity</returns>
        TData Get(int id);

        /// <summary>
        /// Получить наследник BaseEntity по ключу без отслеживания изменений модели
        /// </summary>
        /// <param name="id">Ключ</param>
        /// <returns>Найденный экземпляр наследника BaseEntity</returns>
        TData Get_NoTracking(int id);

        /// <summary>
        /// Получить наследник BaseEntity по условию
        /// </summary>
        /// <param name="condition">Условие поиска</param>
        /// <returns>Найденный список наследников BaseEntity</returns>
        IQueryable<TData> Get(Expression<Func<TData, bool>> condition = null);

        /// <summary>
        /// Получить наследник BaseEntity по условию без отслеживания изменений модели
        /// </summary>
        /// <param name="condition">Условие поиска</param>
        /// <returns>Найденный список наследников BaseEntity</returns>
        IQueryable<TData> Get_NoTracking(Expression<Func<TData, bool>> condition = null);

        /// <summary>
        /// Добавить новый объект наследник BaseEntity в БД
        /// </summary>
        /// <param name="entity">Наследник BaseEntity</param>
        void Create(TData entity);

        /// <summary>
        /// Асинхронно добавить новый объект наследник BaseEntity в БД
        /// </summary>
        /// <param name="entity">Наследник BaseEntity</param>
        /// <param name="token">Токен отмены</param>
        Task CreateAsync(TData entity, CancellationToken token = default);

        /// <summary>
        /// Добавить группу объектов наследников BaseEntity в БД
        /// </summary>
        /// <param name="range">Группа объектов наследников BaseEntity</param>
        void CreateRange(IEnumerable<TData> range);

        /// <summary>
        /// Асинхронно добавить группу объектов наследников BaseEntity в БД
        /// </summary>
        /// <param name="range">Группа объектов наследников BaseEntity</param>
        /// <param name="token">Токен отмены</param>
        Task CreateRangeAsync(IEnumerable<TData> range, CancellationToken token = default);

        /// <summary>
        /// Обноить объект наследник BaseEntity в БД
        /// </summary>
        /// <param name="entity">Наследник BaseEntity</param>
        void Update(TData entity);

        /// <summary>
        /// Асинхронно обноить объект наследник BaseEntity в БД
        /// </summary>
        /// <param name="entity">Наследник BaseEntity</param>
        /// <param name="token">Токен отмены</param>
        Task UpdateAsync(TData entity, CancellationToken token = default);

        /// <summary>
        /// Обновить группу объектов наследников BaseEntity в БД
        /// </summary>
        /// <param name="entities">Группа объектов наследников BaseEntity</param>
        void UpdateRange(IEnumerable<TData> entities);

        /// <summary>
        /// Асинхронно обновить группу объектов наследников BaseEntity в БД
        /// </summary>
        /// <param name="entities">Группа объектов наследников BaseEntity</param>
        /// <param name="token">Токен отмены</param>
        Task UpdateRangeAsync(IEnumerable<TData> entities, CancellationToken token = default);

        /// <summary>
        /// Удалить объект из БД
        /// </summary>
        /// <param name="id">Ключ</param>
        void Delete(int id);

        /// <summary>
        /// Асинхронно удалить объект из БД
        /// </summary>
        /// <param name="id">Ключ</param>
        /// <param name="token">Токен отмены</param>
        Task DeleteAsync(int id, CancellationToken token = default);

        /// <summary>
        /// Удалить объекты из БД
        /// </summary>
        /// <param name="condition">Условие удаления</param>
        void Delete(Expression<Func<TData, bool>> condition);

        /// <summary>
        /// Асинхронно удалить объекты из БД
        /// </summary>
        /// <param name="condition">Условие удаления</param>
        /// <param name="token">Токен отмены</param>
        Task DeleteAsync(Expression<Func<TData, bool>> condition, CancellationToken token = default);
    }
}
