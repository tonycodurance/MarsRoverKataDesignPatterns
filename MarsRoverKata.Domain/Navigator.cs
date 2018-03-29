using System.Collections.Generic;
using System.Linq;
using static MarsRoverKata.Domain.Direction;

namespace MarsRoverKata.Domain
{
    public class Navigator
    {
        private const int MaxHeight = 10;
        private const int MaxWidth = 10;

        public Direction Right(Direction orientation)
        {
            var rightRotations = new List<Direction> { North, East, South, West };

            return Calculate(rightRotations, orientation);
        }

        public Direction Left(Direction orientation)
        {
            var leftRotations = new List<Direction> { North, West, South, East };

            return Calculate(leftRotations, orientation);
        }

        private Direction Calculate(List<Direction> rotations, Direction orientation)
        {
            var newOrientationIndex = 0;
            var currentOrientationIndex = rotations.FindIndex(
                or => or == orientation
            );

            var currentOrientationAtTheEndOfList =
                currentOrientationIndex == rotations.Count - 1;

            if (!currentOrientationAtTheEndOfList)
            {
                newOrientationIndex = currentOrientationIndex + 1;
            }

            return rotations.ElementAt(newOrientationIndex);
        }

        public Coordinate Move(Direction direction, Coordinate coordinate)
        {
            int y = coordinate.Y;
            int x = coordinate.X;
            if (direction == North)
            {
                y = (y + 1) % MaxHeight;
            }
            if (direction == East)
            {
                x = (x + 1) % MaxWidth;
            }

            if (direction == West)
            {
                x = (x > 0) ? x - 1 : MaxWidth - 1;
            }

            if (direction == South)
            {
                y = (y > 0) ? y - 1 : MaxWidth - 1;
            }

            return new Coordinate(x, y);
        }
    }
}