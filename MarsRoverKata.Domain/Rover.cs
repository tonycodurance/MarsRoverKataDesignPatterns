using static MarsRoverKata.Domain.Direction;

namespace MarsRoverKata.Domain
{
    public class Rover
    {
        private readonly Grid _grid;
        
        public Direction Direction { get; set; } = North;
        public Coordinate Coordinate { get; private set; } = new Coordinate(0, 0);
        public OrientationStateHandler OrientationStateHandler { get; set; }

        public Rover()
        {
            OrientationStateHandler = new RightOrientationStateHandler();
            _grid = new Grid();
        }

        public void Rotate()
        {
            OrientationStateHandler.Handle(this);
        }

        public void Move()
        {
            Coordinate = _grid.NextCoordinateFor(Direction, Coordinate);
        }
    }
}