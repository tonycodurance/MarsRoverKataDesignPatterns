namespace MarsRoverKata.Domain
{
    public interface ICommand
    {
        Bearing Execute(Bearing bearing);
    }
}