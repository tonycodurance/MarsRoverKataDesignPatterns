﻿using System.Collections.Generic;
using static MarsRoverKata.Domain.Direction;

namespace MarsRoverKata.Domain
{
    public class LeftOrientationStateHandler : OrientationStateHandler
    {
        public override void Rotate(Rover rover)
        {
            var leftRotations = new List<Direction> { North, West, South, East };
            rover.Direction = CalculateOrientation(leftRotations, rover.Direction);
        }
    }
}