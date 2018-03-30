namespace MarsRoverKata.Domain
{
    public class Invoker
    {
        private ICommand _command;
        
        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public Bearing ExecuteCommand(Bearing startingBearing)
        {
            return _command.Execute(startingBearing);
        }
    }
}