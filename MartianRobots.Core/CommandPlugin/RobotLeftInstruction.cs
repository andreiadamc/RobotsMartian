using MartianRobots.Core.Extensions;
using MartianRobots.Core.Interfaces;

namespace MartianRobots.Core.CommandPlugin
{
    /// <summary>
    /// Class implements "turn to the left" command
    /// </summary>
    public class RobotLeftInstruction : BaseInstruction, IRobotInstruction
    {
        /// <summary>
        /// Returns corresponding command char
        /// </summary>
        /// <returns>The <see cref="char"/></returns>
        public char GetInstructionChar()
        {
            return 'L';
        }

        /// <summary>
        /// Processes the instruction.
        /// </summary>
        /// <param name="robot">The robot</param>
        public void ProcessInstruction(IRobot robot)
        {
            this.CheckRobotArg(robot);
            var orientation = robot.GetOrientation();
            robot.SetOrientation(orientation.GetPrevValue());
        }
    }
}
