using static MarsRoverKata.Domain.Direction;

namespace MarsRoverKata.Domain
{
    public class Rover
    {
        private Direction _direction = North;

        private Coordinate _coordinate = new Coordinate(0, 0);
        private readonly Navigator _navigator;
        private readonly Grid _grid;

        public Rover(Navigator navigator, Grid grid)
        {
            this._navigator = navigator;
            this._grid = grid;
        }

        public string Execute(string command)
        {
            foreach (var character in command)
            {
                if (character == 'R')
                {
                    _direction = _navigator.Right(_direction);
                }

                if (character == 'L')
                {
                    _direction = _navigator.Left(_direction);
                }

                if (character == 'M')
                {
                    _coordinate = _grid.NextCoordinateFor(_direction, _coordinate);
                }
            }
            return _coordinate.X + ":" + _coordinate.Y + ":" + (char)_direction;
        }
    }
}