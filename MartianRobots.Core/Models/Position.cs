namespace MartianRobots.Core.Models
{
    /// <summary>
    /// Position Model
    /// </summary>
    public struct Position 
    {
        /// <summary>
        /// X coordinate
        /// </summary>
        public int X;

        /// <summary>
        /// Y coordinate
        /// </summary>
        public int Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> struct.
        /// </summary>
        /// <param name="x">
        /// The x coordinate
        /// </param>
        /// <param name="y">
        /// The y coordinate
        /// </param>
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// + operator overriding
        /// </summary>
        /// <param name="left">First position</param>
        /// <param name="right">Second position</param>
        /// <returns>Summary of two positions</returns>
        public static Position operator +(Position left, Position right)
        {
            return new Position(left.X + right.X, left.Y + right.Y);
        }        
    }
}
