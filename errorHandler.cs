using Cosmos.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection.Metadata;
using System.Text;

namespace OS1
{
    public class errorHandler
    {
        public static void stoperr(string crashreport) { 
        
            if(!System.IO.Directory.Exists(@"0:\logs"))
            {

                System.IO.Directory.CreateDirectory(@"0:\logs");

            }
            File.WriteAllText(@"0:\logs\crashreport-latest.txt", crashreport);
        
        }
        
        public static void handle(string error, bool fatal)
        {
            if(fatal)
            {

                stoperr(error);

            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[Error Handler Output] " + error);
                Console.ResetColor();

            }
        }

    }
}
