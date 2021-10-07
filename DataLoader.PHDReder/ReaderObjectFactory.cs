using DataLoader.DBCore;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLoader.PHDReder
{
    /// <summary>
    /// Фабрика объектов содержащая DI контейнер
    /// </summary>
    public class ReaderObjectFactory : IReaderObjectFactory
    {
        /// <summary>
        /// DI контейнер
        /// </summary>
        private IUnityContainer _container = new UnityContainer();

        /// <summary>
        /// Статический конструктор инициирующий регистрацию типов
        /// </summary>
        public ReaderObjectFactory(IReaderSettings readerSettings, ILogError logError)
        {
            _container.RegisterInstance(typeof(IReaderSettings), readerSettings);
            _container.RegisterInstance(typeof(ILogError), logError);
            AsSingleton<IPHDDataReader, PHDDataReader>();
            AsSingleton<IPHDDataAcess, PHDDataAcessMock>();
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
