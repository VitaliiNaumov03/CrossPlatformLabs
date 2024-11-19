namespace Lab2.Tests;

public class UnitTest1
{
    [Fact]
    public void TestCalculateDeletionTimes_StandardInput()
    {
        int n = 10, k = 2;

        var expected = new Dictionary<int, int>
        {
            { 2, 1 }, { 4, 2 }, { 6, 3 }, { 8, 4 }, { 10, 5 },
            { 3, 6 }, { 7, 7 }, { 5, 8 }, { 9, 9 }, { 1, 0 }
        };

        var actual = Program.CalculateDeletionTimes(n, k);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestCalculateDeletionTimes_SmallInput()
    {
        int n = 5, k = 1;

        var expected = new Dictionary<int, int>
        {
            { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 }, { 5, 5 }
        };

        var actual = Program.CalculateDeletionTimes(n, k);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestReadInput_ValidFile()
    {
        string inputPath = "test_input.txt";
        File.WriteAllText(inputPath, "10 2 3\n1,2,3");

        var (n, k, l, queries) = Program.ReadInput(inputPath);

        Assert.Equal(10, n);
        Assert.Equal(2, k);
        Assert.Equal(3, l);
        Assert.Equal(new[] { 1, 2, 3 }, queries);

        File.Delete(inputPath);
    }

    [Fact]
    public void TestWriteOutput()
    {
        // Тест записи корректного вывода в файл
        string outputPath = "test_output.txt";
        var queries = new[] { 1, 2, 3 };
        var deletionTimes = new Dictionary<int, int>
        {
            { 1, 1 }, { 2, 2 }, { 3, 3 }
        };

        Program.WriteOutput(outputPath, queries, deletionTimes);

        var output = File.ReadAllText(outputPath);
        Assert.Equal("123", output);

        File.Delete(outputPath);
    }
    [Fact]
    public void TestCalculateDeletionTimes_AllElementsDeletedInOnePass()
    {
        int n = 5, k = 1;

        var expected = new Dictionary<int, int>
        {
            { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 }, { 5, 5 }
        };

        var actual = Program.CalculateDeletionTimes(n, k);

        Assert.Equal(expected, actual);
    }
}