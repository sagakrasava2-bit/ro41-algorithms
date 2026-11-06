using System;
using System.Text;

class Program
{
    static void Main()
    {
        // Тесты для CountWords
        RunWordTest("", 0);
        RunWordTest("   ", 0);
        RunWordTest(" a  b ", 2);
        RunWordTest("А роза упала на лапу Азора", 6);
        RunWordTest("Ахметов Ерлан", 2);

        Console.WriteLine(new string('-', 40));

        // Тесты для IsPalindrome
        RunPalindromeTest("", true);
        RunPalindromeTest("   ", true);
        RunPalindromeTest("А роза упала на лапу Азора", true);
        RunPalindromeTest("Ахметов Ерлан", false);

        Console.WriteLine(new string('-', 40));

        // Тесты для Initials
        RunInitialsTest("Ахметов Ерлан Серикұлы", "А. Е. С.");
        RunInitialsTest("Ахметов Ерлан", "А. Е.");
        RunInitialsTest("", "");
        RunInitialsTest("   ", "");

        Console.WriteLine(new string('-', 40));

        // Тесты для Repeat
        RunRepeatTest("abc", 3, "abcabcabc");
        RunRepeatTest("test", 0, "");
        RunRepeatTest("", 5, "");
    }

    static void RunWordTest(string input, int expected)
    {
        int actual = TextTools.CountWords(input);
        string status = (actual == expected) ? "OK" : "FAIL";
        Console.WriteLine($"CountWords(\"{input}\") | Ожидается: {expected} | Фактически: {actual} | [{status}]");
    }

    static void RunPalindromeTest(string input, bool expected)
    {
        bool actual = TextTools.IsPalindrome(input);
        string status = (actual == expected) ? "OK" : "FAIL";
        Console.WriteLine($"IsPalindrome(\"{input}\") | Ожидается: {expected} | Фактически: {actual} | [{status}]");
    }

    static void RunInitialsTest(string input, string expected)
    {
        string actual = TextTools.Initials(input);
        string status = (actual == expected) ? "OK" : "FAIL";
        Console.WriteLine($"Initials(\"{input}\") | Ожидается: \"{expected}\" | Фактически: \"{actual}\" | [{status}]");
    }

    static void RunRepeatTest(string s, int n, string expected)
    {
        string actual = TextTools.Repeat(s, n);
        string status = (actual == expected) ? "OK" : "FAIL";
        Console.WriteLine($"Repeat(\"{s}\", {n}) | Ожидается: \"{expected}\" | Фактически: \"{actual}\" | [{status}]");
    }
}

static class TextTools
{
    public static int CountWords(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return 0;
        }

        int count = 0;
        bool inWord = false;

        for (int i = 0; i < s.Length; i++)
        {
            if (!char.IsWhiteSpace(s[i]))
            {
                if (!inWord)
                {
                    inWord = true;
                    count++;
                }
            }
            else
            {
                inWord = false;
            }
        }
        return count;
    }

    public static bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return true;
        }

        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            while (left < right && !char.IsLetterOrDigit(s[left]))
            {
                left++;
            }
            while (left < right && !char.IsLetterOrDigit(s[right]))
            {
                right--;
            }

            if (char.ToLower(s[left]) != char.ToLower(s[right]))
            {
                return false;
            }

            left++;
            right--;
        }
        return true;
    }

    public static string Initials(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            return string.Empty;
        }

        // Разбиваем строку по пробелам вручную без LINQ и Regex
        char[] separators = new char[] { ' ', '\t', '\n', '\r' };
        string[] parts = fullName.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 0)
        {
            return string.Empty;
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].Length > 0)
            {
                sb.Append(char.ToUpper(parts[i][0])).Append(". ");
            }
        }

        return sb.ToString().Trim();
    }

    public static string Repeat(string s, int n)
    {
        if (string.IsNullOrEmpty(s) || n <= 0)
        {
            return string.Empty;
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            sb.Append(s);
        }
        return sb.ToString();
    }
}
