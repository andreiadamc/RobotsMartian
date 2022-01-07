using MartianRobots.Core.Models;

namespace MartianRobots.Core.Parser.Models
{
    /// <summary>
    /// The robot command package class
    /// </summary>
    public class RobotCommandPackage
    {
        /// <summary>
        /// Initial robot position and orientation
        /// </summary>
        public FirstLineCommand FirstLineCommand = new FirstLineCommand();

        /// <summary>
        /// Set of moving commands
        /// </summary>
        public SecondLineCommands SecondLineCommands = new SecondLineCommands();

        /// <summary>
        /// The deserialize.
        /// </summary>
        /// <param name="firstLine">
        /// The first line.
        /// </param>
        /// <param name="secondLine">
        /// The second line.
        /// </param>
        /// <param name="plugins">
        /// The plugins.
        /// </param>
        public void Deserialize(string firstLine, string secondLine, CommandPlugins plugins)
        {
            this.FirstLineCommand.Deserialize(firstLine);
            this.SecondLineCommands.Deserialize(secondLine, plugins);
        }
    }
}
