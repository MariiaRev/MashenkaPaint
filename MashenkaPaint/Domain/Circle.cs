using System;
using System.Collections.Generic;

namespace MashenkaPaint.Domain
{
    public class Circle : Shape
    {
        public int Radius { get; }

        public Circle(int radius, int layer, bool contourOnly = false)
        {
            if (radius > MinParameterValue && radius < MaxParameterValue)
                Radius = radius;
            else
                throw new ArgumentOutOfRangeException(nameof(radius));

            SetLayer(layer);
            SetPosition(0, 0);
            SetShapeAppearance(contourOnly);
        }

        protected override List<List<bool>> GetShape()
        {
            List<List<bool>> shape;

            //append the first half
            if (Radius % 2 == 0)
                shape = GetEvenHalf();
            else
                shape = GetOddHalf();

            //copy the first half
            var halfShape = new List<List<bool>>();
            shape.ForEach(x => halfShape.Add(new List<bool>(x)));

            //if radius is odd number add one more line
            if (Radius % 2 == 1)
            {
                var index = shape.Count;
                shape.Add(new List<bool>());

                for (int i = 0; i <= Radius * 2; i++)
                {
                    shape[index].Add(true);
                }
            }

            //append the second half using the first one
            for (int i = Radius - 1; i >= 0; i--)
            {
                shape.Add(halfShape[i]);
            }

            return shape;
        }

        private List<List<bool>> GetOddHalf()
        {
            var shape = new List<List<bool>>();
            var maxSpaces = Radius / 2;

            for (int i = 0; i < Radius; i++)
            {
                shape.Add(new List<bool>());
                for (int j = 0; j < maxSpaces - i; j++)
                {
                    shape[i].Add(false);
                }

                if (i <= maxSpaces)
                    shape[i].Add(false);

                for (int j = 0; j < Radius + 2 * i && j <= 2 * Radius; j++)
                {
                    shape[i].Add(true);
                }
            }

            return shape;
        }

        private List<List<bool>> GetEvenHalf()
        {
            var shape = new List<List<bool>>();
            var maxSpaces = Radius / 2;

            for (int i = 0; i < Radius; i++)
            {
                shape.Add(new List<bool>());

                for (int j = 0; j < maxSpaces - i; j++)
                {
                    shape[i].Add(false);
                }

                for (int j = 0; j < Radius + 2 * i && j < 2 * Radius; j++)
                {
                    shape[i].Add(true);
                }
            }

            return shape;
        }

        protected override List<List<bool>> GetShapeContour()
        {
            List<List<bool>> shape;

            //append the first half
            if (Radius % 2 == 0)
                shape = GetEvenHalfContour();
            else
                shape = GetOddHalfContour();

            //copy the first half
            var halfShape = new List<List<bool>>();
            shape.ForEach(x => halfShape.Add(new List<bool>(x)));

            //if radius is odd number add one more line
            if (Radius % 2 == 1)
            {
                var index = shape.Count;
                shape.Add(new List<bool>());

                for (int i = 0; i <= Radius * 2; i++)
                {
                    if (i == 0 || i == Radius * 2)
                        shape[index].Add(true);
                    else
                        shape[index].Add(false);
                }
            }

            //append the second half using the first one
            for (int i = Radius - 1; i >= 0; i--)
            {
                shape.Add(halfShape[i]);
            }

            return shape;
        }

        private List<List<bool>> GetOddHalfContour()
        {
            var shape = new List<List<bool>>();
            var maxSpaces = Radius / 2;

            for (int i = 0; i < Radius; i++)
            {
                shape.Add(new List<bool>());
                for (int j = 0; j < maxSpaces - i; j++)
                {
                    shape[i].Add(false);
                }

                if (i <= maxSpaces)
                    shape[i].Add(false);

                for (int j = 0; j < Radius + 2 * i && j <= 2 * Radius; j++)
                {
                    if (i == 0 || j == 0 || j == 2 * Radius || j == Radius + 2 * i - 1)
                        shape[i].Add(true);
                    else
                        shape[i].Add(false);
                }
            }

            return shape;
        }

        private List<List<bool>> GetEvenHalfContour()
        {
            var shape = new List<List<bool>>();
            var maxSpaces = Radius / 2;

            for (int i = 0; i < Radius; i++)
            {
                shape.Add(new List<bool>());

                for (int j = 0; j < maxSpaces - i; j++)
                {
                    shape[i].Add(false);
                }

                for (int j = 0; j < Radius + 2 * i && j < 2 * Radius; j++)
                {
                    if (i == 0 || j == 0 || j == 2 * Radius - 1 || j == Radius + 2 * i - 1)
                        shape[i].Add(true);
                    else
                        shape[i].Add(false);
                }
            }

            return shape;
        }

        public override double GetPerimeter()
        {
            return Math.Round((2 * Math.PI * Radius), 2);
        }

        public override double GetArea()
        {
            return Math.Round((Math.PI * Radius * Radius), 2);
        }
    }
}