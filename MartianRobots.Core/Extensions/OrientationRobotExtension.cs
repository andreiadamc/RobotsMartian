using MartianRobots.Core.Helpers;
using System;

namespace MartianRobots.Core.Extensions
{
    /// <summary>
    /// The OrientationRobot extensions.
    /// </summary>
    public static class OrientationRobotExtension
    {
        /// <summary>
        /// Returns a char corresponding to OrientationRobot item
        /// </summary>
        /// <param name="orientation">OrientationRobot item</param>
        /// <returns>A char corresponding to OrientationRobot item</returns>
        public static char GetChar(this OrientationRobot orientation)
        {
            return (char)orientation;
        }
        
        /// <summary>
        /// Returns OrientationRobot item next to the current one
        /// </summary>
        /// <param name="orientation">Current OrientationRobot item</param>
        /// <returns>OrientationRobot item</returns>
        public static OrientationRobot GetNextValue(this OrientationRobot orientation)
        {
            OrientationRobot[] enumItems = GetAllValues();
            int idx = enumItems.GetIndexOfValue(orientation);
            if (idx == enumItems.Length - 1)
            {
                idx = -1;
            }

            return (OrientationRobot)enumItems.GetValue(idx + 1);
        }

        /// <summary>
        /// Returns previous OrientationRobot item
        /// </summary>
        /// <param name="orientation">Current OrientationRobot item</param>
        /// <returns>OrientationRobot item</returns>
        public static OrientationRobot GetPrevValue(this OrientationRobot orientation)
        {
            OrientationRobot[] enumItems = GetAllValues();
            int idx = enumItems.GetIndexOfValue(orientation);
            if (idx == 0)
            {
                idx = enumItems.Length;
            }

            return (OrientationRobot) enumItems.GetValue(idx - 1);
        }

        /// <summary>
        /// Returns all OrientationRobot items as an array
        /// </summary>
        /// <returns>Array of OrientationRobot items</returns>
        private static OrientationRobot[] GetAllValues()
        {
            OrientationRobot[] enumItems = { OrientationRobot.North, OrientationRobot.East, OrientationRobot.South, OrientationRobot.West };
            return enumItems;
        }

        /// <summary>
        /// Returns an index of OrientationRobot item in OrientationRobot's array
        /// </summary>
        /// <param name="orientations">Array of OrientationRobot items</param>
        /// <param name="orientation">OrientationRobot item</param>
        /// <returns>Index of OrientationRobot item</returns>
        private static int GetIndexOfValue(this OrientationRobot[] orientations, OrientationRobot orientation)
        {
            int idx = Array.IndexOf(orientations, orientation);
            if (idx < 0)
            {
                throw new ArgumentException("Invalid OrientationRobot value", nameof(orientation));
            }

            return idx;
        }
    }
}
