namespace MarsRoverKata.Domain
{
    public class LeftCommand : ICommand
    {
        private readonly Navigator _navigator;

        public LeftCommand(Navigator navigator)
        {
            _navigator = navigator;
        }

        public Bearing Execute(Bearing bearing)
        {
            return new Bearing(bearing.Coordinate, _navigator.Left(bearing.Direction));
        }
    }
}