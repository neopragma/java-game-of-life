using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GameOfLife;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameTests
    {
        [Fact]
        public void Constructor_GivenAHeightAndWidth_Creates2dGridOfDeadCells()
        {
            var game = new Game(2, 2);
            var expectedGrid = new List<List<Cell>>
            {
                new List<Cell> { Cell.DEAD, Cell.DEAD },
                new List<Cell> { Cell.DEAD, Cell.DEAD }
            };

            game.Grid.ShouldBeEquivalentTo(expectedGrid);
        }

        [Fact]
        public void ToggleState_GivenAZeroBasedXandYCoordinateAndAnAliveCell_UpdatesCellToBeDead()
        {
            var game = new Game(2, 2);

            game.ToggleState(0, 0);

            game.Grid.ElementAt(0).ElementAt(0).Should().Be(Cell.ALIVE);

            game.ToggleState(0, 0);

            game.Grid.ElementAt(0).ElementAt(0).Should().Be(Cell.DEAD);
        }

        [Fact]
        public void SpawnNextGeneration_GivenAValidGameGridWithRandomNeighbors_WillUpdateGridFollowingCellRules()
        {
            var game = new Game(3, 3);

            var expectedGrid = new List<List<Cell>>
            {
                new List<Cell> { Cell.DEAD, Cell.ALIVE, Cell.ALIVE },
                new List<Cell> { Cell.DEAD, Cell.DEAD, Cell.ALIVE },
                new List<Cell> { Cell.DEAD, Cell.DEAD, Cell.DEAD }
            };
            game.ToggleState(0, 0);
            game.ToggleState(1, 0);
            game.ToggleState(2, 0);
            game.ToggleState(2, 1);

            game.SpawnNextGeneration();

            game.Grid.ShouldBeEquivalentTo(expectedGrid);
        }
    }
}
