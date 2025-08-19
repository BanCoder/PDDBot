using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace PDDBot
{
	internal class Program
	{
		static void Main(string[] args)
		{
			HandleManager handleManager = new HandleManager();
			handleManager.Starter(); 
		}
	}
}