using System;
using FluentAssertions;
using GameOfLife.ConsoleApp.Util.Formatters;
using Xunit;

namespace GameOfLife.ConsoleApp.Tests.Util.Formatters
{
    public class ConsoleFormatterTests
    {
        [Fact]
        public void Format_GivenAGridWithASingleDeadCell_WillPrintACenteredDot()
        {
            var game = new Game(1, 1);

            var output = ConsoleFormatter.Format(game);

            output.Should().Be($"·{Environment.NewLine}");
        }

        [Fact]
        public void Format_GivenAGridWithASingleAliveCell_WillPrintACapitalX()
        {
            var game = new Game(1, 1);
            game.ToggleState(0, 0);

            var output = ConsoleFormatter.Format(game);

            output.Should().Be($"X{Environment.NewLine}");
        }

        [Fact]
        public void Format_GivenA2x2GridWithAliveAndDeadCells_ReturnsAStringThatAllowsForVariableWidthAndHeightGrids()
        {
            var expectedOutput = string.Join(
                Environment.NewLine,
                "X·",
                "·X"
            );
            expectedOutput += Environment.NewLine;

            var game = new Game(2, 2);
            game.ToggleState(0, 0);
            game.ToggleState(1, 1);

            var output = ConsoleFormatter.Format(game);

            output.Should().Be(expectedOutput);
        }
    }
}
