using System;

public static class Task7_MarsColonization
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("+------------------------------------------------------------+");
        Console.WriteLine("| Задание 7: Колонизация Марса                               |");
        Console.WriteLine("+------------------------------------------------------------+");

        int n = ReadPositiveInt("| Введите количество модулей (n): ");

        Console.WriteLine("| Введите размеры модуля (a b):");
        int a = ReadPositiveInt("| a > ");
        int b = ReadPositiveInt("| b > ");

        Console.WriteLine("| Введите размеры поля (h w):");
        int h = ReadPositiveInt("| h > ");
        int w = ReadPositiveInt("| w > ");

        int maxD = CalculateMaxProtection(n, a, b, h, w);
        Console.WriteLine($"| Максимальная толщина защиты: {maxD}");
        Console.WriteLine("+------------------------------------------------------------+");
        Console.WriteLine("Нажмите Enter для выхода в меню...");
        Console.ReadLine();
    }

    private static int CalculateMaxProtection(int n, int a, int b, int h, int w)
    {
        if (!CanPlaceModules(n, a, b, h, w, 0))
        {
            return -1;
        }
        int left = 0;
        int right = Math.Min(h, w) / 2;
        int result = 0;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (CanPlaceModules(n, a, b, h, w, mid))
            {
                result = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return result;
    }

    private static bool CanPlaceModules(int n, int a, int b, int h, int w, int d)
    {
        int aWithD = a + 2 * d;
        int bWithD = b + 2 * d;
        return (h >= aWithD && w >= bWithD && CanFit(n, aWithD, bWithD, h, w))
            || (h >= bWithD && w >= aWithD && CanFit(n, bWithD, aWithD, h, w));
    }

    private static bool CanFit(int n, int a, int b, int h, int w)
    {
        long perRow = w / b;
        long perCol = h / a;
        return perRow > 0 && perCol > 0 && perRow * perCol >= n;
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


