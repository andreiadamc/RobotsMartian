using MartianRobots.Core.CommandPlugin;
using MartianRobots.Core.Extensions;
using MartianRobots.Core.Helpers;
using MartianRobots.Core.Interfaces;
using MartianRobots.Core.Models;
using MartianRobots.Core.Parser.Models;
using System.Collections.Generic;

namespace MartianRobots.Core
{
    /// <summary>
    /// The send message to HQ function.
    /// </summary>
    /// <param name="line">Message for HQ</param>
    public delegate void SendMessage2HQFunction(string line);

    /// <summary>
    /// Model of the robot controller
    /// </summary>
    public class RobotsController
    {
        /// <summary>
        /// The list of command plugins
        /// </summary>
        private readonly CommandPlugins plugins = new CommandPlugins();

        /// <summary>
        /// Output interface
        /// </summary>
        private readonly SendMessage2HQFunction sendMessage2Hq;

        /// <summary>
        /// Last known robot location 
        /// </summary>
        private LocationRobot lastRobotLocation;

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotsController"/> class. 
        /// </summary>
        /// <param name="writeLine">
        /// Function to write a message 
        /// </param>
        public RobotsController(SendMessage2HQFunction writeLine)
        {            
            this.sendMessage2Hq = writeLine;

            // Registers build-in robot's instructions
            this.AddSupportedInstruction<RobotLeftInstruction>();
            this.AddSupportedInstruction<RobotRightInstruction>();
            this.AddSupportedInstruction<RobotForwardInstruction>();
        }

        /// <summary>
        /// Registers a command plugin in a list of plugins
        /// </summary>
        /// <typeparam name="T">Type of plugin</typeparam>
        public void AddSupportedInstruction<T>()
        {
            this.plugins.AddPlugin<T>();
        }

        /// <summary>
        /// Parses incoming script and runs it
        /// </summary>
        /// <param name="inputScript">Incoming script</param>
        public void ProcessIncomingScript(string inputScript)
        {
            var commandBunch = new CommandBunch(inputScript, this.plugins);
            Surface.SurfaceInstance.InitSurface(new Position(commandBunch.TopLineCommand.LimitX, commandBunch.TopLineCommand.LimitY));            
            this.ProcessCommandPackages(commandBunch.RobotCommandPackages);
        }

        /// <summary>
        /// Sends moving commands to robots 
        /// </summary>
        /// <param name="robotCommandPackages">List of command bunches</param>
        private void ProcessCommandPackages(List<RobotCommandPackage> robotCommandPackages)
        {            
            // Process robot commands
            foreach (var item in robotCommandPackages)
            {
                var robot = this.GetRobot();                
                try
                {                    
                    robot.SetInitialLocation(Surface.SurfaceInstance, item.FirstLineCommand.GetLocation());
                    foreach (var command in item.SecondLineCommands.CommandQueue)
                    {
                        var commandHandler = this.plugins.GetValueOrDefault(command);
                        commandHandler?.ProcessInstruction(robot);                        
                    }

                    this.SendMessage2HQ(robotIsLost: false);
                }
                catch (RobotIsLostException)
                {
                    this.SendMessage2HQ(robotIsLost: true);
                }
            } 
        }

        /// <summary>
        /// Sends output message to Earth HQ
        /// </summary>
        /// <param name="robotIsLost">True if the robot is lost</param>
        private void SendMessage2HQ(bool robotIsLost)
        {
            string lostMessage = robotIsLost ? " LOST" : string.Empty;
            this.sendMessage2Hq?.Invoke($"{this.lastRobotLocation.Position.X} {this.lastRobotLocation.Position.Y} {this.lastRobotLocation.Orientation.GetChar()}" + lostMessage);
        }

        /// <summary>
        /// Creates if needed and returns a robot instance 
        /// </summary>        
        /// <returns>New robot</returns>
        private IRobot GetRobot()
        {
            // As we do not need to store previous robots instances - just create a new one
            var robot = new Robot();

            // Set up a callback to get feedback from the robot 
            robot.LocationChanged += (IRobot sender, LocationRobot lastLocation) =>
                {
                    this.lastRobotLocation = lastLocation;
                };
            return robot;
        }
    }
}
