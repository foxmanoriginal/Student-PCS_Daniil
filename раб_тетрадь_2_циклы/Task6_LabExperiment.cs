using System;

public static class Task6_LabExperiment
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("+------------------------------------------------------------+");
        Console.WriteLine("| Задание 6: Лабораторный опыт                               |");
        Console.WriteLine("+------------------------------------------------------------+");

        int N = ReadPositiveInt("| Введите количество бактерий (N): ");
        int X = ReadPositiveInt("| Введите количество капель антибиотика (X): ");

        int bacteria = N;
        int hours = 0;
        int killPower = X * 10; // суммарная мощность в первый час

        Console.WriteLine("\n| Динамика изменения количества бактерий:");

        while (killPower > 0 && bacteria > 0)
        {
            hours++;
            bacteria *= 2; // рост
            bacteria -= killPower; // действие антибиотика
            if (bacteria < 0)
            {
                bacteria = 0;
            }

            Console.WriteLine($"| Час {hours}: Бактерий = {bacteria}, Мощность антибиотика = {Math.Max(killPower - X, 0)}");

            killPower -= X; // эффективность падает на X бактерий в час
        }

        Console.WriteLine($"\n| Процесс завершён через {hours} час(ов)");
        Console.WriteLine($"| Конечное количество бактерий: {bacteria}");
        Console.WriteLine("+------------------------------------------------------------+");
        Console.WriteLine("Нажмите Enter для выхода в меню...");
        Console.ReadLine();
    }

    private static int ReadPositiveInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int v) && v >= 0)
            {
                return v;
            }
            Console.WriteLine("| Ошибка: введите неотрицательное целое число.");
        }
    }
}


