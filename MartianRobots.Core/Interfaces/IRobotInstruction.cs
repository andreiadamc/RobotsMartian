namespace MartianRobots.Core.Interfaces
{
    /// <summary>
    /// The RobotInstruction interface.
    /// </summary>
    public interface IRobotInstruction
    {
        /// <summary>
        /// The get instruction char.
        /// </summary>
        /// <returns>The <see cref="char"/></returns>
        public char GetInstructionChar();

        /// <summary>
        /// The process instruction.
        /// </summary>
        /// <param name="robot">The robot</param>
        public void ProcessInstruction(IRobot robot);
    }
}
