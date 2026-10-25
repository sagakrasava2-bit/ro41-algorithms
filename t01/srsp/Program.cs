using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество секунд: ");
        if (!int.TryParse(Console.ReadLine(), out int totalSeconds) || totalSeconds < 0)
        {
            Console.WriteLine("Ошибка ввода.");
            return;
        }

        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 3600;

        Console.WriteLine($"{hours} ч. {minutes} мин. {seconds} сек.");
    }
}
