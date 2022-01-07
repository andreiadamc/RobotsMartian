using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using MartianRobots.Core.Helpers;
using System.IO;
using System.Linq;
using MartianRobots.Core.Models;

namespace MartianRobots.Core.Parser.Models
{
    /// <summary>
    /// Incoming command script model
    /// </summary>
    public class CommandBunch
    {
        public TopLineCommand TopLineCommand = new TopLineCommand();
        public List<RobotCommandPackage> RobotCommandPackages = new List<RobotCommandPackage>();

        /// <summary>
        /// Parses the RobotCommandPackages from the input script
        /// </summary>
        /// <param name="reader">reader</param>
        /// <param name="plugins">List of available command plugins</param>
        private void DeserializeRestOfScript(StringReader reader, CommandPlugins plugins)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line != string.Empty)
                {
                    var nextLine = reader.ReadLine();
                    var robotCommandPackage = new RobotCommandPackage();
                    robotCommandPackage.Deserialize(line, nextLine, plugins);
                    this.RobotCommandPackages.Add(robotCommandPackage);
                }
            }
        }

        /// <summary>
        /// Parses a full command script
        /// </summary>
        /// <param name="inputScript">script text</param>
        /// <param name="plugins">List of available command plugins</param>
        /// <returns></returns>
        public CommandBunch(string inputScript, CommandPlugins plugins)
        {            
            using var reader = new StringReader(inputScript);            
            this.TopLineCommand.Deserialize(reader);
            this.DeserializeRestOfScript(reader, plugins);
        }
    }    
}
