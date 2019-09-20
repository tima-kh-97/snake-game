using PixelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Snack
{
    public class ExampleSnake : ISnake
    {
        private const int _width = 50;
        private const int _wallDistanceThreshold = 2;
        private Point _myHeadPosition;
        private Point _myFoodPosition;
        private Point _myBodyPosition;

        public string Name => "Example Snake";

        public SnakeDirection GetNextDirection(SnakeDirection currentDirection)
        {

            if (currentDirection == SnakeDirection.Up 
                && _myHeadPosition.Y < _wallDistanceThreshold)
            {
                return SnakeDirection.Left;
            }

            if(currentDirection == SnakeDirection.Right
                && _myHeadPosition.X > _width - _wallDistanceThreshold)
            {
                return SnakeDirection.Up;
            }

            if(currentDirection == SnakeDirection.Down
                && _myHeadPosition.Y > _width - _wallDistanceThreshold)
            {
                return SnakeDirection.Right;
            }

            if (currentDirection == SnakeDirection.Left
                && _myHeadPosition.X <  _wallDistanceThreshold)
            {
                return SnakeDirection.Down;
            }

            if (_myHeadPosition.X == _myBodyPosition.X - 3
                && _myHeadPosition.Y > _myBodyPosition.Y)
            {
                return SnakeDirection.Up;
            }

            if (_myHeadPosition.X == _myBodyPosition.X - 3
                && _myHeadPosition.Y < _myBodyPosition.Y)
            {
                return SnakeDirection.Down;
            }

            if (_myHeadPosition.Y == _myBodyPosition.Y - 3
                && _myHeadPosition.X < _myBodyPosition.X)
            {
                return SnakeDirection.Left;
            }

            if (_myHeadPosition.Y == _myBodyPosition.Y - 3
                && _myHeadPosition.X > _myBodyPosition.X)
            {
                return SnakeDirection.Right;
            }

            if (_myHeadPosition.X  < _myFoodPosition.X)
            {
                return SnakeDirection.Right;
            }

            if (_myHeadPosition.Y < _myFoodPosition.Y)
            {
                return SnakeDirection.Down;
            }

            if (_myHeadPosition.X > _myFoodPosition.X)
            {
                return SnakeDirection.Left;
            }

            if (_myHeadPosition.Y > _myFoodPosition.Y)
            {
                return SnakeDirection.Up;
            }


            return currentDirection;
        }

        public void UpdateMap(string map)
        {
            _myHeadPosition = getMyHeadPosition(map);
        }

        private Point getMyHeadPosition(string map)
        {
            var headIndex = map.IndexOf('*');
            var foodIndex = map.IndexOf('7');
            var bodyIndex = map.IndexOf('1');

            _myFoodPosition = new Point(foodIndex % _width, foodIndex / _width);
            _myBodyPosition = new Point(bodyIndex % _width, bodyIndex / _width);

            return new Point(headIndex % _width, headIndex / _width);
        }
    }
}
