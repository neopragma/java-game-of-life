using System;
using System.Linq;
using System.Text;

namespace GameOfLife.ConsoleApp.Util.Formatters
{
    public class ConsoleFormatter
    {
        public static string Format(Game game)
        {
            var stringBuilder = new StringBuilder();

            foreach (var row in game.Grid)
            {
                foreach (var cell in row)
                {
                    if (cell == Cell.ALIVE)
                    {
                        stringBuilder.Append("X");
                    }
                    else
                    {
                        stringBuilder.Append("·");
                    }
                }

                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
    }
}
