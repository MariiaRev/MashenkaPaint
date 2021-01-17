using System;
using System.Text;

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
        }
        
        
        public override string GetShape()
        {
            var shape = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    shape.Append(Layer.ToString() + " ");
                }

                if (i != Height - 1)
                    shape.Append("\n");
            }

            return shape.ToString();
        }
    }
}
