namespace MarsRoverKata.Domain
{
    public interface IOrientationStateHandler
    {
        void Handle(Rover rover);
    }
}