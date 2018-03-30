using System.Collections.Generic;

namespace MarsRoverKata.Domain
{
    public class CommandsMapper
    {
        private readonly Dictionary<char, ICommand> _map = new Dictionary<char, ICommand>();

        public CommandsMapper(List<Coordinate> obstacles = null)
        {
            var moveReceiver = new Grid(obstacles);
            var leftAndRightReceiver = new Navigator();
            
            var moveCommand = new MoveCommand(moveReceiver);
            var leftCommand = new LeftCommand(leftAndRightReceiver);
            var rightCommand = new RightCommand(leftAndRightReceiver);
            
            _map.Add('M', moveCommand);
            _map.Add('L', leftCommand);
            _map.Add('R', rightCommand);
        }

        public ICommand this[char character] => _map[character];
    }
}