using MartianRobots.Core.Helpers;

namespace MartianRobots.Core.Models
{
    /// <summary>
    /// Model of robot's position and orientation on the surface
    /// </summary>
    public struct LocationRobot
    {
        /// <summary>
        /// Robot's position 
        /// </summary>
        public Position Position;

        /// <summary>
        /// Robot's orientation 
        /// </summary>
        public OrientationRobot Orientation;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationRobot"/> struct.
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="orientation">The orientation</param>
        public LocationRobot(Position position, OrientationRobot orientation)
        {
            this.Position = position;
            this.Orientation = orientation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationRobot"/> struct.
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <param name="orientation">The orientation</param>
        public LocationRobot(int x, int y, char orientation) : this(new Position(x, y), (OrientationRobot)orientation)
        {
        }
    }
}
