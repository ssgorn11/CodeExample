using Microsoft.Practices.Unity;
using DataLoader.DBCore.BL;
using DataLoader.DBCore.DBModel;
using System;
using DataLoader.DBCore.DTS;
using DataLoader.Service.Contract;

namespace DataLoader.DBCore
{
    /// <summary>
    /// Фабрика объектов содержащая DI контейнер
    /// </summary>
    public class DBCoreObjectFactory : IDBCoreObjectFactory
    {
        /// <summary>
        /// DI контейнер
        /// </summary>
        private IUnityContainer _container = new UnityContainer();

        /// <summary>
        /// Статический конструктор инициирующий регистрацию типов
        /// </summary>
        public DBCoreObjectFactory(IDBSettings dbSettings)
        {
            _container.RegisterInstance(typeof(IDBSettings), dbSettings);

            var mapperConfig = new AutoMapper.MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperConfiguration());
            });
            var mapper = mapperConfig.CreateMapper();
            _container.RegisterInstance(typeof(AutoMapper.IMapper), mapper);

            AsSingleton<IDataSource, EfDataSource>();

            AsSingleton<IDao<DPEntity>, EntityDao<DPEntity>>();
            AsSingleton<IDao<ErrorEntity>, EntityDao<ErrorEntity>>();
            AsSingleton<IDao<IntervalDirectionEntity>, EntityDao<IntervalDirectionEntity>>();
            AsSingleton<IDao<LogEntity>, EntityDao<LogEntity>>();
            AsSingleton<IDao<ScheduleEntity>, EntityDao<ScheduleEntity>>();
            AsSingleton<IDao<ScheduleStoreEntity>, EntityDao<ScheduleStoreEntity>>();
            AsSingleton<IDao<Tag2ScheduleEntity>, EntityDao<Tag2ScheduleEntity>>();
            AsSingleton<IDao<Tag2TagGroupEntity>, EntityDao<Tag2TagGroupEntity>>();
            AsSingleton<IDao<TagEntity>, EntityDao<TagEntity>>();
            AsSingleton<IDao<TagGroupEntity>, EntityDao<TagGroupEntity>>();
            AsSingleton<IDao<TagValueEntity>, EntityDao<TagValueEntity>>();
            AsSingleton<IDao<TimeIntervalTypeEntity>, EntityDao<TimeIntervalTypeEntity>>();
            AsSingleton<IDao<TypeOfIntervalSearchEntity>, EntityDao<TypeOfIntervalSearchEntity>>();

            AsSingleton<IScheduleDao, ScheduleDao>();
            AsSingleton<ITag2ScheduleDao, Tag2ScheduleDao>();
            AsSingleton<ITagDao, TagDao>();
            AsSingleton<ITagValueDao, TagValueDao>();

            AsSingleton<IScheduleCollection, ScheduleCollection>();
            AsSingleton<ITagCollection, TagCollection>();
            AsSingleton<ITag2ScheduleCollection, Tag2ScheduleCollection>();
            AsSingleton<ITagValueCollection, TagValueCollection>();

            AsSingleton<IScheduleService, ScheduleService>();
            AsSingleton<ITagService, TagService>();

            AsSingleton<ILogError, LogError>();
        }

        /// <summary>
        /// Создание экземпляра класса с учетом DI
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <returns>Экземпляр класса</returns>
        public T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// Создание экземпляра класса с конструктором без параметров без учета DI
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <returns>Экземпляр класса</returns>
        public T Create<T>() where T : class, new()
        {
            return Activator.CreateInstance(typeof(T)) as T;
        }

        /// <summary>
        /// Регистрация singleton объекта.
        /// </summary>
        /// <typeparam name="TFrom">тип интерфейса</typeparam>
        /// <typeparam name="TTo">тип объекта-реализации</typeparam>
        private void AsSingleton<TFrom, TTo>()
            where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
        }
    }
}
