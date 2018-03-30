using System.Collections.Generic;
using static MarsRoverKata.Domain.Direction;

namespace MarsRoverKata.Domain
{
    public class RightOrientationStateHandler : OrientationStateHandler
    {
        public override void Rotate(Rover rover)
        {
            var rightRotations = new List<Direction> { North, East, South, West };
            rover.Direction = CalculateOrientation(rightRotations, rover.Direction);
        }
    }
}