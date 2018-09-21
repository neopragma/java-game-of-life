using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Game
    {
        private List<List<Cell>> _grid;

        public Game(int width, int height)
        {
            Width = width;
            Height = height;

            _grid = Enumerable
                .Range(0, height)
                .Select(x => Enumerable
                    .Repeat(Cell.DEAD, width)
                    .ToList())
                .ToList();
        }

        public IEnumerable<IEnumerable<Cell>> Grid { get { return _grid; } }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public void ToggleState(int x, int y)
        {
            if (_grid[y][x] == Cell.ALIVE)
            {
                _grid[y][x] = Cell.DEAD;
            }
            else
            {
                _grid[y][x] = Cell.ALIVE;
            }
        }

        public void SpawnNextGeneration()
        {
            var clonedGrid = CreateShallowCopyOfGrid();
            var oldGrid = _grid;
            _grid = clonedGrid;

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    _grid[y][x] = CellRules.GetNextCellGeneration(oldGrid[y][x], GetNeighbors(oldGrid, x, y));
                }
            }
        }

        private IEnumerable<Cell> GetNeighbors(List<List<Cell>> grid, int x, int y)
        {
            var neighbors = new List<Cell>();

            for (int row = -1; row < 2; row++)
            {
                var neighborY = y + row;
                if (neighborY < 0 || neighborY >= Height) { continue; }

                for (int col = -1; col < 2; col++)
                {
                    if (row == 0 && col == 0) { continue; }

                    var neighborX = x + col;

                    if (neighborX < 0 || neighborX >= Width) { continue; }

                    neighbors.Add(grid[neighborY][neighborX]);
                }
            }

            return neighbors;
        }

        private List<List<Cell>> CreateShallowCopyOfGrid()
        {
            return _grid.Select(y => y.ToList()).ToList();
        }
    }
}
