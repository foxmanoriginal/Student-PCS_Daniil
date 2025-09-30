using System;

public static class Task5_CoffeeMachine
{
    private const int AMERICANO_WATER = 300;
    private const int LATTE_WATER = 30;
    private const int LATTE_MILK = 270;

    private const int AMERICANO_PRICE = 150;
    private const int LATTE_PRICE = 170;

    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("+------------------------------------------------------------+");
        Console.WriteLine("| Задание 5: Кофейный аппарат                                |");
        Console.WriteLine("+------------------------------------------------------------+");

        int water = ReadInt("| Введите количество воды (мл): ", min: 0);
        int milk  = ReadInt("| Введите количество молока (мл): ", min: 0);

        int americanoCount = 0;
        int latteCount = 0;
        int revenue = 0;

        while (true)
        {
            bool canAmericano = water >= AMERICANO_WATER;
            bool canLatte = water >= LATTE_WATER && milk >= LATTE_MILK;

            if (!canAmericano && !canLatte)
            {
                Console.WriteLine("+------------------------------------------------------------+");
                Console.WriteLine("| Ингредиенты подошли к концу.");
                Console.WriteLine($"| Остаток воды: {water} мл");
                Console.WriteLine($"| Остаток молока: {milk} мл");
                Console.WriteLine($"| Приготовлено американо: {americanoCount}");
                Console.WriteLine($"| Приготовлено латте: {latteCount}");
                Console.WriteLine($"| Выручка: {revenue} руб.");
                Console.WriteLine("+------------------------------------------------------------+");
                Console.WriteLine("Нажмите Enter для выхода в меню...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("+------------------------------------------------------------+");
            Console.WriteLine("| Выберите напиток:");
            Console.WriteLine("| 1 - Американо (300 мл воды, 150 руб)");
            Console.WriteLine("| 2 - Латте (30 мл воды, 270 мл молока, 170 руб)");
            Console.WriteLine("| 0 - Завершить смену и показать отчёт");
            Console.Write("| > ");
            string? choice = Console.ReadLine();

            if (choice == "0")
            {
                Console.WriteLine("+------------------------------------------------------------+");
                Console.WriteLine($"| Остаток воды: {water} мл");
                Console.WriteLine($"| Остаток молока: {milk} мл");
                Console.WriteLine($"| Приготовлено американо: {americanoCount}");
                Console.WriteLine($"| Приготовлено латте: {latteCount}");
                Console.WriteLine($"| Выручка: {revenue} руб.");
                Console.WriteLine("+------------------------------------------------------------+");
                Console.WriteLine("Нажмите Enter для выхода в меню...");
                Console.ReadLine();
                return;
            }

            if (choice == "1")
            {
                if (canAmericano)
                {
                    water -= AMERICANO_WATER;
                    americanoCount++;
                    revenue += AMERICANO_PRICE;
                    Console.WriteLine($"| Ваш американо готов. Стоимость: {AMERICANO_PRICE} руб.");
                }
                else
                {
                    Console.WriteLine("| Не хватает воды для американо");
                }
            }
            else if (choice == "2")
            {
                if (canLatte)
                {
                    water -= LATTE_WATER;
                    milk  -= LATTE_MILK;
                    latteCount++;
                    revenue += LATTE_PRICE;
                    Console.WriteLine($"| Ваш латте готов. Стоимость: {LATTE_PRICE} руб.");
                }
                else
                {
                    if (water < LATTE_WATER)
                    {
                        Console.WriteLine("| Не хватает воды для латте");
                    }
                    if (milk < LATTE_MILK)
                    {
                        Console.WriteLine("| Не хватает молока для латте");
                    }
                }
            }
        }
    }

    private static int ReadInt(string prompt, int min)
    {
        while (true)
        {
            Console.Write(prompt);
            string? s = Console.ReadLine();
            if (int.TryParse(s, out int v) && v >= min)
            {
                return v;
            }
            Console.WriteLine("| Ошибка ввода. Повторите.");
        }
    }
}


