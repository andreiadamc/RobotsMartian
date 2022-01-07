using MartianRobots.Core.Helpers;
using MartianRobots.Core.Interfaces;

namespace MartianRobots.Core.Models
{
    /// <summary>
    /// Notify RobotController of robot's position change
    /// </summary>
    /// <param name="sender">Robot object</param>
    /// <param name="location">last robot location</param>
    public delegate void LocationChangeHandler(IRobot sender, LocationRobot location);       

    /// <summary>
    /// The robot model
    /// </summary>
    public class Robot : IRobot
    {
        /// <summary>
        /// Robot is lost notification function
        /// </summary>
        public LocationChangeHandler LocationChanged;

        /// <summary>
        /// Current robot's location
        /// </summary>
        private LocationRobot locationRobot = new LocationRobot();

        /// <summary>
        /// Reference to the surface instance
        /// </summary>
        private ISurface planetSurface;

        /// <summary>
        /// "Is lost" flag
        /// </summary>
        private bool isLost = false;

        /// <summary>
        /// Sets "is lost" state.
        /// </summary>
        public void SetIsLost()
        {
            this.isLost = true;
        }

        /// <summary>
        /// Get the current robot position
        /// </summary>
        /// <returns>Robot's position</returns>
        public Position GetPosition()
        {
            this.CheckIsLostState();
            return this.locationRobot.Position;
        }

        /// <summary>
        /// Set the robot position
        /// </summary>
        /// <param name="position">New position</param>
        public void SetPosition(Position position)
        {
            this.CheckIsLostState();
            this.locationRobot.Position = position;
            this.LocationChanged?.Invoke(this, this.locationRobot);
        }

        /// <summary>
        /// Get the current robot's orientation
        /// </summary>
        /// <returns>Robot's orientation</returns>
        public OrientationRobot GetOrientation()
        {
            this.CheckIsLostState();
            return this.locationRobot.Orientation;
        }

        /// <summary>
        /// Set the robot orientation
        /// </summary>
        /// <param name="orientation">New orientation</param>
        public void SetOrientation(OrientationRobot orientation)
        {
            this.CheckIsLostState();
            this.locationRobot.Orientation = orientation;

            // Notify the controller of a new position and orientation
            this.LocationChanged?.Invoke(this, this.locationRobot);
        }

        /// <summary>
        /// Moves the robot to the new position
        /// </summary>
        /// <param name="newPosition">New robot's position</param>
        private void Move(Position newPosition)
        {
            if (this.planetSurface != null)
            {
                // Taste new position - does it smell?
                bool positionIsScent = this.planetSurface.IsScentPosition(this.locationRobot.Position);

                // the position has a scent so we can validate new position before move the robot
                if (!positionIsScent || this.planetSurface.IsValidPosition(newPosition))
                {
                    // Tell the planet that the robot is moving
                    this.planetSurface.MoveObjectOnSurface(this, newPosition);
                }

                // if new position leads the robot to outside the grid we will skip the move            
            }
            else
            {
                throw new RobotNeedsSurfaceException();
            }
        }

        /// <summary>
        /// Moves the robot to the new position by the offset
        /// </summary>
        /// <param name="offset">The offset from the current position</param>
        public void MoveByOffset(Position offset)
        {
            this.CheckIsLostState();
            var newPosition = this.locationRobot.Position + offset;
            this.Move(newPosition);
        }
        
        /// <summary>
        /// Let the robot know what the surface is and where was it landed
        /// </summary>
        /// <param name="planetSurface">Surface object</param>
        /// <param name="location">Robot's landing position and orientation</param>
        public void SetInitialLocation(ISurface planetSurface, LocationRobot location)
        {
            this.CheckIsLostState();
            this.planetSurface = planetSurface ?? throw new RobotNeedsSurfaceException();
            this.SetOrientation(location.Orientation);
            this.Move(location.Position);
        }

        /// <summary>
        /// Checks "is lost" state.
        /// </summary>
        /// <exception cref="RobotIsLostException">Error here</exception>
        private void CheckIsLostState()
        {
            if (this.isLost)
            {
                throw new RobotIsLostException();
            }
        }
    }
}
