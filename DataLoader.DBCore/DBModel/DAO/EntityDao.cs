using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Базовые меоды работы с БД для заданной реализации BaseEntity
    /// </summary>
    /// <typeparam name="TData">Класс модели БД - BaseEntity</typeparam>
    internal class EntityDao<TData> : BaseDao, IDao<TData> where TData : BaseEntity
    {
        public EntityDao(IDataSource dataSource) : base(dataSource)
        { }

        /// <summary>
        /// Получить наследник BaseEntity по ключу
        /// </summary>
        /// <param name="id">Ключ</param>
        /// <returns>Найденный экземпляр наследника BaseEntity</returns>
        public virtual TData Get(int id)
        {
            return ReadContext(db => { return db.Set<TData>().Where(x => x.Id.Equals(id)).FirstOrDefault(); });
        }

        /// <summary>
        /// Получить наследник BaseEntity по ключу без отслеживания изменений модели
        /// </summary>
        /// <param name="id">Ключ</param>
        /// <returns>Найденный экземпляр наследника BaseEntity</returns>
        public virtual TData Get_NoTracking(int id)
        {
            return ReadContext(db => { return db.Set<TData>().AsNoTracking().Where(x => x.Id.Equals(id)).FirstOrDefault(); });
        }

        /// <summary>
        /// Получить наследник BaseEntity по условию
        /// </summary>
        /// <param name="condition">Условие поиска</param>
        /// <returns>Найденный список наследников BaseEntity</returns>
        public virtual IQueryable<TData> Get(Expression<Func<TData, bool>> condition = null)
        {
            return ReadContext(db =>
            {
                var set = condition == null ? db.Set<TData>() : db.Set<TData>().Where(condition);
                return set;
            });
        }

        /// <summary>
        /// Получить наследник BaseEntity по условию без отслеживания изменений модели
        /// </summary>
        /// <param name="condition">Условие поиска</param>
        /// <returns>Найденный список наследников BaseEntity</returns>
        public virtual IQueryable<TData> Get_NoTracking(Expression<Func<TData, bool>> condition = null)
        {
            return ReadContext(db =>
            {
                var set = condition == null ? db.Set<TData>().AsNoTracking() : db.Set<TData>().AsNoTracking().Where(condition);
                return set;
            });
        }

        /// <summary>
        /// Добавить новый объект наследник BaseEntity в БД
        /// </summary>
        /// <param name="entity">Наследник BaseEntity</param>
        public virtual void Create(TData entity)
        {
            if (entity == null) return;
            UpdateContext(db => db.Add(entity));
        }

        /// <summary>
        /// Асинхронно добавить новый объект наследник BaseEntity в БД
        /// </summary>
        /// <param name="entity">Наследник BaseEntity</param>
        /// <param name="token">Токен отмены</param>
        public virtual async Task CreateAsync(TData entity, CancellationToken token = default)
        {
            if (entity == null) return;
            await UpdateContextAsync(db => db.AddAsync(entity, token).AsTask());
        }

        /// <summary>
        /// Добавить группу объектов наследников BaseEntity в БД
        /// </summary>
        /// <param name="range">Группа объектов наследников BaseEntity</param>
        public virtual void CreateRange(IEnumerable<TData> entities)
        {
            if (entities == null) return;
            UpdateContext(db => db.AddRange(entities));
        }
        /// <summary>
        /// Асинхронно добавить группу объектов наследников BaseEntity в БД
        /// </summary>
        /// <param name="range">Группа объектов наследников BaseEntity</param>
        /// <param name="token">Токен отмены</param>
        public virtual async Task CreateRangeAsync(IEnumerable<TData> entities, CancellationToken token = default)
        {
            if (entities == null) return;
            await UpdateContextAsync(db => db.AddRangeAsync(entities, token));
        }

        /// <summary>
        /// Обноить объект наследник BaseEntity в БД
        /// </summary>
        /// <param name="entity">Наследник BaseEntity</param>
        public virtual void Update(TData data)
        {
            UpdateContext(x => x.Update(data));
        }

        /// <summary>
        /// Асинхронно обноить объект наследник BaseEntity в БД
        /// </summary>
        /// <param name="entity">Наследник BaseEntity</param>
        /// <param name="token">Токен отмены</param>
        public virtual async Task UpdateAsync(TData data, CancellationToken token = default)
        {
            await UpdateContextAsync(async x => await Task.Run(() => x.Update(data), token).ConfigureAwait(false));
        }

        /// <summary>
        /// Обновить группу объектов наследников BaseEntity в БД
        /// </summary>
        /// <param name="entities">Группа объектов наследников BaseEntity</param>
        public virtual void UpdateRange(IEnumerable<TData> entities)
        {
            if (entities == null) return;
            UpdateContext(x => x.UpdateRange(entities));
        }

        /// <summary>
        /// Асинхронно обновить группу объектов наследников BaseEntity в БД
        /// </summary>
        /// <param name="entities">Группа объектов наследников BaseEntity</param>
        /// <param name="token">Токен отмены</param>
        public virtual async Task UpdateRangeAsync(IEnumerable<TData> entities, CancellationToken token = default)
        {
            if (entities == null) return;
            await UpdateContextAsync(async x => await Task.Run(() => x.UpdateRange(entities), token).ConfigureAwait(false));
        }

        /// <summary>
        /// Удалить объект из БД
        /// </summary>
        /// <param name="id">Ключ</param>
        public virtual void Delete(int id)
        {
            UpdateContext(db =>
            {
                var entity = db.Set<TData>().Find(id);
                if (entity != null) db.Remove(entity);
            });
        }

        /// <summary>
        /// Асинхронно удалить объект из БД
        /// </summary>
        /// <param name="id">Ключ</param>
        /// <param name="token">Токен отмены</param>
        public virtual async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await UpdateContextAsync(async (db) =>
            {
                var entity = await db.Set<TData>().FindAsync(id, token);
                if (entity != null) 
                    await Task.Run(() => db.Remove(entity), token).ConfigureAwait(false);
            });
        }

        /// <summary>
        /// Удалить объекты из БД
        /// </summary>
        /// <param name="condition">Условие удаления</param>
        public virtual void Delete(Expression<Func<TData, bool>> condition)
        {
            UpdateContext(db =>
            {
                var entity = db.Set<TData>().Find(condition);
                db.RemoveRange(entity);
            });
        }

        /// <summary>
        /// Асинхронно удалить объекты из БД
        /// </summary>
        /// <param name="condition">Условие удаления</param>
        /// <param name="token">Токен отмены</param>
        public virtual async Task DeleteAsync(Expression<Func<TData, bool>> condition, CancellationToken token = default)
        {
            await UpdateContextAsync(async (db) =>
            {
                var entity = await db.Set<TData>().FindAsync(condition, token);
                await Task.Run(() => db.RemoveRange(entity), token).ConfigureAwait(false);
            });
        }
    }
}
