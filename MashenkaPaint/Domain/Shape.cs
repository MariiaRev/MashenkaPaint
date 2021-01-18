using System;
using System.Collections.Generic;

namespace MashenkaPaint.Domain
{
    public abstract class Shape
    {
        public Point Position { get; private set; }
        public int Layer { get; private set;}

        public List<List<bool>> ShapeAppearance { get; private set; }

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

        public void SetShapeAppearance(bool contourOnly)
        {
            if (contourOnly)
                ShapeAppearance = GetShapeContour();
            else
                ShapeAppearance = GetShape();
        }
        protected abstract List<List<bool>> GetShape();
        protected abstract List<List<bool>> GetShapeContour();

        public abstract double GetPerimeter();
        public abstract double GetArea();
    }
}
