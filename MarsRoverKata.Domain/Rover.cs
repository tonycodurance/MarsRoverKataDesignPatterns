using static MarsRoverKata.Domain.Direction;

namespace MarsRoverKata.Domain
{
    public class Rover
    {
        private readonly Grid _grid;
        
        public Direction Direction { get; set; } = North;
        public Coordinate Coordinate { get; private set; } = new Coordinate(0, 0);
        public OrientationStateHandler OrientationStateHandler { private get; set; }

        public Rover(Grid grid)
        {
            _grid = grid;
            OrientationStateHandler = new RightOrientationStateHandler();
        }

        public string Execute(string command)
        {   
            foreach (var character in command)
            {
                if (character == 'L')
                {
                    OrientationStateHandler = new LeftOrientationStateHandler();
                    Rotate();
                }

                if (character == 'R')
                {
                    OrientationStateHandler = new RightOrientationStateHandler();
                    Rotate();
                }
                
                if (character == 'M')
                {
                    Move();
                }
            }
            
            return Coordinate.X + ":" + Coordinate.Y + ":" + (char)Direction;
        }
        
        private void Rotate()
        {
            OrientationStateHandler.Rotate(this);
        }

        private void Move()
        {
            Coordinate = _grid.NextCoordinateFor(Direction, Coordinate);
        }
    }
}