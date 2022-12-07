namespace CSharp_AoC.day1
{
    internal class Day1
    {
        private string _input;

        public Day1(int part, string input)
        {
            _input = input;

            if(int.Equals(part, 1))
            {
                PartOne();
            }
            else
            {
                PartTwo();
            }
        }

        private void PartOne()
        {
            var calories = GetCaloriesFromInput();
            Console.WriteLine($"\nThe highest total calories held is: {calories.Last()}\n");
        }

        private void PartTwo()
        {
            var calories = GetCaloriesFromInput();
            var sum = 0;
            for (int i = calories.Count - 3; i < calories.Count; i++)
            {
                sum += calories[i];
            }

            Console.WriteLine($"\nThe top three sum is: {sum}\n");
        }

        private List<int> GetCaloriesFromInput()
        {
            var individual = _input.Split("\r\n\r\n");
            List<int> calorieList = new();
            
            for(int i = 0; i < individual.Length; i++)
            {
                int sum = individual[i].Split("\n").Select(int.Parse).Sum();
                calorieList.Add(sum);
            }

            calorieList.Sort();
            return calorieList;
        }
    }
}
