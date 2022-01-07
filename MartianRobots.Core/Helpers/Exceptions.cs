using System;

namespace MartianRobots.Core.Helpers
{

    /// <summary>
    /// Represents errors that occurs during an input script validation
    /// </summary>
    public class ValidationRobotCommandException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationRobotCommandException"/> class.
        /// </summary>
        /// <param name="message">The error message</param>
        public ValidationRobotCommandException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationRobotCommandException"/> class.
        /// </summary>
        /// <param name="message">The error message</param>
        /// <param name="innerException">The inner exception</param>
        public ValidationRobotCommandException(string message, Exception innerException)
            : base(string.Format("Invalid {0} syntax" + Environment.NewLine + innerException.Message, message))
        {
        }
    }

    /// <summary>
    /// Robot is lost exception - is a way to implement connection lost signal 
    /// </summary>
    public class RobotIsLostException : Exception
    {

    }

    /// <summary>
    /// Represents error that occurs if the surface object not set in the robot instance
    /// </summary>
    public class RobotNeedsSurfaceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RobotNeedsSurfaceException"/> class.
        /// </summary>
        public RobotNeedsSurfaceException(): base("The surface is not defined for the robot")
        {             
        }        
    }
}
