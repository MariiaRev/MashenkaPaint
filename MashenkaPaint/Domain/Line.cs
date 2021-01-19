using System;
using System.Collections.Generic;

namespace MashenkaPaint.Domain
{
    public class Line : Shape
    {
        public int Length { get; }
        public LineType Type { get; }

        public Line(LineType type, int length, int layer)
        {
            if (length > MinParameterValue && length < MaxParameterValue)
                Length = length;
            else
                throw new ArgumentOutOfRangeException(nameof(length));
            
            Type = type;
            SetLayer(layer);
            SetPosition(0, 0);
            SetShapeAppearance(false);
            SetOccupiedSize();
        }

        protected override void SetOccupiedSize()
        {
            switch(Type)
            {
                case LineType.Type1:
                case LineType.Type2:
                    {
                        OccupiedWidth = OccupiedHeight = (int)Math.Round(Length / Math.Sqrt(2));
                    }; break;
                case LineType.Type3:
                    {
                        OccupiedWidth = Length;
                        OccupiedHeight = 1;
                    }; break;
                case LineType.Type4:
                    {
                        OccupiedWidth = 1;
                        OccupiedHeight = Length;
                    }; break;
                default: throw new ArgumentOutOfRangeException(nameof(Type));
            }
        }
        protected override List<List<bool>> GetShape()
        {
            return Type switch
            {
                LineType.Type1 => GetType1Shape(),
                LineType.Type2 => GetType2Shape(),
                LineType.Type3 => GetType3Shape(),
                LineType.Type4 => GetType4Shape(),
                _ => throw new ArgumentOutOfRangeException(nameof(Type)),
            };
        }

        private List<List<bool>> GetType1Shape()
        {
            var shape = new List<List<bool>>();

            for (int i = 0; i < Length; i++)
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

            for (int i = 0; i < Length; i++)
            {
                shape.Add(new List<bool>());

                for (int j = Length; j > i + 1; j--)
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

            for (int i = 0; i < Length; i++)
            {
                shape[0].Add(true);
            }

            return shape;
        }

        //vertical line
        private List<List<bool>> GetType4Shape()
        {
            var shape = new List<List<bool>>();

            for (int i = 0; i < Length; i++)
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
