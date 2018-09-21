using System.Linq;
using FluentAssertions;
using GameOfLife;
using Xunit;

namespace GameOfLife.Tests
{
    public class CellRulesTests
    {
        [Theory]
        [InlineData(Cell.ALIVE, 0, Cell.DEAD)]
        [InlineData(Cell.ALIVE, 1, Cell.DEAD)]
        [InlineData(Cell.ALIVE, 2, Cell.ALIVE)]
        [InlineData(Cell.ALIVE, 3, Cell.ALIVE)]
        [InlineData(Cell.ALIVE, 4, Cell.DEAD)]
        [InlineData(Cell.ALIVE, 5, Cell.DEAD)]
        [InlineData(Cell.ALIVE, 6, Cell.DEAD)]
        [InlineData(Cell.ALIVE, 7, Cell.DEAD)]
        [InlineData(Cell.ALIVE, 8, Cell.DEAD)]
        [InlineData(Cell.DEAD, 0, Cell.DEAD)]
        [InlineData(Cell.DEAD, 1, Cell.DEAD)]
        [InlineData(Cell.DEAD, 2, Cell.DEAD)]
        [InlineData(Cell.DEAD, 3, Cell.ALIVE)]
        [InlineData(Cell.DEAD, 4, Cell.DEAD)]
        [InlineData(Cell.DEAD, 5, Cell.DEAD)]
        [InlineData(Cell.DEAD, 6, Cell.DEAD)]
        [InlineData(Cell.DEAD, 7, Cell.DEAD)]
        [InlineData(Cell.DEAD, 8, Cell.DEAD)]
        public void GetNextCellGeneration_GivenCurrentGenerationCellAndAliveNeighbors_ReturnsExpectedNextCellGeneration
            (Cell currentGenerationCell, int aliveNeighborCount, Cell expectedNextGenerationCell)
        {
            var aliveNeighbors = Enumerable
                .Repeat(Cell.ALIVE, aliveNeighborCount)
                .ToList();

            var result = CellRules.GetNextCellGeneration(currentGenerationCell, aliveNeighbors);

            result.Should().Be(expectedNextGenerationCell);
        }
    }
}
