using System;
using System.Collections.Generic;
namespace Lab3.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData(new string[]
    {
        "WBWBWBWB",
        "BWBWBWBW",
        "WBWBWBWB",
        "BWBWBWBW",
        "WBWBWBWB",
        "BWBWBWBW",
        "WBWBWBWB",
        "BWBWBWBW"
    }, 1)] // Ідеальний шахматний патерн, мінімальна к-сть будівельників

    [InlineData(new string[]
    {
        "WWWWWWWW",
        "WWWWWWWW",
        "WWWWWWWW",
        "WWWWWWWW",
        "WWWWWWWW",
        "WWWWWWWW",
        "WWWWWWWW",
        "WWWWWWWW"
    }, 32)] // Всі плитки однакові

    [InlineData(new string[]
    {
        "BWBWBWBW",
        "WBWBWBWB",
        "BWBWBWBW",
        "WBWBWBWB",
        "BWBWBWBW",
        "WBWBWBWB",
        "BWBWBWBW",
        "WBWBWBWB"
    }, 1)] // Ідеальний шахматний патерн, але з чорною плиткою зверху

    [InlineData(new string[]
    {
        "WWBWBWBW",
        "BWBWBWBW",
        "WBWBWBWB",
        "BWBWBWBW",
        "WBWBWBWB",
        "BWBWBWBW",
        "WBWBWBWB",
        "BWBWBWBW"
    }, 7)] // Помилка лише в 1 рядку

    [InlineData(new string[]
    {
        "WBWBWBWW",
        "BWBWBWBW",
        "WBWBWBWB",
        "BWBWBWBW",
        "WBWBWBWB",
        "BWBWBWBW",
        "WBWBWBWB",
        "BWBWBWBW"
    }, 1)]

    [InlineData(new string[]
    {
        "WBWBWBWB",
        "WBWBWBWB",
        "WBWBWBWB",
        "WBWBWBWB",
        "WBWBWBWB",
        "WBWBWBWB",
        "WBWBWBWB",
        "WBWBWBWB"
    }, 32)] // Всі рядки однакові

    [InlineData(new string[]
    {
        "WBWBWBWW",
        "BWBWBBBW",
        "WBWBWWBW",
        "BWBWBWBW",
        "WBWBWBWB",
        "BWBWBWBW",
        "WBWBWBWB",
        "BWBWBWBW"
    }, 5)] // Декілька помилок у випадкових місцях
    
    public void TestCalculateWorkers(string[] input, int expected)
    {
        List<string> inputList = new List<string>(input);
        int result = Program.CalculateWorkers(inputList);
        Assert.Equal(expected, result);
    }
}