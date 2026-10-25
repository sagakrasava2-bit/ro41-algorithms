using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите два целых неотрицательных числа (a и b) через пробел: ");
        string input = Console.ReadLine();
        string[] parts = input?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts == null || parts.Length != 2 || 
            !int.TryParse(parts[0], out int a) || !int.TryParse(parts[1], out int b) || 
            a < 0 || b < 0 || (a == 0 && b == 0))
        {
            Console.WriteLine("Ошибка: некорректный ввод. Требуется два неотрицательных числа, не оба равные нулю.");
            return;
        }

        while (b != 0)
        {
            int r = a % b;
            a = b;
            b = r;
        }

        Console.WriteLine($"НОД = {a}");
    }
}
