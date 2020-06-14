using System;
using System.Collections.Generic;
using System.Text;

namespace XCode
{
    public class CodeHandler
    {

        public static void exec(string code)
        {

            if(code.StartsWith("print "))
            {

                string toBeSearched = "print ";
                int ix = code.IndexOf(toBeSearched);

                if (ix != -1)
                {
                    string str = code.Substring(ix + toBeSearched.Length);
                    Console.Write(str);
                }

            }
            else if (code.StartsWith("printline "))
            {

                string toBeSearched = "printline ";
                int ix = code.IndexOf(toBeSearched);

                if (ix != -1)
                {
                    string str = code.Substring(ix + toBeSearched.Length);
                    Console.WriteLine(str);
                }

            }

        }

    }
}
