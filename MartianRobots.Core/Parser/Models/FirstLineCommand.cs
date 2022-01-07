using MartianRobots.Core.Helpers;
using MartianRobots.Core.Models;
using MartianRobots.Core.Parser.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace MartianRobots.Core.Parser.Models
{
    /// <summary>
    /// The first line command class
    /// </summary>
    public class FirstLineCommand : BaseCommand
    {
        /// <summary>
        /// Gets or sets the origin x.
        /// </summary>
        [Required]
        [Range(Constants.MinX, Constants.MaxX)]
        public int OriginX { get; set; }

        /// <summary>
        /// Gets or sets the origin y.
        /// </summary>
        [Required]
        [Range(Constants.MinY, Constants.MaxY)]
        public int OriginY { get; set; }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        [Required]
        [Orientation]
        public char Orientation { get; set; }

        /// <summary>
        /// Returns the current location.
        /// </summary>
        /// <returns>
        /// The <see cref="LocationRobot"/>.
        /// </returns>
        public LocationRobot GetLocation()
        {
            return new LocationRobot(new Position(this.OriginX, this.OriginY), (OrientationRobot)this.Orientation);
        }

        /// <summary>
        /// Deserialize string
        /// </summary>
        /// <param name="line">Input line</param>
        /// <exception cref="ValidationRobotCommandException">Error here</exception>
        public virtual void Deserialize(string line)
        {
            this.ValidateInputText(line);
            try
            {                
                var values = line.Split(Constants.CommandItemsSplitter);
                this.OriginX = int.Parse(values[0]);
                this.OriginY = int.Parse(values[1]);
                this.Orientation = values[2][0];
                this.Validate();
            }
            catch (Exception e)
            {
                throw new ValidationRobotCommandException("first line", e);
            }
        }
    }
}
