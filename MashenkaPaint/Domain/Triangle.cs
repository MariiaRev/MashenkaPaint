using System;
using System.Collections.Generic;

namespace MashenkaPaint.Domain
{
    public class Triangle : Shape
    {
        public int Height { get; }
        public TriangleType Type { get; }

        private readonly double _hypotenuse;

        public Triangle(TriangleType type, int height, int layer, bool contourOnly = false)
        {
            Type = type;

            if (height > MinParameterValue && height < MaxParameterValue)
            {
                Height = height;
            }
            else
                throw new ArgumentOutOfRangeException(nameof(height));

            SetLayer(layer);
            SetPosition(0, 0);
            SetShapeAppearance(contourOnly);
            SetOccupiedSize();

            _hypotenuse = GetHypotenuse();
        }

        protected override void SetOccupiedSize()
        {
            OccupiedWidth = OccupiedHeight = Height;
        }
        protected override List<List<bool>> GetShape()
        {
            return Type switch
            {
                TriangleType.Type1 => GetType1Shape(),
                TriangleType.Type2 => GetType2Shape(),
                TriangleType.Type3 => GetType3Shape(),
                TriangleType.Type4 => GetType4Shape(),
                _ => throw new ArgumentOutOfRangeException(nameof(Type)),
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

        protected override List<List<bool>> GetShapeContour()
        {
            return Type switch
            {
                TriangleType.Type1 => GetType1ShapeContour(),
                TriangleType.Type2 => GetType2ShapeContour(),
                TriangleType.Type3 => GetType3ShapeContour(),
                TriangleType.Type4 => GetType4ShapeContour(),
                _ => throw new ArgumentOutOfRangeException(nameof(Type)),
            };
        }

        private List<List<bool>> GetType1ShapeContour()
        {
            var shape = new List<List<bool>>();

            for (int i = 0; i < Height; i++)
            {
                shape.Add(new List<bool>());

                for (int j = 0; j <= i; j++)
                {
                    if (i == 0 || i == Height - 1 ||
                        j == 0 || j == i)
                        shape[i].Add(true);
                    else
                        shape[i].Add(false);
                }
            }

            return shape;
        }

        private List<List<bool>> GetType2ShapeContour()
        {
            var shape = new List<List<bool>>();

            for (int i = 0; i < Height; i++)
            {
                shape.Add(new List<bool>());

                for (int j = Height - i - 1; j > 0; j--)
                {
                    shape[i].Add(false);
                }

                for (int j = i + 1; j > 0; j--)
                {
                    if (i == 0 || i == Height - 1 || 
                        j == i + 1 || j == 1)
                        shape[i].Add(true);
                    else
                        shape[i].Add(false);
                }
            }

            return shape;
        }

        private List<List<bool>> GetType3ShapeContour()
        {
            var shape = new List<List<bool>>();

            for (int i = 0; i < Height; i++)
            {
                shape.Add(new List<bool>());

                for (int j = Height - i; j > 0; j--)
                {
                    if (i == 0 || i == Height - 1 ||
                        j == Height - i || j == 1)
                        shape[i].Add(true);
                    else
                        shape[i].Add(false);
                }
            }

            return shape;
        }

        private List<List<bool>> GetType4ShapeContour()
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
                    if (i == 0 || i == Height - 1 || 
                        j == Height - i || j == 1)
                        shape[i].Add(true);
                    else
                        shape[i].Add(false);
                }
            }

            return shape;
        }

        public override double GetPerimeter()
        {
            return Math.Round((Height + Height + _hypotenuse), 2);
        }

        public override double GetArea()
        {
            return Math.Round((Height * Height / 2.0), 2);
        }

        private double GetHypotenuse()
        {
            return Math.Sqrt(2 * Height * Height);
        }
    }
}
