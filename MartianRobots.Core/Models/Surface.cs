using MartianRobots.Core.Helpers;
using MartianRobots.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace MartianRobots.Core.Models
{
    /// <summary>
    /// Mars surface model as a singleton
    /// </summary>
    public class Surface : ISurface
    {
        /// <summary>
        /// The singleton instance of the surface
        /// </summary>
        private static readonly Lazy<Surface> Instance = new Lazy<Surface>(() => new Surface());

        /// <summary>
        /// List of the scents on the surface 
        /// </summary>
        private static readonly HashSet<int> RobotScents = new HashSet<int>();

        /// <summary>
        /// Minimum coordinates of the surface grid 
        /// </summary>
        private static readonly Position MinBound = new Position(Constants.MinX, Constants.MinY);

        /// <summary>
        /// Maximum coordinates of the surface grid 
        /// </summary>
        private static Position maxBound = new Position(Constants.MaxX, Constants.MaxY);

        /// <summary>
        /// Prevents a default instance of the <see cref="Surface"/> class from being created.
        /// </summary>
        private Surface()
        {
        }

        /// <summary>
        /// Public property for the surface instance
        /// </summary>
        public static Surface SurfaceInstance => Instance.Value;


        /// <summary>
        /// Initialization of the surface bounds
        /// </summary>        
        /// <param name="maxBounds">The upper-right coordinates</param>
        public void InitSurface(Position maxBounds)
        {
            if (maxBounds.X < MinBound.X || maxBounds.Y < MinBound.Y)
            {    
                throw new ArgumentOutOfRangeException(
                    nameof(maxBounds),
                    "Maximum bounds should be greater than minimum bounds");
            }

            if (maxBounds.X > Constants.MaxX || maxBounds.Y > Constants.MaxY)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(maxBounds),
                    $"Maximum bounds should be equal or less than ({Constants.MaxX}, {Constants.MaxY})");
            }

            maxBound = maxBounds;
        }
        
        /// <summary>
        /// Checks if a position is within the bounds of the surface
        /// </summary>
        /// <param name="position">Position to check</param>
        /// <returns>True if the position is valid</returns>
        public bool IsValidPosition(Position position)
        {
            return (position.X <= maxBound.X) && (position.X >= MinBound.X) && (position.Y <= maxBound.Y) && (position.Y >= MinBound.Y);
        }

        /// <summary>
        /// Adds new scent position to the surface
        /// </summary>
        /// <param name="position">Position with a scent</param>
        public void AddScentPosition(Position position)
        {
            RobotScents.Add(HashCode.Combine(position.X, position.Y));
        }

        /// <summary>
        /// Checks if a position has a scent
        /// </summary>
        /// <param name="position">Position to check</param>
        /// <returns>True if it's a scent otherwise - false</returns>
        public bool IsScentPosition(Position position)
        {            
            return RobotScents.Contains(HashCode.Combine(position.X, position.Y));
        }

        /// <summary>
        /// Checks if a position is within the surface bounds
        ///     if not  - set robot's IsLost flag
        ///     if yes  - move the robot to the new position
        /// </summary>
        /// <param name="robot">Object on the surface</param>
        /// <param name="newPosition">New coordinates</param>
        public void MoveObjectOnSurface(IRobot robot, Position newPosition)
        {
            if (!this.IsValidPosition(newPosition))
            {                   
                var robotPosition = robot.GetPosition();
                robot.SetIsLost();
                // Save last object position in the scent list
                this.AddScentPosition(robotPosition);

                // Make the robot lost                
                throw new RobotIsLostException();
            }
            else
            {                
                robot.SetPosition(newPosition);
            }
        }        
    }
}
