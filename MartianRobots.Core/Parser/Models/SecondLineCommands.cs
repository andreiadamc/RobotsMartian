using MartianRobots.Core.Helpers;
using MartianRobots.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MartianRobots.Core.Parser.Models
{
    /// <summary>
    /// The second line commands class
    /// </summary>
    public class SecondLineCommands : BaseCommand
    {
        /// <summary>
        /// Gets or sets the command queue.
        /// </summary>
        [Required]
        [MaxLength(Constants.MaxLineSize)]
        public List<char> CommandQueue { get; set; }

        /// <summary>
        /// The deserialize.
        /// </summary>
        /// <param name="line">
        /// The line.
        /// </param>
        /// <param name="plugins">
        /// The plugins.
        /// </param>
        /// <exception cref="ValidationRobotCommandException">Error here
        /// </exception>
        public void Deserialize(string line, CommandPlugins plugins)
        {
            this.ValidateInputText(line);
            this.ValidateCommands(line, plugins);
            try
            {                
                this.CommandQueue = new List<char>(line);
                this.Validate();
            }
            catch (Exception e)
            {
                throw new ValidationRobotCommandException("second line", e);
            }
        }

        /// <summary>
        /// Validates input string against list of available instructions
        /// </summary>
        /// <param name="line">line with commands</param>
        /// <param name="plugins">Available plugins list</param>
        private void ValidateCommands(string line, CommandPlugins plugins)
        {
            foreach (var itemChar in line)
            {
                if (plugins.GetValueOrDefault(itemChar) == null)
                {
                    throw new ValidationRobotCommandException($"Unsupported command: '{itemChar}'");
                }
            }

        }
    }
}
