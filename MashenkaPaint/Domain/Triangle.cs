using System;
using System.Text;

namespace MashenkaPaint.Domain
{
    public class Triangle : Shape
    {
        public int Height { get; }
        public ShapeType Type { get; }

        public Triangle(ShapeType type, int height, int layer)
        {
            Type = type;

            if (height > 0)
            {
                Height = height;
            }
            else
                throw new ArgumentOutOfRangeException(nameof(height));

            SetLayer(layer);
            SetPosition(0, 0);
        }        


        public override string GetShape()
        {
            return Type switch
            {
                ShapeType.Type1 => GetType1Shape().ToString(),
                ShapeType.Type2 => GetType2Shape().ToString(),
                ShapeType.Type3 => GetType3Shape().ToString(),
                ShapeType.Type4 => GetType4Shape().ToString(),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        StringBuilder GetType1Shape()
        {
            StringBuilder shape = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    shape.Append(Layer.ToString() + " ");
                }

                if (i != Height - 1)
                    shape.Append("\n");
            }

            return shape;
        }

        StringBuilder GetType2Shape()
        {
            StringBuilder shape = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                for (int j = Height - i - 1; j > 0; j--)
                {
                    shape.Append("  ");
                }

                for (int j = i+1;  j > 0; j--)
                {
                    shape.Append(Layer.ToString() + " ");
                }

                if (i != Height - 1)
                    shape.Append("\n");
            }

            return shape;
        }

        StringBuilder GetType3Shape()
        {
            StringBuilder shape = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                for (int j = Height - i; j > 0; j--)
                {
                    shape.Append(Layer.ToString() + " ");
                }

                if (i != Height - 1)
                    shape.Append("\n");
            }

            return shape;
        }

        StringBuilder GetType4Shape()
        {
            StringBuilder shape = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    shape.Append("  ");
                }

                for (int j = Height - i; j > 0; j--)
                {
                    shape.Append(Layer.ToString() + " ");
                }

                if (i != Height - 1)
                    shape.Append("\n");
            }

            return shape;
        }
    }
}
