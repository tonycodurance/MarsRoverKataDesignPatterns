using static MarsRoverKata.Domain.Direction;

namespace MarsRoverKata.Domain
{
    public class Rover
    {
        private Direction direction = North;

        private Coordinate coordinate = new Coordinate(0, 0);
        private readonly Navigator navigator;

        public Rover(Navigator navigator)
        {
            this.navigator = navigator;
        }

        public string Execute(string command)
        {
            foreach (var character in command)
            {
                if (character == 'R')
                {
                    direction = navigator.Right(direction);
                }

                if (character == 'L')
                {
                    direction = navigator.Left(direction);
                }

                if (character == 'M')
                {
                    coordinate = navigator.Move(direction, coordinate);
                }
            }
            return coordinate.X + ":" + coordinate.Y + ":" + (char)direction;
        }
    }
}