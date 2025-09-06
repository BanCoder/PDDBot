using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; 
using System.Text;
using System.Threading.Tasks;

namespace PDDBot
{
	//Менеджер выгрузки теории из файла в сообщение бота
	internal class FileManager
	{
		public static string ReadTheoryFromFile(string sectionName)
		{
			try
			{
				string[] files = Directory.GetFiles("Теория", $"{sectionName.Substring(sectionName.IndexOf('.') + 1).Trim()}.txt", SearchOption.AllDirectories);
				if (files.Length > 0)
				{
					return File.ReadAllText(files[0], Encoding.UTF8);
				}
				else
				{
					return "Теоретический материал для этого раздела пока не добавлен.";
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
				return "Произошла ошибка при загрузке теории.";
			}
		}
	}
}
