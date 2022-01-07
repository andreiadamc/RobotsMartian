namespace MartianRobots.Core.Helpers
{
    /// <summary>
    /// Possible robot orientations
    /// </summary>
    public enum OrientationRobot
    {
        /// <summary>
        /// The north orientation
        /// </summary>
        North = 'N',

        /// <summary>
        /// The east orientation
        /// </summary>
        East = 'E',

        /// <summary>
        /// The south orientation
        /// </summary>
        South = 'S',

        /// <summary>
        /// The west orientation
        /// </summary>
        West = 'W'        
    }

    /// <summary>
    /// The constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The min x coordinate
        /// </summary>
        public const int MinX = 0;

        /// <summary>
        /// The min y coordinate
        /// </summary>
        public const int MinY = 0;

        /// <summary>
        /// The max x coordinate
        /// </summary>
        public const int MaxX = 50;

        /// <summary>
        /// The max y coordinate
        /// </summary>
        public const int MaxY = 50;

        /// <summary>
        /// The max size for the command line.
        /// </summary>
        public const int MaxLineSize = 99;

        /// <summary>
        /// The command items splitter.
        /// </summary>
        public const char CommandItemsSplitter = ' ';
    }
}
