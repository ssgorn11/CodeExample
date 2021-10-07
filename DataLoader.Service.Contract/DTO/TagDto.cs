using System;
using System.Collections.Generic;
using System.Text;

namespace DataLoader.Service.Contract
{
    public class TagDto
    {
		public TagDto() { }

		public int Id { get; set; }

		/// <summary>
		/// ТЭГ - некий текстовый ключ данных
		/// </summary>
		public string Tag { get; set; }

		/// <summary>
		/// Описание
		/// </summary>
		public string Comment { get; set; }
	}
}
