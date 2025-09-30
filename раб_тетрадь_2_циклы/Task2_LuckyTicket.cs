using System;

public static class Task2_LuckyTicket
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("+------------------------------------------------------------+");
        Console.WriteLine("| Задание 2: Счастливый билет                               |");
        Console.WriteLine("+------------------------------------------------------------+");
        Console.WriteLine("| Введите шестизначный номер билета (только цифры):");
        Console.Write("| > ");

        string? input = Console.ReadLine();
        if (!IsSixDigitNumber(input))
        {
            Console.WriteLine("| Ошибка: введите корректный шестизначный номер");
            Console.WriteLine("+------------------------------------------------------------+");
            Console.WriteLine("Нажмите Enter для выхода в меню...");
            Console.ReadLine();
            return;
        }

        // Без строк/массивов: преобразуем к числу и извлекаем цифры арифметикой
        int ticket = int.Parse(input!);

        int d1 = ticket / 100000;                // сотни тысяч
        int d2 = (ticket / 10000) % 10;          // десятки тысяч
        int d3 = (ticket / 1000) % 10;           // тысячи
        int d4 = (ticket / 100) % 10;            // сотни
        int d5 = (ticket / 10) % 10;             // десятки
        int d6 = ticket % 10;                    // единицы

        int sumFirst = d1 + d2 + d3;
        int sumLast  = d4 + d5 + d6;

        if (sumFirst == sumLast)
        {
            Console.WriteLine("| Билет счастливый!");
        }
        else
        {
            Console.WriteLine("| Билет обычный.");
        }

        Console.WriteLine("+------------------------------------------------------------+");
        Console.WriteLine("Нажмите Enter для выхода в меню...");
        Console.ReadLine();
    }

    private static bool IsSixDigitNumber(string? s)
    {
        if (string.IsNullOrEmpty(s) || s.Length != 6)
        {
            return false;
        }
        int value = 0;
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c < '0' || c > '9')
            {
                return false;
            }
            // Переводим в число вручную, избегая массивов/коллекций в логике
            value = value * 10 + (c - '0');
        }
        // Проверяем, что действительно шестизначное число (не начинается с 0)
        return value >= 100000 && value <= 999999;
    }
}


