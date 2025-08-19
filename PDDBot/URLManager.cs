using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace PDDBot
{
	//Менеджер выдачи url-ссылок для нужного пункта 
	internal class URLManager
	{
		public static async Task GetMarkUpURL(ITelegramBotClient botClient, long chatId, CancellationToken ct, string message)
		{
			SectionShower.AddToNavigationHistory(chatId, message);
			string horizontalMarkUpURL = "https://haiv.ru/textbook/article/4_1/";
			string verticalMarkUpURL = "https://haiv.ru/textbook/article/4_2/";
			switch (message)
			{
				case "1.Горизонтальная разметка":
					await botClient.SendTextMessageAsync(
					chatId: chatId,
					text: $"Горизонтальная разметка.\nПерейдите по ссылке, чтобы изучить материал: {horizontalMarkUpURL}",
					parseMode: ParseMode.Html,
					replyMarkup: ButtonManager.GetBackButton(chatId),
					cancellationToken: ct);
					break;
				case "2.Вертикальная разметка":
					await botClient.SendTextMessageAsync(
					chatId: chatId,
					text: $"Вертикальная разметка.\nПерейдите по ссылке, чтобы изучить материал: {verticalMarkUpURL}",
					 parseMode: ParseMode.Html,
					replyMarkup: ButtonManager.GetBackButton(chatId),
					cancellationToken: ct);
					break;
				default:
					await SectionShower.ShowMainMenu(botClient, chatId, ct);
					break;
			}
		}
		public static async Task GetTrafficSignURL(ITelegramBotClient botClient, long chatId, CancellationToken ct, string message)
		{
			SectionShower.AddToNavigationHistory(chatId, message);
			const string warningSignsURL = "https://www.drom.ru/pdd/pdd/signs/#63035";
			const string prioritySignsURL = "https://www.drom.ru/pdd/pdd/signs/#65324";
			const string forbiddingSignsURL = "https://www.drom.ru/pdd/pdd/signs/#65325";
			const string prescriptiveSignsURL = "https://www.drom.ru/pdd/pdd/signs/#65326";
			const string signsOfSpecialRegulationsURL = "https://www.drom.ru/pdd/pdd/signs/#69610";
			const string informationSignsURL = "https://www.drom.ru/pdd/pdd/signs/#65328";
			const string serviceSignsURL = "https://www.drom.ru/pdd/pdd/signs/#65329";
			const string additionalInformationSignsURL = "https://www.drom.ru/pdd/pdd/signs/#65331";
			switch (message)
			{
				case "1.Предупреждающие знаки":
					await botClient.SendTextMessageAsync(
					chatId: chatId,
					text: $"Предупреждающие знаки.\nПерейдите по ссылке, чтобы изучить материал: {warningSignsURL}",
					parseMode: ParseMode.Html,
					replyMarkup: ButtonManager.GetBackButton(chatId),
					cancellationToken: ct);
					break;
				case "2.Знаки приоритета":
					await botClient.SendTextMessageAsync(
					chatId: chatId,
					text: $"Знаки приоритета.\nПерейдите по ссылке, чтобы изучить материал: {prioritySignsURL}",
					 parseMode: ParseMode.Html,
					replyMarkup: ButtonManager.GetBackButton(chatId),
					cancellationToken: ct);
					break;
				case "3.Запрещающие знаки":
					await botClient.SendTextMessageAsync(
					chatId: chatId,
					text: $"Запрещающие знаки.\nПерейдите по ссылке, чтобы изучить материал: {forbiddingSignsURL}",
					parseMode: ParseMode.Html,
					replyMarkup: ButtonManager.GetBackButton(chatId),
					cancellationToken: ct);
					break;
				case "4.Предписывающие знаки":
					await botClient.SendTextMessageAsync(
					chatId: chatId,
					text: $"Предписывающие знаки.\nПерейдите по ссылке, чтобы изучить материал: {prescriptiveSignsURL}",
					parseMode: ParseMode.Html,
					replyMarkup: ButtonManager.GetBackButton(chatId),
					cancellationToken: ct);
					break;
				case "5.Знаки особых предписаний":
					await botClient.SendTextMessageAsync(
					chatId: chatId,
					text: $"Знаки особых предписаний.\nПерейдите по ссылке, чтобы изучить материал: {signsOfSpecialRegulationsURL}",
					parseMode: ParseMode.Html,
					replyMarkup: ButtonManager.GetBackButton(chatId),
					cancellationToken: ct);
					break;
				case "6.Информационные знаки":
					await botClient.SendTextMessageAsync(
					chatId: chatId,
					text: $"Информационные знаки.\nПерейдите по ссылке, чтобы изучить материал: {informationSignsURL}",
					parseMode: ParseMode.Html,
					replyMarkup: ButtonManager.GetBackButton(chatId),
					cancellationToken: ct);
					break;
				case "7.Знаки сервиса":
					await botClient.SendTextMessageAsync(
					chatId: chatId,
					text: $"Знаки сервиса.\nПерейдите по ссылке, чтобы изучить материал: {serviceSignsURL}",
					parseMode: ParseMode.Html,
					replyMarkup: ButtonManager.GetBackButton(chatId),
					cancellationToken: ct);
					break;
				case "8.Знаки доп.информации":
					await botClient.SendTextMessageAsync(
					chatId: chatId,
					text: $"Знаки доп.информации.\nПерейдите по ссылке, чтобы изучить материал: {additionalInformationSignsURL}",
					parseMode: ParseMode.Html,
					replyMarkup: ButtonManager.GetBackButton(chatId),
					cancellationToken: ct);
					break;
				default:
					await SectionShower.ShowMainMenu(botClient, chatId, ct);
					break;
			}
		}
	}
}
