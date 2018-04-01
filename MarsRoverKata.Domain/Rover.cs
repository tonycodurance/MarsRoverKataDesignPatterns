using static MarsRoverKata.Domain.Direction;

namespace MarsRoverKata.Domain
{
    public class Rover
    {
        private readonly Grid _grid;
        
        public readonly Bearing Bearing = new Bearing(North, new Coordinate(0, 0));
        private readonly OrientationStateHandler _leftOrientationStateHandler= new LeftOrientationStateHandler();
        private readonly OrientationStateHandler _rightOrientationStateHandler = new RightOrientationStateHandler();

        public Rover(Grid grid)
        {
            _grid = grid;
        }

        public string Execute(string command)
        {   
            foreach (var character in command)
            {
                if (character == 'L')
                {
                    _leftOrientationStateHandler.Rotate(this);
                }

                if (character == 'R')
                {
                    _rightOrientationStateHandler.Rotate(this);
                }
                
                if (character == 'M')
                {
                    Move();
                }
            }
            
            return Bearing.Coordinate.X + ":" + Bearing.Coordinate.Y + ":" + (char)Bearing.Direction;
        }

        private void Move()
        {
            Bearing.Coordinate = _grid.NextCoordinateFor(Bearing.Direction, Bearing.Coordinate);
        }
    }
}