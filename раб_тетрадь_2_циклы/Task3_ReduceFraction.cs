using System;

public static class Task3_ReduceFraction
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("+------------------------------------------------------------+");
        Console.WriteLine("| Задание 3: Сокращение дроби                                |");
        Console.WriteLine("+------------------------------------------------------------+");

        Console.WriteLine("| Введите числитель M (целое):");
        Console.Write("| > ");
        if (!int.TryParse(Console.ReadLine(), out int m))
        {
            Console.WriteLine("| Ошибка: некорректное M");
            Finish();
            return;
        }

        Console.WriteLine("| Введите знаменатель N (целое, не 0):");
        Console.Write("| > ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n == 0)
        {
            Console.WriteLine("| Ошибка: некорректное N (ноль запрещён)");
            Finish();
            return;
        }

        int gcd = Gcd(Math.Abs(m), Math.Abs(n));
        int numerator = m / gcd;
        int denominator = n / gcd;

        // Нормализуем знак: знаменатель всегда положительный
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        Console.WriteLine($"| Несократимая дробь: {numerator}/{denominator}");
        Finish();
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a == 0 ? 1 : a;
    }

    private static void Finish()
    {
        Console.WriteLine("+------------------------------------------------------------+");
        Console.WriteLine("Нажмите Enter для выхода в меню...");
        Console.ReadLine();
    }
}


