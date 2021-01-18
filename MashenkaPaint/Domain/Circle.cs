using System;
using System.Collections.Generic;

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
            SetShapeAppearance();
        }

        protected override List<List<bool>> GetShape()
        {
            List<List<bool>> shape;

            //append the first half
            if (Radius % 2 == 0)
                shape = GetEvenHalf();
            else
                shape = GetOddHalf();

            //append the second half using the first one

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
    }
}