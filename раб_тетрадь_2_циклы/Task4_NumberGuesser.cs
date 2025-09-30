using System;

public static class Task4_NumberGuesser
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("+------------------------------------------------------------+");
        Console.WriteLine("| Задание 4: Угадай число (0..63)                            |");
        Console.WriteLine("+------------------------------------------------------------+");
        Console.WriteLine("| Загадайте число от 0 до 63. Отвечайте '1' (да) или '0' (нет).");
        Console.WriteLine("+------------------------------------------------------------+");

        int[] masks = { 32, 16, 8, 4, 2, 1 };
        int lower = 0;
        int result = 0;

        foreach (int mask in masks)
        {
            Console.Write($"| Ваше число больше или равно {lower + mask}? (1/0): ");
            string? answer = Console.ReadLine();
            if (answer == "1")
            {
                result |= mask;
                lower += mask;
            }
        }

        Console.WriteLine($"| Ваше число: {result}");
        Console.WriteLine("+------------------------------------------------------------+");
        Console.WriteLine("Нажмите Enter для выхода в меню...");
        Console.ReadLine();
    }
}


