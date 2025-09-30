using System;

public static class Task1_Maclaurin_1
{
    private static void PrintSeparator()
    {
        Console.WriteLine("+------------------------------------------------------------+");
    }

    private static void PrintHeader()
    {
        PrintSeparator();
        Console.WriteLine("| Дисциплина: Программирование корпоративных систем          |");
        Console.WriteLine("| Рабочая тетрадь 2 — Циклы                                  |");
        Console.WriteLine("| Задание 1: Ряды (разложение e^x по Маклорену)              |");
        PrintSeparator();
    }

    private static void PrintInstructions()
    {
        Console.WriteLine("| Описание:");
        Console.WriteLine("| - Программа вычисляет e^x через ряд Маклорена с точностью e.");
        Console.WriteLine("| - Также вычисляет n-й член ряда для заданных x и n.");
        Console.WriteLine("|");
        Console.WriteLine("| Формулы:");
        Console.WriteLine("|   e^x = Σ (x^n / n!), n = 0..∞");
        Console.WriteLine("|   a_n = x^n / n!");
        Console.WriteLine("|");
        Console.WriteLine("| Как пользоваться:");
        Console.WriteLine("|  1) Введите x (вещественное число, например: 1 или -0.5)");
        Console.WriteLine("|  2) Введите точность e (0 < e < 0.01), например: 0.001");
        Console.WriteLine("|  3) Введите номер члена n (целое n >= 0), например: 5");
        Console.WriteLine("|");
        Console.WriteLine("| Пример ввода:");
        Console.WriteLine("|   x = 1");
        Console.WriteLine("|   e = 0.001");
        Console.WriteLine("|   n = 5");
        PrintSeparator();
    }

    private static double Factorial(int n)
    {
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be non-negative");
        }
        if (n == 0)
        {
            return 1.0;
        }
        double result = 1.0;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    private static double GetNthTerm(double x, int n)
    {
        return Math.Pow(x, n) / Factorial(n);
    }

    private static double CalculateSeries(double x, double epsilon)
    {
        if (epsilon <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(epsilon), "epsilon must be positive");
        }

        double sum = 0.0;
        double term = 1.0; // первый член ряда (n = 0)
        int n = 0;

        while (Math.Abs(term) > epsilon)
        {
            sum += term;
            n++;
            term = Math.Pow(x, n) / Factorial(n);
        }

        return sum;
    }

    public static void Run()
    {
        Console.Clear();
        PrintHeader();
        PrintInstructions();

        Console.WriteLine("| Введите x:");
        Console.Write("| > ");
        if (!double.TryParse(Console.ReadLine(), out double x))
        {
            Console.WriteLine("| Ошибка: некорректное значение x");
            PrintSeparator();
            return;
        }

        Console.WriteLine("| Введите точность (e < 0.01):");
        Console.Write("| > ");
        if (!double.TryParse(Console.ReadLine(), out double epsilon))
        {
            Console.WriteLine("| Ошибка: некорректное значение точности");
            PrintSeparator();
            return;
        }
        if (epsilon >= 0.01)
        {
            Console.WriteLine("| Ошибка: точность должна быть меньше 0.01");
            PrintSeparator();
            return;
        }
        if (epsilon <= 0)
        {
            Console.WriteLine("| Ошибка: точность должна быть положительной");
            PrintSeparator();
            return;
        }

        double result = CalculateSeries(x, epsilon);
        Console.WriteLine($"| Значение функции e^x с точностью {epsilon}: {result}");

        Console.WriteLine("|");
        Console.WriteLine("| Введите номер члена ряда (n >= 0):");
        Console.Write("| > ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n < 0)
        {
            Console.WriteLine("| Ошибка: некорректное n (должно быть целым неотрицательным)");
            PrintSeparator();
            return;
        }

        double nthTerm = GetNthTerm(x, n);
        Console.WriteLine($"| Значение {n}-го члена ряда a_{n} = x^{n}/n!: {nthTerm}");
        PrintSeparator();
        Console.WriteLine("Нажмите Enter для выхода в меню...");
        Console.ReadLine();
    }
}


