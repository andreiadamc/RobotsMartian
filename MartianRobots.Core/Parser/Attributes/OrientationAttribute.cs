using MartianRobots.Core.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace MartianRobots.Core.Parser.Attributes
{
    /// <summary>
    /// The orientation attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class OrientationAttribute : ValidationAttribute
    {
        /// <summary>Checks is a orientation value valid</summary>
        /// <param name="value">The orientation value</param>
        /// <returns>The <see cref="bool"/></returns>
        public override bool IsValid(object value)
        {
            var isValid = char.IsLetter((char)value) && Enum.IsDefined(typeof(OrientationRobot), (int)(char)value);
            return isValid;
        }
    }
}
