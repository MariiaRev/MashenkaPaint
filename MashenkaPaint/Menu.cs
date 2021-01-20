using System;
using System.IO;

namespace MashenkaPaint
{
    public static class Menu
    {
        public static void Start()
        {
            Console.WriteLine($"\n{"",30}MAIN MENU");

            while (true)
            {
                Console.WriteLine();
                var userChoice = ValidateUserData.AcceptIntDataInRange("\n\nAvailable commands:\n0 - exit the program\n1 - switch to drawing mode\n" +
                                                                       "2 - view rules\n\nPlease, choose menu item:", 0, 2);

                switch (userChoice)
                {
                    case 0:
                        {
                            Console.WriteLine("\n\nGoodbye!\n\n\n");
                            return;
                        }
                    case 1:
                        {
                            DrawingMode.Draw();
                            Console.WriteLine($"\n{"",30}MAIN MENU");
                        }; break;
                    case 2:
                        {
                            InfoMode();
                        }; break;
                }
            }
        }

        private static void InfoMode()
        {
            Console.WriteLine($"\n\n{"",32}RULES");

            var rulesPath = "rules.txt";
            var rules = ReadTxtFile(rulesPath);

            if (rules == null)
                Console.WriteLine($"\n\nFile {rulesPath} was not found.");
            else if (rules.Trim() == "")
                Console.WriteLine($"\n\nFile {rulesPath} is empty.");
            else
                Console.WriteLine(rules);
        }

        private static string ReadTxtFile(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }
    }
}
