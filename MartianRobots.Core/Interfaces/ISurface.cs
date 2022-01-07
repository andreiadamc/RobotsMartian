using MartianRobots.Core.Models;

namespace MartianRobots.Core.Interfaces
{
    /// <summary>
    /// The Surface interface.
    /// </summary>
    public interface ISurface
    {
        /// <summary>
        /// The is scent position.
        /// </summary>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsScentPosition(Position position);

        /// <summary>
        /// The move object on surface.
        /// </summary>
        /// <param name="objectOnSurface">
        /// The object on surface.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        public void MoveObjectOnSurface(IRobot objectOnSurface, Position position);

        /// <summary>
        /// The is valid position.
        /// </summary>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsValidPosition(Position position);
    }
}
