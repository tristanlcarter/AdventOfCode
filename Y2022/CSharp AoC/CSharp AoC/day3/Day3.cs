namespace CSharp_AoC.day2
{
    internal class Day3
    {
        private string _input;

        public Day3(int part, string input)
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
            int sum = _input.Split("\r\n")
                            .Select(line => line.Chunk(line.Length / 2))
                            .Select(GetCommonItemPriority)
                            .Sum();
            Console.WriteLine($"\nTotal score is: {sum}\n");
        }

        private void PartTwo()
        {
            int sum = _input.Split("\r\n")
                            .Chunk(3)
                            .Select(GetCommonItemPriority)
                            .Sum();
            Console.WriteLine($"\nTotal altered score is: {sum}\n");
        }

        private int GetCommonItemPriority(IEnumerable<IEnumerable<char>> texts) => (
            from ch in texts.First()
            where texts.All(text => text.Contains(ch))
            select ch < 'a' ? ch - 'A' + 27 : ch - 'a' + 1
        ).First();
    }
}
