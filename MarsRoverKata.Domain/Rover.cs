using static MarsRoverKata.Domain.Direction;

namespace MarsRoverKata.Domain
{
    public class Rover
    {
        private Bearing _bearing;
        private readonly CommandsMapper _mapper;

        public Rover(CommandsMapper mapper)
        {
            _mapper = mapper;
            _bearing  = new Bearing(new Coordinate(0, 0), North);
        }

        public string Execute(string command)
        {   
            foreach (var character in command)
            {
                var invoker = new Invoker();
                invoker.SetCommand(_mapper[character]);
                
                _bearing = invoker.ExecuteCommand(_bearing);
            }
            
            return _bearing.Coordinate.X + ":" + _bearing.Coordinate.Y + ":" + (char)_bearing.Direction;
        }
    }
}