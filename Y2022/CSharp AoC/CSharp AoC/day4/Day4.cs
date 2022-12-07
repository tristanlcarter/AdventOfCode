namespace CSharp_AoC.day2
{
    internal class Day4
    {
        private string _input;

        public Day4(int part, string input)
        {
            _input = input;

            if (int.Equals(part, 1))
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
            int numberOfPairs = 0;
            var lines = _input.Split("\r\n");
            foreach (var line in lines)
            {
                var ranges = line.Split(",");
                var fromTo1 = ranges[0].Split("-").Select(int.Parse);
                var fromTo2 = ranges[1].Split("-").Select(int.Parse);
                Range r1 = new(fromTo1.First(), fromTo1.Last());
                Range r2 = new(fromTo2.First(), fromTo2.Last());

                if (ContainsRange(r1, r2) || ContainsRange(r2, r1))
                {
                    numberOfPairs++;
                }
            }

            Console.WriteLine($"\nThe total number of pairs that contain the other are: {numberOfPairs}\n");
        }

        private void PartTwo()
        {
            int numberOfPairs = 0;
            var lines = _input.Split("\r\n");
            foreach (var line in lines)
            {
                var ranges = line.Split(",");
                var fromTo1 = ranges[0].Split("-").Select(int.Parse);
                var fromTo2 = ranges[1].Split("-").Select(int.Parse);
                Range r1 = new(fromTo1.First(), fromTo1.Last());
                Range r2 = new(fromTo2.First(), fromTo2.Last());

                if (OverlapsRange(r1, r2) || OverlapsRange(r2, r1))
                {
                    numberOfPairs++;
                }
            }

            Console.WriteLine($"\nThe total number of pairs that overlap the other are: {numberOfPairs}\n");
        }

        private bool ContainsRange(Range r1, Range r2) => r1.From <= r2.From && r1.To >= r2.To;

        private bool OverlapsRange(Range r1, Range r2) => r1.To >= r2.From && r1.From <= r2.To;

        struct Range{
            public int From;
            public int To;
            public Range(int f, int t) { From = f; To = t; }
        };
    }
}
