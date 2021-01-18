using System;
using System.Collections.Generic;

namespace MashenkaPaint.Domain
{
    public class Rectangle : Shape
    {
        public int Height { get; }
        public int Width { get; }

        public Rectangle(int height, int width, int layer)
        {
            //set height
            if (height > 0)
                Height = height;
            else
                throw new ArgumentOutOfRangeException(nameof(height));

            //set widtht
            if (width > 0)
                Width = width;
            else
                throw new ArgumentOutOfRangeException(nameof(width));

            SetLayer(layer);
            SetPosition(0, 0);
            SetShapeAppearance();
        }

        protected override List<List<bool>> GetShape()
        {
            var shape = new List<List<bool>>();

            for (int i = 0; i < Height; i++)
            {
                shape.Add(new List<bool>());

                for (int j = 0; j < Width; j++)
                {
                    shape[i].Add(true);
                }
            }

            return shape;
        }
    }
}
