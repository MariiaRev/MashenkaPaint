﻿using System;
using System.Collections.Generic;

namespace MashenkaPaint.Domain
{
    public abstract class Shape
    {
        public Point Position { get; private set; }
        public int Layer { get; private set; }
        public int OccupiedWidth { get; protected set; }
        public int OccupiedHeight { get; protected set; }
        public List<List<bool>> ShapeAppearance { get; private set; }
        public const int MinParameterValue = 0;
        public const int MaxParameterValue = 11;

        public void SetPosition(int x, int y)
        {
            if (x >= 0 && y >= 0)
                Position = new Point(x, y);
        }
        public void SetLayer(int layer)
        {
            if (layer >= 0 && layer <= 9)
            {
                Layer = layer;
            }
            else
                throw new ArgumentOutOfRangeException(nameof(layer));
        }

        protected abstract void SetOccupiedSize();
        protected void SetShapeAppearance(bool contourOnly)
        {
            if (contourOnly)
                ShapeAppearance = GetShapeContour();
            else
                ShapeAppearance = GetShape();
        }
        protected abstract List<List<bool>> GetShape();
        protected abstract List<List<bool>> GetShapeContour();

        public abstract double GetPerimeter();
        public abstract double GetArea();
    }
}
