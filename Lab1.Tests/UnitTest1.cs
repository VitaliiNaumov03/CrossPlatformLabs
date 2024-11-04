namespace Lab1.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.Equal("10117", Program.FindMinNumber(5, 15));
        Assert.Equal("97111", Program.FindMaxNumber(5, 15));
    }

    [Fact]
    public void Test2()
    {
        Assert.Equal("NO SOLUTION", Program.FindMinNumber(10, 1));
        Assert.Equal("NO SOLUTION", Program.FindMaxNumber(10, 1));
    }

    [Fact]
    public void Test3()
    {
        Assert.Equal("100111", Program.FindMinNumber(6, 20));
        Assert.Equal("991111", Program.FindMaxNumber(6, 20));
    }

    [Fact]
    public void Test4()
    {
        Assert.Equal("1114", Program.FindMinNumber(4, 10));
        Assert.Equal("7711", Program.FindMaxNumber(4, 10));
    }
    
    [Fact]
    public void Test5()
    {
        Assert.Equal("1000011", Program.FindMinNumber(7, 30));
        Assert.Equal("9999111", Program.FindMaxNumber(7, 30));
    }
}