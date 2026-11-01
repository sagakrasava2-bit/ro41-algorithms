using System;

class Program
{
    static void Main()
    {
        int[][] testArrays = new int[][]
        {
            new int[] { 4, 1, 7, 3, 9 },
            new int[] { 5 },
            new int[] { -2, -7, -4 },
            new int[] { 2, 2, 2 }
        };

        foreach (var arr in testArrays)
        {
            // Создаем копию для вывода исходного состояния
            int[] original = (int[])arr.Clone();
            int x = 2;

            int sum = ArrayOps.Sum(arr);
            int minIndex = ArrayOps.IndexOfMin(arr);
            int countGreater = ArrayOps.CountGreater(arr, x);
            
            ArrayOps.Reverse(arr);

            Console.WriteLine($"Исходный массив: [{string.Join(", ", original)}]");
            Console.WriteLine($"Сумма: {sum}");
            Console.WriteLine($"Индекс минимума: {minIndex}");
            Console.WriteLine($"Элементов больше {x}: {countGreater}");
            Console.WriteLine($"После Reverse: [{string.Join(", ", arr)}]");
            Console.WriteLine(new string('-', 30));
        }
    }
}

static class ArrayOps
{
    public static int Sum(int[] a)
    {
        int sum = 0;
        for (int i = 0; i < a.Length; i++)
        {
            sum += a[i];
        }
        return sum;
    }

    public static int IndexOfMin(int[] a)
    {
        if (a.Length == 0) return -1;
        
        int minIndex = 0;
        int minVal = a[0];
        
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] < minVal)
            {
                minVal = a[i];
                minIndex = i;
            }
        }
        return minIndex;
    }

    public static int CountGreater(int[] a, int x)
    {
        int count = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] > x)
            {
                count++;
            }
        }
        return count;
    }

    public static void Reverse(int[] a)
    {
        int left = 0;
        int right = a.Length - 1;
        while (left < right)
        {
            int temp = a[left];
            a[left] = a[right];
            a[right] = temp;
            left++;
            right--;
        }
    }
}
