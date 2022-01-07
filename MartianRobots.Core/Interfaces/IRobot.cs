using MartianRobots.Core.Helpers;
using MartianRobots.Core.Models;

namespace MartianRobots.Core.Interfaces
{
    /// <summary>
    /// The Robot interface.
    /// </summary>
    public interface IRobot
    {
        /// <summary>
        /// Sets the initial location.
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="location">The location</param>
        public void SetInitialLocation(ISurface surface, LocationRobot location);

        /// <summary>
        /// Get current orientation.
        /// </summary>
        /// <returns>
        /// The <see cref="OrientationRobot"/>.
        /// </returns>
        public OrientationRobot GetOrientation();

        /// <summary>
        /// Set orientation.
        /// </summary>
        /// <param name="orientation">
        /// The orientation.
        /// </param>
        public void SetOrientation(OrientationRobot orientation);

        /// <summary>
        /// Get current position.
        /// </summary>
        /// <returns>
        /// The <see cref="Position"/>.
        /// </returns>
        public Position GetPosition();

        /// <summary>
        /// Set position.
        /// </summary>
        /// <param name="position">
        /// The position.
        /// </param>
        public void SetPosition(Position position);

        /// <summary>
        /// Moves the robot by offset.
        /// </summary>
        /// <param name="offset">
        /// The offset.
        /// </param>
        public void MoveByOffset(Position offset);

        /// <summary>
        /// Set robot "is lost" state.
        /// </summary>
        public void SetIsLost();
    }
}
