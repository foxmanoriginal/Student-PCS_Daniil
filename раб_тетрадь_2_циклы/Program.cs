using System;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("+------------------------------------------------------------+");
            Console.WriteLine("| Рабочая тетрадь 2 — Циклы: Меню заданий                    |");
            Console.WriteLine("+------------------------------------------------------------+");
            Console.WriteLine("| 1 - Задание 1: Ряды (e^x по Маклорену)");
            Console.WriteLine("| 2 - Задание 2: Счастливый билет");
            Console.WriteLine("| 3 - Задание 3: Сокращение дроби");
            Console.WriteLine("| 4 - Задание 4: Угадай число (0..63)");
            Console.WriteLine("| 5 - Задание 5: Кофейный аппарат");
            Console.WriteLine("| 6 - Задание 6: Лабораторный опыт");
            Console.WriteLine("| 7 - Задание 7: Колонизация Марса");
            Console.WriteLine("| 0 - Выход");
            Console.Write("| > ");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Task1_Maclaurin_1.Run();
                    break;
                case "2":
                    Task2_LuckyTicket.Run();
                    break;
                case "3":
                    Task3_ReduceFraction.Run();
                    break;
                case "4":
                    Task4_NumberGuesser.Run();
                    break;
                case "5":
                    Task5_CoffeeMachine.Run();
                    break;
                case "6":
                    Task6_LabExperiment.Run();
                    break;
                case "7":
                    Task7_MarsColonization.Run();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("| Неверный выбор. Нажмите Enter и попробуйте снова...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
