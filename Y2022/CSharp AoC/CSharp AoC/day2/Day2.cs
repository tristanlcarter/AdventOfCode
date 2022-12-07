namespace CSharp_AoC.day2
{
    internal class Day2
    {
        private string _input;

        public Day2(int part, string input)
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
            var total = GetTotalScore();
            Console.WriteLine($"\nTotal score is: {total}\n");
        }

        private void PartTwo()
        {
            var total = GetTotalAlteredScore();
            Console.WriteLine($"\nTotal altered score is: {total}\n");
        }

        private int GetTotalScore()
        {
            var matches = _input.Split("\r\n");
            int score = 0;
            foreach(string match in matches)
            {
                char opponent = match[0];
                char yours = match[2];
                int matchPoints = MatchPoints(opponent, yours);

                score += matchPoints + ConvertCharToPoints(yours);
            }

            return score;
        }
        private int GetTotalAlteredScore()
        {
            var matches = _input.Split("\r\n");
            int score = 0;
            foreach (string match in matches)
            {
                char opponent = match[0];
                char yours = match[2];

                yours = ChangeUpYourMove(opponent, yours);

                int matchPoints = MatchPoints(opponent, yours);

                score += matchPoints + ConvertCharToPoints(yours);
            }

            return score;
        }
        private int MatchPoints(char opponent, char yours)
        {
            // On a Loss!
            int win = 0;
            if ((char.Equals(yours, 'X') && char.Equals(opponent, 'A'))
                || (char.Equals(yours, 'Y') && char.Equals(opponent, 'B'))
                || (char.Equals(yours, 'Z') && char.Equals(opponent, 'C')))
            {
                // Draw!
                win = 3;
            }
            else if ((char.Equals(yours, 'X') && !char.Equals(opponent, 'B'))
                || (char.Equals(yours, 'Y') && !char.Equals(opponent, 'C'))
                || (char.Equals(yours, 'Z') && !char.Equals(opponent, 'A')))
            {
                // Win!
                win = 6;
            }

            return win;
        }

        private char ChangeUpYourMove(char opponent, char yours)
        {
            char newMove = yours;
            switch (yours)
            {
                case 'X':
                    if (char.Equals(opponent, 'A'))
                    {
                        newMove = 'Z';
                    }
                    else if (char.Equals(opponent, 'C'))
                    {
                        newMove = 'Y';
                    }
                    break;
                case 'Y':
                    if (char.Equals(opponent, 'A'))
                    {
                        newMove = 'X';
                    }
                    else if (char.Equals(opponent, 'C'))
                    {
                        newMove = 'Z';
                    }
                    break;
                case 'Z':
                    if (char.Equals(opponent, 'A'))
                    {
                        newMove = 'Y';
                    }
                    else if (char.Equals(opponent, 'C'))
                    {
                        newMove = 'X';
                    }
                    break;
                default:
                    break;
            }

            return newMove;
        }

        private int ConvertCharToPoints(char character)
        {
            int points = 0;
            switch (character)
            {
                case 'X':
                    points = 1;
                    break;
                case 'Y':
                    points = 2;
                    break;
                case 'Z':
                    points = 3;
                    break;
                default:
                    break;
            }
            return points;
        }
    }
}
