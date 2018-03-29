using System.Collections.Generic;
using System.Linq;
using static MarsRoverKata.Domain.Direction;

namespace MarsRoverKata.Domain
{
    public class Navigator
    {
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
    }
}