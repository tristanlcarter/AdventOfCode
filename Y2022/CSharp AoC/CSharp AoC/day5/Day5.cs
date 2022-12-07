using System.Text.RegularExpressions;

namespace CSharp_AoC.day2
{
    internal class Day5
    {
        private string _input;

        private List<Stack<char>> _stacks;

        public Day5(int part, string input)
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
            var commands = SeparateStacksFromCommands();
            FollowCommands(commands);
            string passphrase = GetPassphrase();

            Console.WriteLine($"\nThe letters at the top of each stack are: {passphrase}\n");
        }

        private void PartTwo()
        {
            var commands = SeparateStacksFromCommands();
            FollowCommands(commands, true);
            string passphrase = GetPassphrase();

            Console.WriteLine($"\nThe letters at the top of each stack are: {passphrase}\n");
        }

        private void FollowCommands(string commands, bool moveMultiple = false)
        {
            foreach(var line in commands.Split("\r\n"))
            {
                var match = Regex.Match(line, @"move (.*) from (.*) to (.*)");
                var count = int.Parse(match.Groups[1].Value);
                var from = int.Parse(match.Groups[2].Value) - 1;
                var to = int.Parse(match.Groups[3].Value) - 1;

                if (moveMultiple)
                    MoveCratesTwo(count, from, to); 
                else
                    MoveCratesOne(count, from, to);
            }
        }

        private void MoveCratesOne(int count, int from, int to)
        {
            for(int i = 0; i < count; i++)
            {
                var crate = _stacks[from].Pop();
                _stacks[to].Push(crate);
            }
        }

        private void MoveCratesTwo(int count, int from, int to)
        {
            Stack<char> held = new();
            for (int i = 0; i < count; i++)
            {
                held.Push(_stacks[from].Pop());
            }

            while(held.Count != 0)
            {
                _stacks[to].Push(held.Pop());
            }
        }

        private string GetPassphrase()
        {
            string passphrase = "";
            foreach(var stack in _stacks)
            {
                passphrase += stack.Pop().ToString();
            }

            return passphrase;
        }

        private string SeparateStacksFromCommands()
        {
            var split = _input.Split("\r\n\r\n");
            var commands = split[1];
            var stackDefs = split[0].Split("\r\n");

            _stacks = stackDefs.Last().Chunk(4).Select(s => new Stack<char>()).ToList();

            foreach(var line in stackDefs.Reverse().Skip(1))
            {
                foreach (var (stack, item) in _stacks.Zip(line.Chunk(4)))
                {
                    if(item[1] != ' ')
                    {
                        stack.Push(item[1]);
                    }
                }
            }

            return commands;
        }
    }
}
