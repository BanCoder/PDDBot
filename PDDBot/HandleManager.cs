using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace PDDBot
{
	//Обработчик дейстивий пользователя(запуск бота)
	internal class HandleManager
	{
		private static string _token { get; set; } = "7235469103:AAHCVjfV1jbQmhTaxrFSq2FNJl767Gsqdz4";
		private static TelegramBotClient _client;
		private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
		{
			if (update.Message?.Text is { } messageText)
			{
				Console.WriteLine($"Получено сообщение: {messageText}");
				switch (messageText)
				{
					case "/start":
						await SectionShower.ShowMainMenu(botClient, update.Message.Chat.Id, cancellationToken);
						break;

					case "Правила дорожного движения":
						await SectionShower.ShowPddSections(botClient, update.Message.Chat.Id, cancellationToken);
						break;
					case "Дорожные знаки":
						await SectionShower.ShowTrafficSignSections(botClient, update.Message.Chat.Id, cancellationToken);
						break;
					case "1.Предупреждающие знаки":
					case "2.Знаки приоритета":
					case "3.Запрещающие знаки":
					case "4.Предписывающие знаки":
					case "5.Знаки особых предписаний":
					case "6.Информационные знаки":
					case "7.Знаки сервиса":
					case "8.Знаки доп.информации":
						await URLManager.GetTrafficSignURL(botClient, update.Message.Chat.Id, cancellationToken, messageText); 
						break; 
					case "Дорожная разметка":
						await SectionShower.ShowTrafficMarkUpSections(botClient, update.Message.Chat.Id, cancellationToken);
						break;
					case "1.Горизонтальная разметка":
					case "2.Вертикальная разметка":
						await URLManager.GetMarkUpURL(botClient, update.Message.Chat.Id, cancellationToken, messageText);
						break;
					case "Перечень неисправностей":
						await SectionShower.ShowMalfunctionsList(botClient, update.Message.Chat.Id, cancellationToken);
						break;
					case "Основные положения по допуску":
						await SectionShower.ShowAdmissionProvisions(botClient, update.Message.Chat.Id, cancellationToken);
						break;
					case "Штрафы":
						await SectionShower.ShowPenalties(botClient, update.Message.Chat.Id, cancellationToken);
						break;
					case "Назад на главную":
						await SectionShower.ShowMainMenu(botClient, update.Message.Chat.Id, cancellationToken);
						break;
					case "Назад":
						await HandleBackCommand(botClient, update.Message.Chat.Id, cancellationToken);
						break;
					default:
						if (messageText.StartsWith("1.") || messageText.StartsWith("2.") ||
							messageText.StartsWith("3.") || messageText.StartsWith("4.") ||
							messageText.StartsWith("5.") || messageText.StartsWith("6.") ||
							messageText.StartsWith("7.") || messageText.StartsWith("8.") ||
							messageText.StartsWith("9.") || messageText.StartsWith("10.") ||
							messageText.StartsWith("11.") || messageText.StartsWith("12.") ||
							messageText.StartsWith("13.") || messageText.StartsWith("14.") ||
							messageText.StartsWith("15.") || messageText.StartsWith("16.") ||
							messageText.StartsWith("17.") || messageText.StartsWith("18.") ||
							messageText.StartsWith("19.") || messageText.StartsWith("20.") ||
							messageText.StartsWith("21.") || messageText.StartsWith("22.") ||
							messageText.StartsWith("23.") || messageText.StartsWith("24.") ||
							messageText.StartsWith("25.") || messageText.StartsWith("26."))
						{
							string theoryText = FileManager.ReadTheoryFromFile(messageText);
							await SendLongMessage(
							botClient,
							update.Message.Chat.Id,
							$"'{messageText}'\n\n{theoryText}",
							ButtonManager.GetBackButton(update.Message.Chat.Id),
							cancellationToken);
						}
						else
						{
							await botClient.SendTextMessageAsync(
								chatId: update.Message.Chat.Id,
								text: "Неизвестная команда!",
								cancellationToken: cancellationToken);
						}
						break;
				}
			}
		}
		private static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
		{
			Console.WriteLine($"Ошибка: {exception.Message}");
			return Task.CompletedTask;
		}
		public void Starter()
		{
			SectionShower sectionShower = new SectionShower();
			_client = new TelegramBotClient(_token);
			var receiverOptions = new ReceiverOptions
			{
				AllowedUpdates = Array.Empty<UpdateType>()
			};
			_client.StartReceiving(
				updateHandler: HandleUpdateAsync,
				pollingErrorHandler: HandlePollingErrorAsync,
				receiverOptions: receiverOptions
			);

			Console.WriteLine("Бот запущен. Нажмите Enter для остановки...");
			Console.ReadLine();
		}
		private static async Task SendLongMessage(ITelegramBotClient botClient, long chatId, string text, IReplyMarkup replyMarkup, CancellationToken ct)
		{
			if (text.Length <= 4096)
			{
				await botClient.SendTextMessageAsync(
					chatId: chatId,
					text: text,
					parseMode: ParseMode.Html,
					replyMarkup: replyMarkup,
					cancellationToken: ct);
			}
			else
			{
				using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(text)))
				{
					await botClient.SendDocumentAsync(
						chatId: chatId,
						document: InputFile.FromStream(stream, "Теория.txt"),
						caption: "Текст теории (слишком длинный для сообщения)",
						replyMarkup: replyMarkup,
						cancellationToken: ct);
				}
			}
		}
		private static async Task HandleBackCommand(ITelegramBotClient botClient, long chatId, CancellationToken ct)
		{
			if (SectionShower.GetNavHistory().TryGetValue(chatId, out var history) && history.Count > 0)
			{
				var currentSection = history.Peek();

				switch (currentSection)
				{
					case "ПДД":
						await SectionShower.ShowPddSections(botClient, chatId, ct);
						break;
					case "Дорожные знаки":
						await SectionShower.ShowTrafficSignSections(botClient, chatId, ct);
						break;
					case "Дорожная разметка":
						await SectionShower.ShowTrafficMarkUpSections(botClient, chatId, ct);
						break;
					case "Перечень неисправностей":
						await SectionShower.ShowMalfunctionsList(botClient, chatId, ct);
						break;
					case "Основные положения по допуску":
						await SectionShower.ShowAdmissionProvisions(botClient, chatId, ct);
						break;
					case "Штрафы":
						await SectionShower.ShowPenalties(botClient, chatId, ct);
						break;
					default:
						await SectionShower.ShowMainMenu(botClient, chatId, ct);
						break;
				}
			}
			else
			{
				await SectionShower.ShowMainMenu(botClient, chatId, ct);
			}
		}
		
		
	}
}
