using System;
using System.Collections.Generic;

namespace MashenkaPaint.Domain
{
    public class Line : Shape
    {
        public int Height { get; }
        public LineType Type { get; }

        public Line(LineType type, int height, int layer)
        {
            if (height > MinParameterValue && height < MaxParameterValue)
                Height = height;
            else
                throw new ArgumentOutOfRangeException(nameof(height));
            
            Type = type;
            SetLayer(layer);
            SetPosition(0, 0);
            SetShapeAppearance(false);
        }

        protected override List<List<bool>> GetShape()
        {
            return Type switch
            {
                LineType.Type1 => GetType1Shape(),
                LineType.Type2 => GetType2Shape(),
                LineType.Type3 => GetType3Shape(),
                LineType.Type4 => GetType4Shape(),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        private List<List<bool>> GetType1Shape()
        {
            var shape = new List<List<bool>>();

            for (int i = 0; i < Height; i++)
            {
                shape.Add(new List<bool>());

                for (int j = 0; j < i; j++)
                {
                    shape[i].Add(false);
                }

                shape[i].Add(true);
            }

            return shape;
        }

        private List<List<bool>> GetType2Shape()
        {
            var shape = new List<List<bool>>();

            for (int i = 0; i < Height; i++)
            {
                shape.Add(new List<bool>());

                for (int j = Height; j > i + 1; j--)
                {
                    shape[i].Add(false);
                }

                shape[i].Add(true);
            }

            return shape;
        }

        //horizontal line
        private List<List<bool>> GetType3Shape()
        {
            var shape = new List<List<bool>>() { new List<bool>()};

            for (int i = 0; i < Height; i++)
            {
                shape[0].Add(true);
            }

            return shape;
        }

        //vertical line
        private List<List<bool>> GetType4Shape()
        {
            var shape = new List<List<bool>>();

            for (int i = 0; i < Height; i++)
            {
                shape.Add(new List<bool>() { true });
            }

            return shape;
        }

        protected override List<List<bool>> GetShapeContour()
        {
            return GetShape();
        }

        public override double GetPerimeter()
        {
            return 0;
        }

        public override double GetArea()
        {
            return 0;
        }
    }
}
