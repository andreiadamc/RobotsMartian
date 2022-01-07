using MartianRobots.Core.Helpers;
using MartianRobots.Core.Interfaces;
using MartianRobots.Core.Models;

namespace MartianRobots.Core.CommandPlugin
{
    /// <summary>
    /// Class implements "move forward" command
    /// </summary>
    public class RobotForwardInstruction : BaseInstruction, IRobotInstruction
    {
        /// <summary>
        /// Returns corresponding command char
        /// </summary>
        /// <returns>The <see cref="char"/></returns>
        public char GetInstructionChar()
        {
            return 'F';
        }

        /// <summary>
        /// Processes the instruction.
        /// </summary>
        /// <param name="robot">The robot</param>
        public void ProcessInstruction(IRobot robot)
        {
            this.CheckRobotArg(robot);
            var orientation = robot.GetOrientation();
            var offset = new Position();
            switch (orientation)
            {
                case OrientationRobot.North:
                    offset.Y = 1;
                    break;
                case OrientationRobot.East:
                    offset.X = 1;
                    break;
                case OrientationRobot.South:
                    offset.Y = -1;
                    break;
                case OrientationRobot.West:
                    offset.X = -1;
                    break;
                default:
                    break;
            }
            robot.MoveByOffset(offset);
        }
    }
}
