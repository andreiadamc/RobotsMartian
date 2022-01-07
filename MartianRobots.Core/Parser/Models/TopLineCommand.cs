using MartianRobots.Core.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace MartianRobots.Core.Parser.Models
{
    /// <summary>
    /// The top line command.
    /// </summary>
    public class TopLineCommand : BaseCommand
    {
        /// <summary>
        /// Gets or sets the limit x.
        /// </summary>
        [Required]
        [Range(Constants.MinX, Constants.MaxX)]
        public int LimitX { get; set; }

        /// <summary>
        /// Gets or sets the limit y.
        /// </summary>
        [Required]
        [Range(Constants.MinY, Constants.MaxY)]
        public int LimitY { get; set; }

        /// <summary>Deserialize top line from string</summary>
        /// <param name="line">Input line</param>
        /// <exception cref="ValidationRobotCommandException">Error here</exception>
        public virtual void Deserialize(string line)
        {
            this.ValidateInputText(line);
            try
            {                
                var values = line.Split(Constants.CommandItemsSplitter);
                this.LimitX = int.Parse(values[0]);
                this.LimitY = int.Parse(values[1]);
                this.Validate();
            }
            catch (Exception e)
            {
                throw new ValidationRobotCommandException("top line", e);
            }
        }

        /// <summary>
        /// Deserialize top line from StringReader
        /// </summary>
        /// <param name="reader">The reader</param>
        public virtual void Deserialize(StringReader reader)
        {
            var line = reader.ReadLine();
            this.Deserialize(line);
        }
    }
}
