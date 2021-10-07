namespace DataLoader.DBCore.BL
{
	/// <summary>
	/// Бизнес объект внешнего ключа ТЭГа
	/// Связь с ТЭГом 1 к 1му (т.е. для каждого ТЭГа должен быть свой уникальный IdDirectoryParameter в этой таблице)
	/// Исторический рудимент
	/// </summary>
	public class DPBO : BaseBO
	{
		/// <summary>
		/// Ключ ТЭГа
		/// </summary>
		public int IdTag { get; set; }

		/// <summary>
		/// Коментарий
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		/// Внешний ключ
		/// </summary>
		public int IdDirectoryParameter { get; set; }
	}
}
