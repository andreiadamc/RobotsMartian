using MartianRobots.Core.Interfaces;

namespace MartianRobots.Core.CommandPlugin
{
    using MartianRobots.Core.Extensions;

    /// <summary>
    /// Class implements "turn to the right" command
    /// </summary>
    public class RobotRightInstruction : BaseInstruction, IRobotInstruction
    {
        /// <summary>
        /// The get instruction char.
        /// </summary>
        /// <returns>The <see cref="char"/></returns>
        public char GetInstructionChar()
        {
            return 'R';
        }

        /// <summary>
        /// Processes the instruction.
        /// </summary>
        /// <param name="robot">The robot</param>
        public void ProcessInstruction(IRobot robot)
        {
            this.CheckRobotArg(robot);
            var orientation = robot.GetOrientation();            
            robot.SetOrientation(orientation.GetNextValue());
        }
    }
}
