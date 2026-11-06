using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Тесты BubbleSort и IsSorted ===");
        int[][] bubbleTests = new int[][]
        {
            new int[] { },
            new int[] { 5 },
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 5, 4, 3, 2, 1 },
            new int[] { 3, 1, 3, 2, 3 }
        };

        foreach (var arr in bubbleTests)
        {
            int[] original = (int[])arr.Clone();
            bool sortedBefore = ArrayAlgos.IsSorted(arr);
            int comparisons = ArrayAlgos.BubbleSort(arr);
            bool sortedAfter = ArrayAlgos.IsSorted(arr);

            Console.WriteLine($"До: [{string.Join(", ", original)}]");
            Console.WriteLine($"После: [{string.Join(", ", arr)}]");
            Console.WriteLine($"IsSorted до: {sortedBefore} | после: {sortedAfter} | Сравнений: {comparisons}");
            Console.WriteLine(new string('-', 40));
        }

        // Проверка на 1000 элементов (ожидается 999 сравнений)
        int[] thousand = new int[1000];
        for (int i = 0; i < 1000; i++) thousand[i] = i + 1;
        int comps1000 = ArrayAlgos.BubbleSort(thousand);
        Console.WriteLine($"Массив из 1000 элементов: сравнений = {comps1000}");
        Console.WriteLine(new string('=', 40));

        Console.WriteLine("=== Тесты CountOccurrences ===");
        int[] sortedArr = new int[] { 1, 2, 2, 2, 5, 7 };
        int[] targets = new int[] { 2, 1, 7, 3, 9 };

        Console.WriteLine($"Отсортированный массив: [{string.Join(", ", sortedArr)}]");
        foreach (var x in targets)
        {
            int count = ArrayAlgos.CountOccurrences(sortedArr, x);
            Console.WriteLine($"x = {x} -> вхождений: {count}");
        }
    }
}

static class ArrayAlgos
{
    public static bool IsSorted(int[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            if (a[i] > a[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    public static int BubbleSort(int[] a)
    {
        int comparisons = 0;
        int n = a.Length;
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < n - 1 - i; j++)
            {
                comparisons++;
                if (a[j] > a[j + 1])
                {
                    int temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped)
            {
                break;
            }
        }
        return comparisons;
    }

    public static int CountOccurrences(int[] sortedA, int x)
    {
        int lower = LowerBound(sortedA, x);
        int upper = UpperBound(sortedA, x);
        return upper - lower;
    }

    // Первый индекс элемента, который >= x
    private static int LowerBound(int[] a, int x)
    {
        int l = 0, r = a.Length;
        while (l < r)
        {
            int mid = l + (r - l) / 2;
            if (a[mid] >= x)
            {
                r = mid;
            }
            else
            {
                l = mid + 1;
            }
        }
        return l;
    }

    // Первый индекс элемента, который > x
    private static int UpperBound(int[] a, int x)
    {
        int l = 0, r = a.Length;
        while (l < r)
        {
            int mid = l + (r - l) / 2;
            if (a[mid] > x)
            {
                r = mid;
            }
            else
            {
                l = mid + 1;
            }
        }
        return l;
    }
}
