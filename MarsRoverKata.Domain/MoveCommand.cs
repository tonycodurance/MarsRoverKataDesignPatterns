namespace MarsRoverKata.Domain
{
    public class MoveCommand : ICommand
    {
        private readonly Grid _grid;

        public MoveCommand(Grid grid)
        {
            _grid = grid;
        }

        public Bearing Execute(Bearing bearing)
        {
            var newCoordinate = _grid.NextCoordinateFor(bearing.Direction, bearing.Coordinate);
            return new Bearing(newCoordinate, bearing.Direction);

        }
    }
}