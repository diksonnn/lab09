using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static StreamWriter logger;

    static void Main(string[] args)
    {
        Console.Write("Введите натуральное число N: ");
        if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
        {
            Console.WriteLine("Некорректный ввод. Введите натуральное число больше 0.");
            return;
        }

        InitializeLogger();

        List<int> drawnNumbers = new List<int>();

        for (int i = 1; i <= N; i++)
        {
            int nextNumber = GetNextNumber(drawnNumbers, N);
            drawnNumbers.Add(nextNumber);

            Log($"Вытянуто число: {nextNumber}");
        }

        CloseLogger();

        Console.WriteLine("Лотерея завершена. Поздравляем с окончанием игры!");
    }

    private static int GetNextNumber(List<int> drawnNumbers, int N)
    {
        int nextNumber;
        do
        {
            nextNumber = new Random().Next(1, N + 1);
        } while (drawnNumbers.Contains(nextNumber));

        return nextNumber;
    }

    private static void InitializeLogger()
    {
        logger = new StreamWriter("log.txt");
        Log("Начало лотереи");
    }

    private static void Log(string message)
    {
        Console.WriteLine(message);
        logger.WriteLine(message);
    }

    private static void CloseLogger()
    {
        logger.Close();
    }
}