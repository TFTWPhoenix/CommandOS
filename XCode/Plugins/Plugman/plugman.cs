using System;
using System.Collections.Generic;
using System.Text;

namespace XCode.Plugins
{
    public class PlugMan
    {

        public static void exec(string code)
        {

            // Run the code using the Shock API.
            ShockAPI.exec(code);

            // Add other plugin exec() methods here.

        }

    }
}
