using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace PDDBot
{
	//Отображение кнопок главных секций(разделов ПДД)
	internal class SectionShower
	{
		private static Dictionary<long, Stack<string>> _userNavigationHistory;
		public SectionShower()
		{
			_userNavigationHistory = new Dictionary<long, Stack<string>>(); 
		}
		public static async Task ShowMainMenu(ITelegramBotClient botClient, long chatId, CancellationToken ct)
		{
			if (_userNavigationHistory.ContainsKey(chatId))
			{
				_userNavigationHistory[chatId].Clear();
			}
			AddToNavigationHistory(chatId, "Главное меню");
			await botClient.SendTextMessageAsync(
				chatId: chatId,
				text: "Выберите раздел, который хотите изучить:",
				replyMarkup: ButtonManager.MainSectionButtons(),
				cancellationToken: ct);
		}
		public static async Task ShowPddSections(ITelegramBotClient botClient, long chatId, CancellationToken ct)
		{
			AddToNavigationHistory(chatId, "ПДД");
			await botClient.SendTextMessageAsync(
				chatId: chatId,
				text: "Выберите пункт ПДД, который хотите изучить:",
				replyMarkup: ButtonManager.TrafficLawsButtons(),
				cancellationToken: ct);
		}
		public static async Task ShowTrafficSignSections(ITelegramBotClient botClient, long chatId, CancellationToken ct)
		{
			AddToNavigationHistory(chatId, "Дорожные знаки");
			await botClient.SendTextMessageAsync(
				chatId: chatId,
				text: "Выберите пункт дорожных знаков, который хотите изучить:",
				replyMarkup: ButtonManager.TrafficSignButtons(),
				cancellationToken: ct);
		}
		public static async Task ShowTrafficMarkUpSections(ITelegramBotClient botClient, long chatId, CancellationToken ct)
		{
			AddToNavigationHistory(chatId, "Дорожная разметка");
			await botClient.SendTextMessageAsync(
				chatId: chatId,
				text: "Выберите разметку, которую хотите изучить:",
				replyMarkup: ButtonManager.TrafficMarkUpButtons(),
				cancellationToken: ct);
		}
		public static async Task ShowMalfunctionsList(ITelegramBotClient botClient, long chatId, CancellationToken ct)
		{
			AddToNavigationHistory(chatId, "Перечень неисправностей");
			await botClient.SendTextMessageAsync(
				chatId: chatId,
				text: "Выберите перечень, который хотите изучить:",
				replyMarkup: ButtonManager.MalfunctionsButtons(),
				cancellationToken: ct);
		}
		public static async Task ShowAdmissionProvisions(ITelegramBotClient botClient, long chatId, CancellationToken ct)
		{
			AddToNavigationHistory(chatId, "Основные положения по допуску");
			await botClient.SendTextMessageAsync(
				chatId: chatId,
				text: "Выберите положение, который хотите изучить:",
				replyMarkup: ButtonManager.AdmissionProvisionsButtons(),
				cancellationToken: ct);
		}
		public static async Task ShowPenalties(ITelegramBotClient botClient, long chatId, CancellationToken ct)
		{
			AddToNavigationHistory(chatId, "Штрафы");
			await botClient.SendTextMessageAsync(
				chatId: chatId,
				text: "Выберите пункт, который хотите изучить:",
				replyMarkup: ButtonManager.PenaltiesButtons(),
				cancellationToken: ct);
		}
		public static void AddToNavigationHistory(long chatId, string section)
		{
			if (!_userNavigationHistory.ContainsKey(chatId))
			{
				_userNavigationHistory[chatId] = new Stack<string>();
			}
			_userNavigationHistory[chatId].Push(section);
		}
		public static Dictionary<long, Stack<string>> GetNavHistory()
		{
			return _userNavigationHistory; 
		}
	}
}
