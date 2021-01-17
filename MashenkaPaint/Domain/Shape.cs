using System;

namespace MashenkaPaint.Domain
{
    public abstract class Shape
    {
        public Point Position { get; private set; }
        public int Layer { get; private set;}

        public void SetPosition(int x, int y)
        {
            if (x >= 0 && y >= 0)
                Position = new Point(x, y);
        }
        public void SetLayer(int layer)
        {
            if (layer >= 0 && layer <= 9)
            {
                Layer = layer;
            }
            else
                throw new ArgumentOutOfRangeException(nameof(layer));
        }
        public abstract string GetShape();
    }
}
