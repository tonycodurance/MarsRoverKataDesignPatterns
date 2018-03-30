using System.Collections.Generic;
using static MarsRoverKata.Domain.Direction;

namespace MarsRoverKata.Domain
{
    public class Grid
    {
        private const int MaxHeight = 10;
        private const int MaxWidth = 10;
        private readonly List<Coordinate> _obstacles = new List<Coordinate>();

        public Grid(List<Coordinate> obstacles)
        {
            if (obstacles != null)
            {
                _obstacles = obstacles;    
            }
        }

        public Grid()
        {
        }

        public Coordinate NextCoordinateFor(Direction direction, Coordinate coordinate)
        {
            var y = coordinate.Y;
            var x = coordinate.X;
            
            if (direction == North)
            {
                y = (y + 1) % MaxHeight;
            }
            if (direction == East)
            {
                x = (x + 1) % MaxWidth;
            }

            if (direction == West)
            {
                x = (x > 0) ? x - 1 : MaxWidth - 1;
            }

            if (direction == South)
            {
                y = (y > 0) ? y - 1 : MaxWidth - 1;
            }

            var newCoordinate = new Coordinate(x, y);
            var obstacleIndex = _obstacles.FindIndex(obstacle => obstacle.X == x && obstacle.Y == y);

            if (obstacleIndex >= 0)
            {
                return coordinate;
            }

            return newCoordinate;
        }
    }
}