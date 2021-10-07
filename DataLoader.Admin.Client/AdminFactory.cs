using System;
using DataLoader.Service.Contract;
using Unity.Lifetime;
using Unity;
using DataLoader.Admin.HTTP;

namespace DataLoader.Admin.Client
{
    /// <summary>
    /// Фабрика объектов содержащая DI контейнер
    /// </summary>
    public static class AdminFactory
    {
        /// <summary>
        /// DI контейнер
        /// </summary>
        private static IUnityContainer _container = new UnityContainer();

        /// <summary>
        /// Статический конструктор инициирующий регистрацию типов
        /// </summary>
        static AdminFactory()
        {
            AsSingleton<IScheduleService, ScheduleService>();
            AsSingleton<ITagService, TagService>();
        }

        /// <summary>
        /// Создание экземпляра класса с учетом DI
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <returns>Экземпляр класса</returns>
        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// Создание экземпляра класса с конструктором без параметров без учета DI
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <returns>Экземпляр класса</returns>
        public static T Create<T>() where T : class, new()
        {
            return Activator.CreateInstance(typeof(T)) as T;
        }

        /// <summary>
        /// Регистрация singleton объекта.
        /// </summary>
        /// <typeparam name="TFrom">тип интерфейса</typeparam>
        /// <typeparam name="TTo">тип объекта-реализации</typeparam>
        private static void AsSingleton<TFrom, TTo>()
            where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
        }
    }
}
