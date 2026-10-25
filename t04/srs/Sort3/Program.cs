using System;

class Program
{
    static void Main()
    {
        int a, b, c;

        a = 3; b = 1; c = 2;
        Order.Sort3(ref a, ref b, ref c);
        Console.WriteLine("3 1 2 -> " + a + " " + b + " " + c);

        a = 1; b = 2; c = 3;
        Order.Sort3(ref a, ref b, ref c);
        Console.WriteLine("1 2 3 -> " + a + " " + b + " " + c);

        a = 3; b = 2; c = 1;
        Order.Sort3(ref a, ref b, ref c);
        Console.WriteLine("3 2 1 -> " + a + " " + b + " " + c);

        a = 2; b = 2; c = 1;
        Order.Sort3(ref a, ref b, ref c);
        Console.WriteLine("2 2 1 -> " + a + " " + b + " " + c);

        a = 5; b = 5; c = 5;
        Order.Sort3(ref a, ref b, ref c);
        Console.WriteLine("5 5 5 -> " + a + " " + b + " " + c);
    }
}

static class Order
{
    public static void Swap(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }

    public static void Sort3(ref int a, ref int b, ref int c)
    {
        if (a > b) Swap(ref a, ref b);
        if (b > c) Swap(ref b, ref c);
        if (a > b) Swap(ref a, ref b);
    }
}
