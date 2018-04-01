namespace MarsRoverKata.Domain
{
    public class Bearing
    {   
        public Direction Direction { get; set; }

        public Coordinate Coordinate { get; set; }

        public Bearing(Direction direction, Coordinate coordinate)
        {
            Direction = direction;
            Coordinate = coordinate;
        }
    }
}