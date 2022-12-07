namespace CSharp_AoC.day2
{
    internal class Day6
    {
        private string _input;

        public Day6(int part, string input)
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
            var markerIndex = FindMarker(4);
            Console.WriteLine($"\nThe first marker appears at: {markerIndex}\n");
        }

        private void PartTwo()
        {
            var markerIndex = FindMarker(14);
            Console.WriteLine($"\nThe first marker appears at: {markerIndex}\n");
        }

        private int FindMarker(int markerLength)
        {
            int markerIndex = 0;
            Queue<char> marker = new();

            var inputCharacters = _input.Chunk(1);
            for (int i = 0; i < inputCharacters.Count(); i++)
            {
                var ch = inputCharacters.ElementAt(i)[0];
                marker.Enqueue(ch);

                if (marker.Count == markerLength+1)
                {
                    marker.Dequeue();
                }
                if(marker.Count == markerLength)
                {
                    int numberOfDistinct = marker.Distinct().Count();
                    if(numberOfDistinct == markerLength)
                    {
                        markerIndex = i + 1;
                        break;
                    }
                }

            }

            return markerIndex;
        }
    }
}
