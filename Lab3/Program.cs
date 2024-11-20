using System;
using System.IO;
using System.Collections.Generic;

public class Program
{
    static readonly string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\INPUT.txt");
    static readonly string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\OUTPUT.txt");

    static int Main()
    {
        // Зчитування вхідних даних
        List<string> input = new List<string>();
        
        try{
            input = File.ReadAllLines(inputPath).ToList();
            if (!InputFileIsCorrect(input))
                throw new FormatException("Файл INPUT.txt повинен мати 8 рядків по 8 символів");
        }
        catch (Exception e){
            Console.Error.WriteLine($"ПОМИЛКА: {e.Message}");
            return 1;
        }

        File.WriteAllText(outputPath, CalculateWorkers(input).ToString());
        return 0;
    }

    public static bool InputFileIsCorrect(List<string> input){
        if (input.Count != 8) return false;
        foreach (string line in input){
            if (line.Length != 8) return false;
        }
        return true;
    }

    public static int CalculateWorkers(List<string> input){
        int pattern1Errors = 0; // Помилки для еталону 1 (початок з 'W')
        int pattern2Errors = 0; // Помилки для еталону 2 (початок з 'B')

        // Проходимо по кожній клітинці дошки
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                // Обчислюємо, яка плитка має бути за шаховим візерунком
                char expectedPattern1 = ((i + j) % 2 == 0) ? 'W' : 'B';
                char expectedPattern2 = ((i + j) % 2 == 0) ? 'B' : 'W';

                // Якщо поточна плитка не збігається з еталоном, це помилка
                if (input[i][j] != expectedPattern1) pattern1Errors++;
                if (input[i][j] != expectedPattern2) pattern2Errors++;
            }
        }

        int numOfWorkers = Math.Min(pattern1Errors, pattern2Errors);
        return numOfWorkers > 0 ? numOfWorkers : 1;
    }
}