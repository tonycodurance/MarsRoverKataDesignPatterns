namespace MarsRoverKata.Domain
{
    public class RightCommand : ICommand
    {
        private readonly Navigator _navigator;

        public RightCommand(Navigator navigator)
        {
            _navigator = navigator;
        }

        public Bearing Execute(Bearing bearing)
        {
            return new Bearing(bearing.Coordinate, _navigator.Right(bearing.Direction));
        }
    }
}