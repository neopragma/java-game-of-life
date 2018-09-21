using System;
using System.Text;
using System.Threading;
using GameOfLife.ConsoleApp.Util.Formatters;

namespace GameOfLife.ConsoleApp
{
    public class App
    {
        private const int SLEEP_INTERVAL = 500;
        private Game _game;

        public void Run()
        {
            Console.Clear();
            Console.WriteLine(MakeHeader());
            BuildGameBoardAndToggleCellsAlive();

            while (true)
            {
                PrintGeneration();
                Console.WriteLine("Press 'Q' to Quit, Press 'C' to continue");
                var input = Console.ReadKey(false);

                if (input.Key == ConsoleKey.Q)
                {
                    break;
                }

                if (input.Key == ConsoleKey.C)
                {
                    _game.SpawnNextGeneration();
                }
            }
        }

        private void PrintGeneration()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendJoin(
                Environment.NewLine,
                MakeHeader(),
                ConsoleFormatter.Format(_game)
            );
            Console.Clear();
            Console.WriteLine(stringBuilder.ToString());
        }

        private void BuildGameBoardAndToggleCellsAlive()
        {
            int width = GetDimension("width");
            int height = GetDimension("height");

            _game = new Game(width, height);

            int percentAlive = GetPercentAlive();

            ToggleCellsAlive(percentAlive);
        }

        private void ToggleCellsAlive(int percentAlive)
        {
            var random = new Random();

            for (int row = 0; row < _game.Height; row++)
            {
                for (int col = 0; col < _game.Width; col++)
                {
                    var rand = random.Next(101);
                    if (rand <= percentAlive)
                    {
                        _game.ToggleState(col, row);
                    }
                }
            }
        }

        private int GetDimension(string dimension)
        {
            while (true)
            {
                System.Console.Write($"Enter {dimension} of grid (number greater than 0): ");
                var parsedValue = int.TryParse(Console.ReadLine(), out int inputValue);

                if (!parsedValue || inputValue <= 0)
                {
                    System.Console.WriteLine("Invalid input. Please enter a number greater than 0.");
                    continue;
                }

                return inputValue;
            }
        }

        private int GetPercentAlive()
        {
            while (true)
            {
                System.Console.Write($"Enter the rough percent of cells you would like alive (0-100): ");
                var parsedValue = int.TryParse(Console.ReadLine(), out int inputValue);

                if (!parsedValue || inputValue < 0 || inputValue > 100)
                {
                    System.Console.WriteLine("Invalid input. Please enter a number between 0-100.");
                    continue;
                }

                return inputValue;
            }
        }

        private string MakeHeader()
        {
            return string.Join(
                Environment.NewLine,
                "#########################",
                "# Conway's Game Of Life #",
                "#########################"
            );
        }
    }
}
