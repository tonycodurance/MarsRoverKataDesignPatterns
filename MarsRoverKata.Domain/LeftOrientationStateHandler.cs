using System.Collections.Generic;
using System.Linq;
using static MarsRoverKata.Domain.Direction;

namespace MarsRoverKata.Domain
{
    public class LeftOrientationStateHandler : OrientationStateHandler
    {
        public override void Handle(Rover rover)
        {
            var leftRotations = new List<Direction> { North, West, South, East };
            rover.Direction = CalculateOrientation(leftRotations, rover.Direction);
        }
    }
}