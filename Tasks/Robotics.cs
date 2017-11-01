using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    internal class Robotics
    {
        public static void Check(string[] args)
        {
            var results = DoesCircleExist(new[] { "GRGL", "G", "L" });
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        private static IEnumerable<string> DoesCircleExist(IEnumerable<string> commands)
        {
            return commands
                .Select(cs => new Robot(cs))
                .Select(robot => robot.IsMovesInCircles ? "YES" : "NO")
                .ToArray();
        }

        private class Robot
        {
            private RobotPosition _position;

            public Robot(string commands)
            {
                if (string.IsNullOrWhiteSpace(commands))
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(commands), commands, "Null or empty command list");
                }

                _position = new RobotPosition();

                // Four times is enough
                ApplyCommands(commands);
                ApplyCommands(commands);
                ApplyCommands(commands);
                ApplyCommands(commands);
            }

            public bool IsMovesInCircles => _position.IsInitial;

            private void ApplyCommands(string commands)
            {
                foreach (var command in commands)
                {
                    ApplyCommand(command);
                }
            }

            private void ApplyCommand(char command)
            {
                switch (command)
                {
                    case 'G':
                        _position.MoveForward();
                        break;
                    case 'L':
                        _position.TurnLeft();
                        break;
                    case 'R':
                        _position.TurnRight();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(command), command, "Invalid commnad");
                }
            }

            private struct RobotPosition
            {
                public int X { get; private set; }

                public int Y { get; private set; }

                public Direction Direction { get; private set; }

                public bool IsInitial => X == 0 && Y == 0;

                public void MoveForward()
                {
                    switch (Direction)
                    {
                        case Direction.North:
                            Y++;
                            break;
                        case Direction.East:
                            X++;
                            break;
                        case Direction.South:
                            Y--;
                            break;
                        case Direction.West:
                            X--;
                            break;
                    }
                }

                public void TurnLeft()
                {
                    Direction = (Direction)(((int)Direction + 4 - 1) % 4);
                }

                public void TurnRight()
                {
                    Direction = (Direction)(((int)Direction + 1) % 4);
                }
            }

            private enum Direction
            {
                North = 0,
                East = 1,
                South = 2,
                West = 3
            }
        }
    }
}
