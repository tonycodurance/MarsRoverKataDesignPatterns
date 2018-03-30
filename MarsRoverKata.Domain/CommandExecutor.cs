namespace MarsRoverKata.Domain
{
    public class CommandExecutor
    {
        public string Execute(string command)
        {
            var rover = new Rover();
            
            foreach (var character in command)
            {
                if (character == 'L')
                {
                    rover.OrientationStateHandler = new LeftOrientationStateHandler();
                    rover.Rotate();
                }

                if (character == 'R')
                {
                    rover.Rotate();
                }
                
                if (character == 'M')
                {
                    rover.Move();
                }
            }
            
            return rover.Coordinate.X + ":" + rover.Coordinate.Y + ":" + (char)rover.Direction;
        }
    }
}