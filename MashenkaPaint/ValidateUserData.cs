using System;
using MashenkaPaint.Domain;

namespace MashenkaPaint
{
    public static class ValidateUserData
    {
        public static int AcceptIntDataInRange(string message, int start, int end)
        {
            int number;

            Console.WriteLine(message);
            var data = Console.ReadLine().Trim();

            while (string.IsNullOrEmpty(data) || !int.TryParse(data, out number) || number < start || number > end)
            {
                Console.WriteLine($"\nYou need to enter an integer number between {start} and {end} (including). Try again:");
                data = Console.ReadLine().Trim();
            }

            return number;
        }
        public static ShapeType? AcceptShapeType()
        {
            var userChoice = AcceptIntDataInRange("\n\nChoose the shape:\n1 - line\n2 - circle\n3 - rectangle\n4 - triangle\n" +
                                                  "0 - exit\n\nSelect command:", 0,  4);
            return userChoice switch
            {
                1 => ShapeType.Line,
                2 => ShapeType.Circle,
                3 => ShapeType.Rectangle,
                4 => ShapeType.Triangle,
                _ => null,
            };
        }

        public static int? AcceptLineType()
        {
            var userChoice = AcceptIntDataInRange("\n\nChoose the line type:\n1 - 135-degree line\n2 - 45-degree line\n" +
                                                  "3 - vertical  line\n4 - horizontal line\n0 - exit\n\n" +
                                                  "Select command:", 0, Enum.GetNames(typeof(LineType)).Length);

            if (userChoice == 0)
                return null;

            return userChoice;
        }

        public static int? AcceptTriangleType()
        {
            var userChoice = AcceptIntDataInRange("\n\nChoose the triangle type:\n1 - with 135-degree hypotenuse above cathetus\n2 - with 45-degree line hypotenuse above cathetus\n" +
                                                  "3 - with 45-degree hypotenuse under cathetus\n4 - with 135-degree hypotenuse under cathetus\n0 - exit\n\n" +
                                                  "Select command:", 0, Enum.GetNames(typeof(TriangleType)).Length);

            if (userChoice == 0)
                return null;

            return userChoice;
        }


    }
}
