using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите целое неотрицательное число n: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int n) || n < 0)
        {
            Console.WriteLine("Ошибка: введено некорректное значение. Требуется целое неотрицательное число.");
            return;
        }

        int temp = n;
        int count = 0;
        int sum = 0;

        do
        {
            sum += temp % 10;
            count++;
            temp /= 10;
        } while (temp > 0);

        Console.WriteLine($"Количество цифр: {count}");
        Console.WriteLine($"Сумма цифр: {sum}");
    }
}
