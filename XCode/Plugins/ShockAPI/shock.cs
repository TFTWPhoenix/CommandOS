using OS1;
using System;
using System.Collections.Generic;
using System.Text;
using XCode.Plugins.Shock.Exceptions;

namespace XCode.Plugins
{
    public class ShockAPI
    {

        public static void exec(string code)
        {

            if(code.StartsWith("draw "))
            {

                string toBeSearched = "draw ";
                int ix = code.IndexOf(toBeSearched);

                if (ix != -1)
                {
                    string color = code.Substring(ix + toBeSearched.Length);
                    if(color == "white")
                    {

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;

                    } else if (color == "red")
                    {

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    else if (color == "green")
                    {

                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    else if (color == "blue")
                    {

                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    else if (color == "yellow")
                    {

                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    else if (color == "purple")
                    {

                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    else if (color == "magenta")
                    {

                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    else if (color == "cyan")
                    {

                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    else if (color == "darkgreen")
                    {

                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;

                    } else
                    {

                        errorHandler.handle(unknowncolor.throwErr(), false);

                    }
                    
                }
            } else if (code == "newln")
            {

                Console.WriteLine("");

            }

        }

    }

}

