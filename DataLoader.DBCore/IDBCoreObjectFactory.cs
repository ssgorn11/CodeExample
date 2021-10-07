namespace DataLoader.DBCore
{
    /// <summary>
    /// Фабрика объектов содержащая DI контейнер
    /// </summary>
    public interface IDBCoreObjectFactory
    {
        /// <summary>
        /// Создание экземпляра класса с учетом DI
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <returns>Экземпляр класса</returns>
        T Resolve<T>() where T : class;

        /// <summary>
        /// Создание экземпляра класса с конструктором без параметров без учета DI
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <returns>Экземпляр класса</returns>
        T Create<T>() where T : class, new();
    }
}
