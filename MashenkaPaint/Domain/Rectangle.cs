﻿using System;
using System.Collections.Generic;

namespace MashenkaPaint.Domain
{
    public class Rectangle : Shape
    {
        public int Height { get; }
        public int Width { get; }

        public Rectangle(int height, int width, int layer, bool contourOnly = false)
        {
            //set height
            if (height > MinParameterValue && height < MaxParameterValue)
                Height = height;
            else
                throw new ArgumentOutOfRangeException(nameof(height));

            //set widtht
            if (width > MinParameterValue && width < MaxParameterValue)
                Width = width;
            else
                throw new ArgumentOutOfRangeException(nameof(width));

            SetLayer(layer);
            SetPosition(0, 0);
            SetShapeAppearance(contourOnly);
            SetOccupiedSize();
        }

        protected override void SetOccupiedSize()
        {
            OccupiedWidth = Width;
            OccupiedHeight = Height;
        }
        protected override List<List<bool>> GetShape()
        {
            var shape = new List<List<bool>>();

            for (int i = 0; i < Height; i++)
            {
                shape.Add(new List<bool>());

                for (int j = 0; j < Width; j++)
                {
                    shape[i].Add(true);
                }
            }

            return shape;
        }

        protected override List<List<bool>> GetShapeContour()
        {
            var shape = new List<List<bool>>();

            for (int i = 0; i < Height; i++)
            {
                shape.Add(new List<bool>());

                for (int j = 0; j < Width; j++)
                {
                    if (i == 0 || i == Height - 1 ||
                        j == 0 || j == Width - 1)
                        shape[i].Add(true);
                    else
                        shape[i].Add(false);
                }
            }

            return shape;
        }

        public override double GetPerimeter()
        {
            return 2 * (Height + Width);
        }

        public override double GetArea()
        {
            return Height * Width;
        }
    }
}
