using System;
using MashenkaPaint.Domain;

namespace MashenkaPaint
{
    public static class DrawingMode
    {
        private static readonly Shapes shapes = new Shapes();
        public static void Draw()
        {
            Console.Clear();
            Console.WriteLine($"{"",26}DRAWING MODE");

            ConsoleKeyInfo key;         //the key entered by user
            var layer = -1;
            char? changeOrderTo = null;
            var setOrder = Order.AscendingLayer;

            shapes.ShowShapes(setOrder);

            while (true)
            {
                Console.Write("\n\n\nHotkey: ");

                if ((key = Console.ReadKey(true)).Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return;
                }

                if (key.Modifiers == ConsoleModifiers.Control)
                {
                    switch(key.Key)
                    {
                        case ConsoleKey.N:
                            { 
                                //add a new shapes
                                AddShape();
                                Console.Clear();
                                Console.WriteLine($"{"",26}DRAWING MODE\n\n");
                                shapes.ShowShapes(setOrder);
                            }; break;
                        case ConsoleKey.S:
                            {
                                Console.WriteLine("\n\nThe 'saving scene to the file' feature is still under development and will be added very soon.");
                                //save scene to the file
                            }; break;
                        case ConsoleKey.O:
                            {
                                Console.WriteLine("\n\nThe 'loading scene from the file' feature is still under development and will be added very soon.");
                                //load scene from the file
                            }; break;

                        case ConsoleKey.LeftArrow:
                            {
                                //if layer is set, change layer to the lower one
                                if (layer != -1)
                                {
                                    if (shapes[layer] == null)
                                    {
                                        Console.WriteLine($"\n\nThere is no shape on the layer {layer}.");
                                        layer = -1;                             //unset
                                        continue;
                                    }

                                    if (shapes.ChangeLayer(layer, false))
                                    {
                                        Console.WriteLine("\n\nThe layer has been changed.\n\n");
                                        shapes.ShowShapes(setOrder);
                                    }
                                    else
                                        Console.WriteLine("\n\nCannot change the layer (layer is minimum/maximum already).");

                                    layer = -1;                                 //unset
                                }
                                else
                                    Console.WriteLine("\n\nFirst, set the layer!");

                            }; break;
                        case ConsoleKey.RightArrow:
                            {
                                //if layer is set, change layer to the upper one
                                if (layer != -1)
                                {                                   
                                    if (shapes[layer] == null)
                                    {
                                        Console.WriteLine($"\n\nThere is no shape on the layer {layer}.");
                                        layer = -1;                             //unset
                                        continue;
                                    }

                                    if (shapes.ChangeLayer(layer, true))
                                    {
                                        Console.WriteLine("\n\nThe layer has been changed.\n\n");
                                        shapes.ShowShapes(setOrder);                                        
                                    }
                                    else
                                        Console.WriteLine("\n\nCannot change the layer (layer is minimum/maximum already).");

                                    layer = -1;                                 //unset
                                }
                                else
                                    Console.WriteLine("\n\nFirst, set the layer!");

                            }; break;

                        case ConsoleKey.D0: { layer = 0; Console.WriteLine("You've chosen layer 0"); } break;
                        case ConsoleKey.D1: { layer = 1; Console.WriteLine("You've chosen layer 1"); } break;
                        case ConsoleKey.D2: { layer = 2; Console.WriteLine("You've chosen layer 2"); } break;
                        case ConsoleKey.D3: { layer = 3; Console.WriteLine("You've chosen layer 3"); } break;
                        case ConsoleKey.D4: { layer = 4; Console.WriteLine("You've chosen layer 4"); } break;
                        case ConsoleKey.D5: { layer = 5; Console.WriteLine("You've chosen layer 5"); } break;
                        case ConsoleKey.D6: { layer = 6; Console.WriteLine("You've chosen layer 6"); } break;
                        case ConsoleKey.D7: { layer = 7; Console.WriteLine("You've chosen layer 7"); } break;
                        case ConsoleKey.D8: { layer = 8; Console.WriteLine("You've chosen layer 8"); } break;
                        case ConsoleKey.D9: { layer = 9; Console.WriteLine("You've chosen layer 9"); } break;
                    }

                    continue;
                }

                if (key.Modifiers == ConsoleModifiers.Alt)
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.A:
                            {
                                Console.WriteLine("\n\nYou've chosen order by area parameter.");
                                changeOrderTo = 'a';
                            }; break;
                        case ConsoleKey.P:
                            {
                                Console.WriteLine("\n\nYou've chosen order by perimeter parameter.");
                                changeOrderTo = 'p';
                            }; break;
                        case ConsoleKey.L:
                            {
                                Console.WriteLine("\n\nYou've chosen order by layer parameter.");
                                changeOrderTo = 'l';
                            }; break;
                        case ConsoleKey.D:
                            {                                
                                changeOrderTo = null;                   //unset
                                setOrder = Order.AscendingLayer;
                                Console.WriteLine("\n\nOrder is set as default (ascending by layer).\n\n");
                                shapes.ShowShapes(setOrder);
                            }; break;
                        case ConsoleKey.W:
                            {
                                //if order is set, order by ascending
                                if (changeOrderTo != null)
                                {
                                    switch (changeOrderTo)
                                    {
                                        case 'a':
                                            {
                                                setOrder = Order.AscendingArea;
                                                Console.WriteLine("\n\nOrder is set as ascending by area.\n\n");
                                                shapes.ShowShapes(setOrder);
                                            }; break;
                                        case 'p':
                                            {
                                                setOrder = Order.AscendingPerimeter;
                                                Console.WriteLine("\n\nOrder is set as ascending by perimeter.\n\n");
                                                shapes.ShowShapes(setOrder);
                                            }; break;
                                        case 'l':
                                            {
                                                setOrder = Order.AscendingLayer;
                                                Console.WriteLine("\n\nOrder is set as ascending by layer.\n\n");
                                                shapes.ShowShapes(setOrder);
                                            }; break;
                                    }

                                    //changeOrderTo = null;
                                }
                                else
                                    Console.WriteLine("\n\nFirst, set the parameter by which to order!");

                            };  break;
                        case ConsoleKey.S:
                            {
                                //if order is set, order by descending
                                if (changeOrderTo != null)
                                {
                                    switch (changeOrderTo)
                                    {
                                        case 'a':
                                            {
                                                setOrder = Order.DescendingArea;
                                                Console.WriteLine("\n\nOrder is set as descending by area.\n\n");
                                                shapes.ShowShapes(setOrder);
                                            }; break;
                                        case 'p':
                                            {
                                                setOrder = Order.DescendingPerimeter;
                                                Console.WriteLine("\n\nOrder is set as descending by perimeter.\n\n");
                                                shapes.ShowShapes(setOrder);
                                            }; break;
                                        case 'l':
                                            {
                                                setOrder = Order.DescendingLayer;
                                                Console.WriteLine("\n\nOrder is set as descending by layer (default).\n\n");
                                                shapes.ShowShapes(setOrder);
                                            }; break;
                                    }

                                    //changeOrderTo = null;
                                }
                                else
                                    Console.WriteLine("\n\nFirst, set the parameter by which to order!");

                            }; break;
                    }

                    continue;
                }

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        {
                            //if layer is set, move the shape down
                            if (layer != -1)
                            {
                                if (shapes[layer] == null)
                                {
                                    Console.WriteLine($"\n\nThere is no shape on the layer {layer} to move.");
                                    continue;
                                }

                                shapes.Move(shapes[layer].Position.X, shapes[layer].Position.Y + 1, layer);
                                shapes.ShowShapes(setOrder);
                            }
                            else
                                Console.WriteLine("\n\nFirst, set the layer!");
                        }; break;
                    case ConsoleKey.UpArrow:
                        {
                            //if layer is set, move the shape up
                            if (layer != -1)
                            {
                                if (shapes[layer] == null)
                                {
                                    Console.WriteLine($"\n\nThere is no shape on the layer {layer} to move.");
                                    continue;
                                }

                                shapes.Move(shapes[layer].Position.X, shapes[layer].Position.Y - 1, layer);
                                shapes.ShowShapes(setOrder);
                            }
                            else
                                Console.WriteLine("\n\nFirst, set the layer!");
                        }; break;
                    case ConsoleKey.RightArrow:
                        {
                            //if layer is set, move the shape right
                            if (layer != -1)
                            {
                                if (shapes[layer] == null)
                                {
                                    Console.WriteLine($"\n\nThere is no shape on the layer {layer} to move.");
                                    continue;
                                }

                                shapes.Move(shapes[layer].Position.X + 1, shapes[layer].Position.Y, layer);
                                shapes.ShowShapes(setOrder);
                            }
                            else
                                Console.WriteLine("\n\nFirst, set the layer!");
                        }; break;
                    case ConsoleKey.LeftArrow:
                        {
                            //if layer is set, move the shape left
                            if (layer != -1)
                            {
                                if (shapes[layer] == null)
                                {
                                    Console.WriteLine($"\n\nThere is no shape on the layer {layer} to move.");
                                    continue;
                                }

                                shapes.Move(shapes[layer].Position.X - 1, shapes[layer].Position.Y, layer);
                                shapes.ShowShapes(setOrder);
                            }
                            else
                                Console.WriteLine("\n\nFirst, set the layer!");
                        }; break;
                    case ConsoleKey.Delete:
                        {
                            //if layer is set, delete the shape
                            if (layer != -1)
                            {
                                if(shapes[layer] == null)
                                {
                                    Console.WriteLine("\n\nThere is nothing to delete.");
                                    layer = -1;                             //unset
                                    continue;
                                }

                                Console.WriteLine($"\n\nAre you sure to delete the shape from layer {layer} (y/n)?");
                                var userChoice = Console.ReadKey();

                                if(userChoice.Key == ConsoleKey.Y)
                                {
                                    shapes.Delete(layer);
                                    Console.WriteLine("\n\nThe shape is deleted successfully.\n\n");
                                    shapes.ShowShapes(setOrder); 
                                }
                                else
                                    Console.WriteLine("\n\nThe shape deleting is canceled.");

                                layer = -1;                             //unset
                            }
                            else
                                Console.WriteLine("\n\nFirst, set the layer!");
                        }; break;

                    default: { }; break;
                }
            }
        }

        static void AddShape()
        {
            Console.Clear();
            Console.WriteLine($"{"", 26}ADDING A NEW SHAPE");

            if (Shapes.CurrentShapesNumber == Shapes.MaxShapesNumber)
            {
                Console.WriteLine($"\n\nYou already have created {Shapes.CurrentShapesNumber} shapes. Sorry, you can't create more.");
                Console.WriteLine("\n\n\nEnter any key to return to the drawing mode:");
                Console.ReadKey();
                return;
            }

            bool success = false;
            bool contourOnly = false;
            int contourChoice;

            var shapeType = ValidateUserData.AcceptShapeType();

            if (shapeType == null)
            {
                return;
            }

            if (!(shapeType is ShapeType.Line))
            {
                contourChoice = ValidateUserData.AcceptIntDataInRange("\n\n\nChoose a drawing shape method:\n0 - fully filled\n" +
                                                                      "1 - only contour\n\nSelected method:", 0, 1);
                contourOnly = contourChoice != 0;
            }

            switch (shapeType)
            {
                case ShapeType.Line:
                    {
                        var lineType = ValidateUserData.AcceptLineType();

                        if (lineType == null)
                            return;

                        var length = ValidateUserData.AcceptIntDataInRange("\n\nEnter the line length:", Shape.MinParameterValue + 1, Shape.MaxParameterValue - 1);
                        success = shapes.Add((ShapeType)shapeType, length, (int)lineType, 0);

                    }; break;
                case ShapeType.Circle:
                    {
                        var radius = ValidateUserData.AcceptIntDataInRange("\n\nEnter the circle radius:", Shape.MinParameterValue + 1, Shape.MaxParameterValue - 1);
                        success = shapes.Add((ShapeType)shapeType, radius, 0, 0, contourOnly);

                    }; break;
                case ShapeType.Rectangle:
                    {
                        var width = ValidateUserData.AcceptIntDataInRange("\n\nEnter the rectangle width:", Shape.MinParameterValue + 1, Shape.MaxParameterValue - 1);
                        var height = ValidateUserData.AcceptIntDataInRange("\n\nEnter the rectangle height:", Shape.MinParameterValue + 1, Shape.MaxParameterValue - 1);
                        success = shapes.Add((ShapeType)shapeType, height, 0, width, contourOnly);

                    }; break;
                case ShapeType.Triangle:
                    {
                        var triangleType = ValidateUserData.AcceptTriangleType();

                        if (triangleType == null)
                            return;

                        var height = ValidateUserData.AcceptIntDataInRange("\n\nEnter the triangle height:", Shape.MinParameterValue + 1, Shape.MaxParameterValue - 1);
                        success = shapes.Add((ShapeType)shapeType, height, (int)triangleType, 0, contourOnly);

                    }; break;
            }

            if (success)
                Console.WriteLine("\nThe shape was successfully added.");
            else
            {
                //if(Shapes.CurrentShapesNumber == Shapes.CurrentShapesNumber)
                //    Console.WriteLine($"\n\nYou already have created {Shapes.CurrentShapesNumber} shapes. Sorry, you can't create more.");
                //else
                    Console.WriteLine("\n\nSorry, there are some problems on our side. Please, contact the author of the application.");
            }

            Console.WriteLine("\n\n\nEnter any key to return to the drawing mode:");
            Console.ReadKey();
            
        }
    }
}
