using System;

namespace Locations.Data
{
    [Serializable]
    public class LocationBounds
    {
        /// <summary>
        /// width in rectangles
        /// </summary>
        public int width;

        /// <summary>
        /// height in rectangles
        /// </summary>
        public int height;

        /// <summary>
        ///  offset in rhombus
        /// </summary>
        public int offset;

        public LocationBounds()
        {

        }
        public LocationBounds(int width, int height, int offset)
        {
            this.width = width;
            this.height = height;
            this.offset = offset;
        }

        public override string ToString()
        {
            return string.Format("Width: {0}, Height: {1}, Offset: {2}", width, height, offset);
        }
    }
}
