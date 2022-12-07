using CSharp_AoC.day1;
using CSharp_AoC.day2;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the 2022 Advent of Code!\n");

        do
        {
            Console.Write("Enter a day: ");
            string inputString = Console.ReadLine();
            if (!int.TryParse(inputString, out int day) || !IsDayValid(day))
            {
                Console.WriteLine($"\n{day} is not a valid day!\n");
                continue;
            }
            Console.Write("Enter part 1 or 2: ");
            inputString = Console.ReadLine();
            if(!int.TryParse(inputString, out int part) || (part < 1 && part > 2))
            {
                Console.WriteLine($"{inputString} is not a valid part!\n");
                continue;
            }

            string input = GetFileContents(day);
            SolveProblem(day, part, input);
        } while (true);
    }

    private static void SolveProblem(int day, int part, string input)
    {
        switch (day)
        {
            case 1:
                _ = new Day1(part, input);
                break;
            case 2:
                _ = new Day2(part, input);
                break;
            case 3:
                _ = new Day3(part, input);
                break;
            case 4:
                _ = new Day4(part, input);
                break;
            case 5:
                _ = new Day5(part, input);
                break;
            case 6:
                _ = new Day6(part, input);
                break;
            case 7:
                _ = new Day7(part, input);
                break;
            default:
                break;
        }
    }

    private static bool IsDayValid(int day)
    {
        bool isValid = false;
        if(day >= 1 && day <= 25)
        {
            isValid = true;
        }

        return isValid;
    }

    public static string GetFileContents(int day)
    {
        string filePath = $"C:\\Users\\trist\\Repos\\AdventOfCode\\year2022\\CSharp AoC\\CSharp AoC\\day{day}\\input.txt";
        return File.ReadAllText(filePath);
    }
}