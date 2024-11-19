using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    static string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\INPUT.txt");
    static string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\OUTPUT.txt");

    static int Main()
    {

        try
        {
            if (!File.Exists(inputPath))
                throw new Exception($"Файл {inputPath} не знайдено.");

            var (n, k, l, queries) = ReadInput(inputPath);

            var deletionTimes = CalculateDeletionTimes(n, k);

            WriteOutput(outputPath, queries, deletionTimes);

            Console.WriteLine($"Результат записано в файл {outputPath}");
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ПОМИЛКА: {ex.Message}");
            return -1;
        }
    }

    public static (int n, int k, int l, int[] queries) ReadInput(string inputPath)
    {
        var input = File.ReadAllText(inputPath).Split();
        if (input.Length != 4)
            throw new Exception("Файл INPUT.txt має некоректну кількість аргументів");

        int n = int.Parse(input[0]); // Кількість символів
        int k = int.Parse(input[1]); // Період видалення
        int l = int.Parse(input[2]); // Кількість запросів
        int[] queries = input[3].Split(',').Select(int.Parse).ToArray(); // Запити

        if (queries.Length != l)
            throw new Exception("Кількість запросів у файлі менше, ніж вказано в параметрі L");

        return (n, k, l, queries);
    }

    public static Dictionary<int, int> CalculateDeletionTimes(int n, int k)
    {
        var deletionTimes = new Dictionary<int, int>();
        var numbers = new List<int>();

        for (int i = 1; i <= n; i++)
            numbers.Add(i);

        int currNumDelTime = 1;

        while (numbers.Count >= k)
        {
            var toRemove = new List<int>();

            for (int i = k - 1; i < numbers.Count; i += k)
            {
                deletionTimes[numbers[i]] = currNumDelTime++;
                toRemove.Add(numbers[i]);
            }

            foreach (var num in toRemove)
                numbers.Remove(num);
        }

        foreach (var num in numbers)
        {
            if (!deletionTimes.ContainsKey(num))
                deletionTimes[num] = 0;
        }

        return deletionTimes;
    }

    public static void WriteOutput(string outputPath, int[] queries, Dictionary<int, int> deletionTimes)
    {
        using (StreamWriter writer = new StreamWriter(outputPath))
        {
            foreach (var query in queries)
            {
                if (deletionTimes.ContainsKey(query))
                    writer.Write(deletionTimes[query]);
                else
                    writer.Write(0); // Якщо символ не було видалено
            }
        }
    }
}