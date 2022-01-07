using MartianRobots.Core.Interfaces;
using System;

namespace MartianRobots.Core.CommandPlugin
{
    /// <summary>
    /// The base instruction class
    /// </summary>
    public class BaseInstruction
    {
        /// <summary>
        /// Validate robot argument
        /// </summary>
        /// <param name="robot">The robot</param>
        /// <exception cref="ArgumentNullException">Robot is null</exception>
        protected void CheckRobotArg(IRobot robot)
        {
            if (robot == null)
            {
                throw new ArgumentNullException();
            }
        }
    }        
}
