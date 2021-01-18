using System;
using System.Collections.Generic;

namespace MashenkaPaint.Domain
{
    public class Triangle : Shape
    {
        public int Height { get; }
        public TriangleType Type { get; }

        public Triangle(TriangleType type, int height, int layer)
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
            SetShapeAppearance();
        }        

        protected override List<List<bool>> GetShape()
        {
            return Type switch
            {
                TriangleType.Type1 => GetType1Shape(),
                TriangleType.Type2 => GetType2Shape(),
                TriangleType.Type3 => GetType3Shape(),
                TriangleType.Type4 => GetType4Shape(),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        private List<List<bool>> GetType1Shape()
        {
            var shape = new List<List<bool>>();

            for (int i = 0; i < Height; i++)
            {
                shape.Add(new List<bool>());
                for (int j = 0; j <= i; j++)
                {
                    shape[i].Add(true);
                }
            }

            return shape;
        }

        private List<List<bool>> GetType2Shape()
        {
            var shape = new List<List<bool>>();

            for (int i = 0; i < Height; i++)
            {
                shape.Add(new List<bool>());
                for (int j = Height - i - 1; j > 0; j--)
                {
                    shape[i].Add(false);
                }

                for (int j = i+1;  j > 0; j--)
                {
                    shape[i].Add(true);
                }
            }

            return shape;
        }

        private List<List<bool>> GetType3Shape()
        {
            var shape = new List<List<bool>>();

            for (int i = 0; i < Height; i++)
            {
                shape.Add(new List<bool>());
                for (int j = Height - i; j > 0; j--)
                {
                    shape[i].Add(true);
                }
            }

            return shape;
        }

        private List<List<bool>> GetType4Shape()
        {
            var shape = new List<List<bool>>();

            for (int i = 0; i < Height; i++)
            {
                shape.Add(new List<bool>());
                for (int j = 0; j < i; j++)
                {
                    shape[i].Add(false);
                }

                for (int j = Height - i; j > 0; j--)
                {
                    shape[i].Add(true);
                }
            }

            return shape;
        }
    }
}
