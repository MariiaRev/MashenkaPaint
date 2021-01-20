using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using MashenkaPaint.Domain;

namespace MashenkaPaint
{
    public class Shapes
    {
        private readonly Shape[] _shapes;
        public const int MaxShapesNumber = 10;             //0, 1, ... 9
        public static int CurrentShapesNumber { get; private set; }
        private readonly int _fieldSizeX = 50;
        private readonly int _fieldSizeY = 30;

        public Shapes()
        {
            _shapes = new Shape[MaxShapesNumber];
            CurrentShapesNumber = 0;
        }


        //indexator
        public Shape this[int index]
        {
            get
            {
                return _shapes[index];
            }
            set
            {
                _shapes[index] = value;
            }
        }


        public bool Add(ShapeType shapeType, int height, int type = 0, int width = 0, bool contourOnly = false)
        {
            try
            {
                if (CurrentShapesNumber < MaxShapesNumber)
                {
                    var newShapeIndex = CurrentShapesNumber++;

                    _shapes[newShapeIndex] = shapeType switch
                    {
                        ShapeType.Line => new Line((LineType)type, height, newShapeIndex),
                        ShapeType.Circle => new Circle(height, newShapeIndex, contourOnly),
                        ShapeType.Rectangle => new Rectangle(height, width, newShapeIndex, contourOnly),
                        ShapeType.Triangle => new Triangle((TriangleType)type, height, newShapeIndex, contourOnly),
                        _ => throw new ArgumentOutOfRangeException(nameof(shapeType)),
                    };
                    return true;
                }
                else
                    return false;
            }
            catch { return false; }
        }

        //delete shape from specified layer
        public void Delete(int layer)
        {
            if (layer < MaxShapesNumber && layer >= 0 && _shapes[layer] != null)
            {
                _shapes[layer] = null;
                CurrentShapesNumber--;
            }
        }

        //move shape from the specified layer to the specified position
        public void Move(int bottom, int right, int layer)
        {
            var position = new Point(right, bottom);

            if (layer < MaxShapesNumber && layer >= 0 && _shapes[layer] != null &&
                position.X >= 0 && position.Y >= 0 && 
                position.X + _shapes[layer].OccupiedWidth < _fieldSizeX &&
                position.Y + _shapes[layer].OccupiedHeight < _fieldSizeY)
            {
                _shapes[layer].SetPosition(position.X, position.Y);
            }
        }

        public void ShowShapes(Order order = Order.AscendingLayer)
        {
            var shapes = ShapesOrderedBy(order);

            if (!shapes.Any())
                Console.WriteLine("No shapes to show.");
            else
            {
                var overlappingShapes = OverlapShapes(shapes);
                var fieldRaws = overlappingShapes.GetLength(0);
                var fieldColumns = overlappingShapes.GetLength(1);
                
                Console.WriteLine($"There is the scene ({fieldRaws}x{fieldColumns})");

                for (int i = 0; i < fieldRaws; i++)
                {
                    for (int j = 0; j < fieldColumns; j++)
                    {
                        if (overlappingShapes[i, j] == null)
                        {
                            Console.Write("  ");
                        }
                        else
                        {
                            Console.Write(overlappingShapes[i, j] + " ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }


        public bool ChangeLayer(int layer, bool upward)
        {
            if (upward && layer < MaxShapesNumber - 1)
            {
                var temp = _shapes[layer];
                _shapes[layer] = _shapes[layer + 1];
                _shapes[layer + 1] = temp;
                _shapes[layer + 1].SetLayer(layer + 1);
                return true;
            }
            else if (!upward && layer > 0)
            {
                var temp = _shapes[layer];
                _shapes[layer] = _shapes[layer - 1];
                _shapes[layer - 1] = temp;
                _shapes[layer - 1].SetLayer(layer - 1);
                return true;
            }
            else
                return false;
        }

        private List<Shape> ShapesOrderedBy(Order order)
        {
            var shapes = ShapesToList();

            return order switch
            {
                Order.AscendingLayer => shapes.OrderBy(sh => sh.Layer).ToList(),
                Order.DescendingLayer => shapes.OrderByDescending(sh => sh.Layer).ToList(),
                Order.AscendingArea => shapes.OrderBy(sh => sh.GetArea()).ToList(),
                Order.DescendingArea => shapes.OrderByDescending(sh => sh.GetArea()).ToList(),
                Order.AscendingPerimeter => shapes.OrderBy(sh => sh.GetPerimeter()).ToList(),
                Order.DescendingPerimeter => shapes.OrderByDescending(sh => sh.GetPerimeter()).ToList(),
                _ => throw new ArgumentOutOfRangeException(nameof(order)),
            };
            
        }

        private List<Shape> ShapesToList()
        {
            var list = new List<Shape>(MaxShapesNumber);

            foreach (var shape in _shapes)
            {
                if (shape != null)
                    list.Add(shape);
            }

            return list;
        }

        private int?[,] OverlapShapes(List<Shape> shapes)
        {
            var field = new int?[_fieldSizeY, _fieldSizeX];

            for (int k = 0; k < shapes.Count; k++)
            {
                var x = shapes[k].Position.X;
                var y = shapes[k].Position.Y;

                for (int i = 0; i < shapes[k].ShapeAppearance.Count; i++)
                {
                    for (int j = 0; j < shapes[k].ShapeAppearance[i].Count; j++)
                    {
                        if (shapes[k].ShapeAppearance[i][j])
                        {
                            try
                            {
                                field[i + x, j + y] = shapes[k].Layer;
                            }
                            catch { }
                        }
                    }
                }
            }

            return field;
        }
    }
}
