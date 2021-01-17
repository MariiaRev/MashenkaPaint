using System;
using System.Text;

namespace MashenkaPaint.Domain
{
    public class Circle : Shape
    {
        public int Radius { get; }

        public Circle(int radius, int layer)
        {
            if (radius > 0)
                Radius = radius;
            else
                throw new ArgumentOutOfRangeException(nameof(radius));

            SetLayer(layer);
            SetPosition(0, 0);
        }

        public override string GetShape()
        {
            StringBuilder shape;

            if (Radius % 2 == 0)
                shape = GetEvenHalf();
            else
                shape = GetOddHalf();
            
            //append second half
            var halfShape = shape.ToString().Split("\n");

            //if radius is odd number add one more line
            if (Radius % 2 == 1)
            {
                for (int i = 0; i <= Radius * 2; i++)
                {
                    shape.Append(Layer.ToString() + " ");
                }
                shape.Append("\n");
            }

            for (int i = Radius-1; i >= 0; i--)
            {
                if (i == 0)
                    shape.Append(halfShape[i]);
                else
                    shape.Append(halfShape[i] + "\n");
            }

            return shape.ToString();
        }

        private StringBuilder GetOddHalf()
        {
            var shape = new StringBuilder();
            var maxSpaces = Radius / 2;

            for (int i = 0; i < Radius; i++)
            {
                //add spaces
                for (int j = 0; j < maxSpaces - i; j++)
                {
                    shape.Append("  ");
                }

                //add content
                if (i <= maxSpaces)
                    shape.Append("  ");
                for (int j = 0; j < Radius + 2 * i; j++)
                {
                    if (j <= 2 * Radius)
                    {
                        shape.Append(Layer.ToString() + " ");
                    }
                }

                if (i != Radius - 1)
                    shape.Append("\n");
            }

            shape.Append("\n");
            return shape;
        }

        private StringBuilder GetEvenHalf()
        {
            var shape = new StringBuilder();
            var maxSpaces = Radius / 2;

            for (int i = 0; i < Radius; i++)
            {
                //add spaces
                for (int j = 0; j < maxSpaces - i; j++)
                {
                    shape.Append("  ");
                }

                for (int j = 0; j < Radius + 2 * i; j++)
                {
                    if (j < 2 * Radius)
                    {
                        shape.Append(Layer.ToString() + " ");
                    }
                }
                 

                if (i != Radius - 1)
                    shape.Append("\n");
            }

            shape.Append("\n");

            return shape;
        }
    }
}