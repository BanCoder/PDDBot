using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace PDDBot
{
	//Отображение подразделов главных секций ПДД
	internal class ButtonManager
	{
		public static ReplyKeyboardMarkup MainSectionButtons()
		{
			return new ReplyKeyboardMarkup(new[]
			{
				new[] { new KeyboardButton("Правила дорожного движения"), new KeyboardButton("Дорожные знаки"), new KeyboardButton("Дорожная разметка") },
				new[] { new KeyboardButton("Перечень неисправностей"), new KeyboardButton("Основные положения по допуску"), new KeyboardButton("Штрафы") }
			})
			{
				ResizeKeyboard = true
			};
		}
		public static ReplyKeyboardMarkup TrafficLawsButtons()
		{
			var buttons = new List<KeyboardButton[]>
			{
				new[] { new KeyboardButton("1.Общие положения"), new KeyboardButton("2.Общие обязанности водителей"), new KeyboardButton("3.Применение специальных сигналов"), new KeyboardButton("4.Обязанности пешеходов"), new KeyboardButton("5.Обязанности пассажиров") },
				new[] { new KeyboardButton("6.Сигналы светофора и регулировщика"), new KeyboardButton("7.Применение аварийной сигнализации"), new KeyboardButton("8.Начало движения, маневрирование"), new KeyboardButton("9.Расположение транспортных средств на проезжей части"), new KeyboardButton("10.Скорость движения") },
				new[] { new KeyboardButton("11.Обгон, опережение, встречный разъезд"), new KeyboardButton("12.Остановка и стоянка"), new KeyboardButton("13.Проезд перекрестков"), new KeyboardButton("14.Пешеходные переходы и места остановок маршрутных транспортных средств"), new KeyboardButton("15.Движение через железнодорожные пути") },
				new[] { new KeyboardButton("16.Движение по автомагистралям"), new KeyboardButton("17.Движение в жилых зонах"), new KeyboardButton("18.Приоритет маршрутных транспортных средств"), new KeyboardButton("19.Пользование внешними световыми приборами"), new KeyboardButton("20.Буксировка механических транспортных средств") },
				new[] { new KeyboardButton("21.Учебная езда"), new KeyboardButton("22.Перевозка людей"), new KeyboardButton("23.Перевозка грузов"), new KeyboardButton("24.Доп. требования к движению средства индивидуальной мобильности"), new KeyboardButton("25.Доп.требования к движению гужевых повозок"), new KeyboardButton("26.Нормы времени управления транспортным средством и отдыха") },
				new[] { new KeyboardButton("Назад на главную") }
			};
			return new ReplyKeyboardMarkup(buttons)
			{
				ResizeKeyboard = true
			};
		}
		public static ReplyKeyboardMarkup TrafficSignButtons()
		{
			var buttons = new List<KeyboardButton[]>
			{
				new[] { new KeyboardButton("1.Предупреждающие знаки"), new KeyboardButton("2.Знаки приоритета"), new KeyboardButton("3.Запрещающие знаки"), new KeyboardButton("4.Предписывающие знаки")},
				new[] { new KeyboardButton("5.Знаки особых предписаний"), new KeyboardButton("6.Информационные знаки"), new KeyboardButton("7.Знаки сервиса"), new KeyboardButton("8.Знаки доп.информации") },
				new[] { new KeyboardButton("Назад на главную") }
			};
			return new ReplyKeyboardMarkup(buttons)
			{
				ResizeKeyboard = true
			};
		}
		public static ReplyKeyboardMarkup TrafficMarkUpButtons()
		{
			var buttons = new List<KeyboardButton[]>
			{
				new[] { new KeyboardButton("1.Горизонтальная разметка"), new KeyboardButton("2.Вертикальная разметка")},
				new[] { new KeyboardButton("Назад на главную") }
			};
			return new ReplyKeyboardMarkup(buttons)
			{
				ResizeKeyboard = true
			};
		}
		public static ReplyKeyboardMarkup MalfunctionsButtons()
		{
			var buttons = new List<KeyboardButton[]>
			{
				new[] { new KeyboardButton("1.Тормозная система"), new KeyboardButton("2.Рулевое управление"), new KeyboardButton("3.Устройства освещения и световой сигнализации"), new KeyboardButton("4.Обзорность транспортного средства"), new KeyboardButton("5.Колеса и шины")},
				new[] { new KeyboardButton("6.Сцепные устройства"), new KeyboardButton("7.Удерживающие системы пассивной безопасности"), new KeyboardButton("8.Двигатель"), new KeyboardButton("9.Прочие элементы конструкции и оборудование"), new KeyboardButton("10.Комплектность транспортных средств") },
				new[] { new KeyboardButton("Назад на главную") }
			};
			return new ReplyKeyboardMarkup(buttons)
			{
				ResizeKeyboard = true
			};
		}
		public static ReplyKeyboardMarkup AdmissionProvisionsButtons()
		{
			var buttons = new List<KeyboardButton[]>
			{
				new[] { new KeyboardButton("1.Пункт 1"), new KeyboardButton("2.Пункт 2"), new KeyboardButton("3.Пункт 3"), new KeyboardButton("4.Пункт 4"), new KeyboardButton("5.Пункт 4.1") },
				new[] { new KeyboardButton("6.Пункт 5"), new KeyboardButton("7.Пункт 5(1)"), new KeyboardButton("8.Пункт 6"), new KeyboardButton("9.Пункт 7"), new KeyboardButton("10.Пункт 8") },
				new[] { new KeyboardButton("11.Пункт 9"), new KeyboardButton("12.Пункт 10"), new KeyboardButton("13.Пункт 11"), new KeyboardButton("14.Пункт 12"), new KeyboardButton("15.Пункт 13") },
				new[] { new KeyboardButton("16.Пункт 14"), new KeyboardButton("17.Пункт 15"), new KeyboardButton("18.Пункт 16"), new KeyboardButton("19.Пункт 17"), new KeyboardButton("20.Пункт 18") },
				new[] { new KeyboardButton("21.Пункт 19"), new KeyboardButton("22.Пункт 20"), new KeyboardButton("23.Пункт 21"),},
				new[] { new KeyboardButton("Назад на главную") }
			};
			return new ReplyKeyboardMarkup(buttons)
			{
				ResizeKeyboard = true
			};
		}
		public static ReplyKeyboardMarkup PenaltiesButtons()
		{
			var buttons = new List<KeyboardButton[]>
			{
				new[] { new KeyboardButton("1.Отсутствие документов и регистрации автомобиля"), new KeyboardButton("2.Штраф за отсутствие страховки"), new KeyboardButton("3.Штрафы за резину"), new KeyboardButton("4.Знаки и разметка"), new KeyboardButton("5.Штрафы за проезд на красный свет") },
				new[] { new KeyboardButton("6.Железная дорога"), new KeyboardButton("7.Автомагистраль"), new KeyboardButton("8.Маневрирование"), new KeyboardButton("9.Расположение, обгон"), new KeyboardButton("10.Предоставить преимущество") },
				new[] { new KeyboardButton("11.ДТП"), new KeyboardButton("12.ГАИ(ГИБДД)"), new KeyboardButton("13.Штрафы за проезд стоп-линии"), new KeyboardButton("14.Штрафы за парковку на газоне"), new KeyboardButton("15.Штраф за тонировку") },
				new[] { new KeyboardButton("16.Штрафы за превышение скорости"), new KeyboardButton("17.Штрафы за неправильную парковку"), new KeyboardButton("18.Проезд перекрестка"), new KeyboardButton("19.Штрафы за непристегнутый ремень"), new KeyboardButton("20.Штраф за вождение в состоянии опьянения и без прав") },
				new[] { new KeyboardButton("21.Установка мигалок"), new KeyboardButton("22.Неисправности автомобиля"), new KeyboardButton("23.Прочее"),},
				new[] { new KeyboardButton("Назад на главную") }
			};
			return new ReplyKeyboardMarkup(buttons)
			{
				ResizeKeyboard = true
			};
		}
		public static ReplyKeyboardMarkup GetBackButton(long chatId)
		{
			return new ReplyKeyboardMarkup(new[] { new[] { new KeyboardButton("Назад") } })
			{
				ResizeKeyboard = true
			};
		}
	}
}
