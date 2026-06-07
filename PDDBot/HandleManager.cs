using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace PDDBot
{
	//Обработчик дейстивий пользователя(запуск бота)
	public class HandleManager
	{
		private static string _token = App.Settings.Token;
		private static TelegramBotClient _client;
		private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
		{
			try
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
							if (Regex.IsMatch(messageText, @"^\d+\."))
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
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
				await botClient.SendTextMessageAsync(chatId: update.Message.Chat.Id, "Произошла ошибка. Попробуйте позже.");
			}
			
		}
		private static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
		{
			Console.WriteLine($"Ошибка: {exception.Message}");
			return Task.CompletedTask;
		}
		public void Starter()
		{
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
			int maxWordLength = 4096; 
			if (text.Length <= maxWordLength)
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
				for (int i = 0; i < text.Length; i+=maxWordLength)
				{
					int length = Math.Min(maxWordLength, text.Length - i);
					string part = text.Substring(i, length);
					IReplyMarkup currentReplyMarkup; 
					if(i == 0)
					{
						currentReplyMarkup = replyMarkup; 
					}
					else
					{
						currentReplyMarkup = null; 
					}
						await botClient.SendTextMessageAsync(
						chatId: chatId,
						text: part,
						parseMode: ParseMode.Html,
						replyMarkup: currentReplyMarkup,
						cancellationToken: ct
						);
					await Task.Delay(100, ct);
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
