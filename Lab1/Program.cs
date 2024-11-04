namespace Lab1;
public class Program
{
    static void Main()
    {
        int n, k;

        using (StreamReader reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\INPUT.txt"))){
            string[] input = reader.ReadLine().Split(' ');
            n = int.Parse(input[0]);
            k = int.Parse(input[1]);
        }

        string minNumber = FindMinNumber(n, k);
        string maxNumber = FindMaxNumber(n, k);

        using (StreamWriter writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\OUTPUT.txt"))){
            writer.Write(minNumber);
            if (minNumber != "NO SOLUTION") writer.Write('\n' + maxNumber);
        }
    }
    static readonly int[] segments = { 6, 2, 5, 5, 4, 5, 6, 3, 7, 6 }; // [0..9]

    public static string FindMinNumber(int n, int k)
    {
        string solution = "NO SOLUTION";
        int i = 1;
        if (k >= n * 2){
            solution = new string('1', n);
            k -= n * 2;

            while (i <= n && k >= 4)
            {
                solution = solution.Remove(i, 1).Insert(i, "0");
                k -= 4;
                i++;
            }

            i = n;
            while (i >= 1 && k > 0)
            {
                switch (solution[i - 1])
                {
                    case '1':
                        if (k == 1)
                        {
                            solution = solution.Remove(i - 1, 1).Insert(i - 1, "7");
                            k = 0;
                        }
                        else if (k == 2)
                        {
                            solution = solution.Remove(i - 1, 1).Insert(i - 1, "4");
                            k = 0;
                        }
                        else if (k == 3)
                        {
                            solution = solution.Remove(i - 1, 1).Insert(i - 1, "2");
                            k = 0;
                        }
                        else if (k == 4)
                        {
                            solution = solution.Remove(i - 1, 1).Insert(i - 1, "6");
                            k = 0;
                        }
                        else
                        {
                            solution = solution.Remove(i - 1, 1).Insert(i - 1, "8");
                            k -= 5;
                        }
                        break;
                    case '0':
                        solution = solution.Remove(i - 1, 1).Insert(i - 1, "8");
                        k--;
                        break;
                }
                i--;
            }

            if (k != 0) solution = "NO SOLUTION";
        }
        return solution;
    }

    public static string FindMaxNumber(int n, int k)
    {
        char[] result = new char[n];
        int totalSegments = k;
        
        for (int i = 0; i < n; i++)
        {
            for (int digit = 9; digit >= 0; digit--)
            {
                int neededSegments = segments[digit];
                int remainingPositions = n - i - 1;

                if (totalSegments - neededSegments >= remainingPositions * 2)
                {
                    result[i] = (char)('0' + digit);
                    totalSegments -= neededSegments;
                    break;
                }
            }
        }

        if (totalSegments != 0)
            return "NO SOLUTION";

        return new string(result);
    }
}