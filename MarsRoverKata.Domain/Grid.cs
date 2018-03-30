using System.Collections.Generic;

namespace MarsRoverKata.Domain
{
    public class Grid
    {
        private const int MaxHeight = 10;
        private const int MaxWidth = 10;

        public Coordinate NextCoordinateFor(Direction direction, Coordinate coordinate)
        {
            var y = coordinate.Y;
            var x = coordinate.X;
            if (direction == Direction.North)
            {
                y = (y + 1) % MaxHeight;
            }
            if (direction == Direction.East)
            {
                x = (x + 1) % MaxWidth;
            }

            if (direction == Direction.West)
            {
                x = (x > 0) ? x - 1 : MaxWidth - 1;
            }

            if (direction == Direction.South)
            {
                y = (y > 0) ? y - 1 : MaxWidth - 1;
            }

            var newCoordinate = new Coordinate(x, y);

            return newCoordinate;
        }
    }
}