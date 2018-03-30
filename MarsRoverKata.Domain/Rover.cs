using static MarsRoverKata.Domain.Direction;

namespace MarsRoverKata.Domain
{
    public class Rover
    {
        private Direction direction = North;

        private Coordinate _coordinate = new Coordinate(0, 0);
        private readonly Navigator _navigator;
        private readonly Grid _grid;

        public Rover(Navigator navigator, Grid grid)
        {
            _navigator = navigator;
            _grid = grid;
        }

        public string Execute(string command)
        {
            foreach (var character in command)
            {
                if (character == 'R')
                {
                    direction = _navigator.Right(direction);
                }

                if (character == 'L')
                {
                    direction = _navigator.Left(direction);
                }

                if (character == 'M')
                {
                    _coordinate = _grid.NextCoordinateFor(direction, _coordinate);
                }
            }
            return _coordinate.X + ":" + _coordinate.Y + ":" + (char)direction;
        }
    }
}