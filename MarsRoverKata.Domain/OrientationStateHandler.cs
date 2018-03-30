using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata.Domain
{
    public abstract class OrientationStateHandler
    {
        protected Direction CalculateOrientation(List<Direction> rotations, Direction orientation)
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
        
        public abstract void Rotate(Rover rover);
    }
}