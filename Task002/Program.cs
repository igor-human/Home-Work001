using System;
using System.Collections.Generic;
using System.Linq;

// Клас, що представляє місяць
class Month
{
    public string Name { get; set; } // Назва місяця
    public int Number { get; set; } // Порядковий номер місяця
    public int Days { get; set; } // Кількість днів у місяці
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Ініціалізація списку місяців...");

        // Створення списку місяців з відповідними характеристиками
        List<Month> months = new List<Month>
        {
            new Month { Name = "Січень", Number = 1, Days = 31 },
            new Month { Name = "Лютий", Number = 2, Days = 28 },
            new Month { Name = "Березень", Number = 3, Days = 31 },
            new Month { Name = "Квітень", Number = 4, Days = 30 },
            new Month { Name = "Травень", Number = 5, Days = 31 },
            new Month { Name = "Червень", Number = 6, Days = 30 },
            new Month { Name = "Липень", Number = 7, Days = 31 },
            new Month { Name = "Серпень", Number = 8, Days = 31 },
            new Month { Name = "Вересень", Number = 9, Days = 30 },
            new Month { Name = "Жовтень", Number = 10, Days = 31 },
            new Month { Name = "Листопад", Number = 11, Days = 30 },
            new Month { Name = "Грудень", Number = 12, Days = 31 }
        };
        Console.WriteLine("Список місяців успішно створений.");

        Console.WriteLine("Введіть номер місяця (1-12):");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            Console.WriteLine($"Шукаємо місяць з номером {number}...");

            // Пошук місяця за його порядковим номером
            var monthByNumber = months.FirstOrDefault(m => m.Number == number);
            if (monthByNumber != null)
                Console.WriteLine($"Місяць: {monthByNumber.Name}, Днів: {monthByNumber.Days}");
            else
                Console.WriteLine("Місяць не знайдено");
        }
        else
        {
            Console.WriteLine("Помилка: введено некоректне значення!");
        }

        Console.WriteLine("Введіть кількість днів у місяці:");
        if (int.TryParse(Console.ReadLine(), out int days))
        {
            Console.WriteLine($"Шукаємо місяці з {days} днями...");

            // Пошук усіх місяців, що мають задану кількість днів
            var monthsByDays = months.Where(m => m.Days == days).ToList();
            if (monthsByDays.Any())
            {
                Console.WriteLine("Місяці з такою кількістю днів:");
                foreach (var month in monthsByDays)
                    Console.WriteLine($"{month.Name} ({month.Number})");
            }
            else
                Console.WriteLine("Місяць не знайдено");
        }
        else
        {
            Console.WriteLine("Помилка: введено некоректне значення!");
        }
    }
}