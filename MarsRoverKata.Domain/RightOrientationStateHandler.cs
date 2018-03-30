﻿using System.Collections.Generic;
using System.Linq;
using static MarsRoverKata.Domain.Direction;

namespace MarsRoverKata.Domain
{
    public class RightOrientationStateHandler : IOrientationStateHandler
    {
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

        public void Handle(Rover rover)
        {
            var rightRotations = new List<Direction> { North, East, South, West };
            rover.Direction = Calculate(rightRotations, rover.Direction);
        }
    }
}