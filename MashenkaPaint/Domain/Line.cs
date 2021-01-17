using System;
using System.Text;

namespace MashenkaPaint.Domain
{
    public class Line : Shape
    {
        public int Height { get; }
        public ShapeType Type { get; }

        public Line(ShapeType type, int height, int layer)
        {
            if (height > 0)
                Height = height;
            else
                throw new ArgumentOutOfRangeException(nameof(height));
            
            Type = type;
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

        private StringBuilder GetType1Shape()
        {
            var shape = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    shape.Append("  ");
                }

                if (i == Height - 1)
                    shape.Append(Layer.ToString() + " ");
                else
                    shape.Append(Layer.ToString() + "\n");
            }

            return shape;
        }

        private StringBuilder GetType2Shape()
        {
            var shape = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                for (int j = Height; j > i + 1 ; j--)
                {
                    shape.Append("  ");
                }

                if (i == Height - 1)
                    shape.Append(Layer.ToString() + " ");
                else
                    shape.Append(Layer.ToString() + "\n");
            }

            return shape;
        }

        //horizontal line
        private StringBuilder GetType3Shape()
        {
            var shape = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                shape.Append(Layer.ToString() + " ");
            }

            return shape;
        }

        //vertical line
        private StringBuilder GetType4Shape()
        {
            var shape = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                if (i == Height - 1)
                    shape.Append(Layer.ToString());
                else
                    shape.Append(Layer.ToString() + "\n");
            }

            return shape;
        }
    }
}
