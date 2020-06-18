using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;

namespace OS1
{
    public class CommandHandler
    {

        public static void exec(string cmd)
        {
            List<string> cmds = new List<string>();
            cmds.Add("about");
            cmds.Add("shutdown [-r]");
            cmds.Add("edit <file>");
            cmds.Add("dir");
            cmds.Add("rm");
            cmds.Add("rmdir");
            cmds.Add("mkdir");
            cmds.Add("clr");
            cmds.Add("invoke <program>");
            cmds.Add("?/help/cmdlist");
            string input;
            if (cmd == "about")
            {

                Console.WriteLine("CommandOS Chipmunk is an operating system developed");
                Console.WriteLine("using the Cosmos User Kit.");

            }
            else if (cmd.StartsWith("shutdown"))
            {

                if (cmd == "shutdown")
                {

                    Sys.Power.Shutdown();

                }
                else if (cmd == "shutdown -r")
                {

                    Sys.Power.Reboot();

                }

            }
            else if (cmd.StartsWith("edit"))
            {

                string toBeSearched = "edit ";
                int ix = cmd.IndexOf(toBeSearched);

                if (ix != -1)
                {
                    string inp = cmd.Substring(ix + toBeSearched.Length);
                    if (File.Exists(inp))
                    {

                        Console.WriteLine("Old Contents: ");
                        int i = 0;
                        while (i < File.ReadAllLines(inp).Length)
                        {

                            Console.WriteLine(File.ReadAllLines(inp)[i]);
                            i++;

                        }
                        Console.WriteLine("New Contents:");
                        List<string> nconts = new List<string>();
                        string ci = "";
                        while (ci != @"\%exit")
                        {

                            ci = Console.ReadLine();
                            if (ci != @"\%exit")
                            {

                                nconts.Add(ci);

                            }



                        }
                        File.WriteAllLines(inp, nconts.ToArray());

                    }
                    else
                    {

                        Console.WriteLine("Doesn't exist. Creating...");
                        Console.WriteLine("Contents: ");
                        List<string> nconts = new List<string>();
                        string ci = "";
                        while (ci != @"\%exit")
                        {

                            ci = Console.ReadLine();
                            if (ci != @"\%exit")
                            {

                                nconts.Add(ci);

                            }



                        }
                        File.WriteAllLines(inp, nconts.ToArray());

                    }
                }
                


            }
            else if (cmd == "dir")
            {

                Console.Write("Directory Of: ");
                input = Console.ReadLine();
                if (input != "")
                {

                    string[] dirdirs = Directory.GetDirectories(input);
                    int i = 0;
                    while (i < dirdirs.Length)
                    {

                        Console.WriteLine(dirdirs[i] + "    [DIR]");
                        i++;

                    }
                    i = 0;
                    string[] dirfils = Directory.GetFiles(input);
                    while (i < dirfils.Length)
                    {

                        Console.WriteLine(dirfils[i] + "    [FILE]");
                        i++;

                    }

                }
                else
                {

                    string[] dirdirs = Directory.GetDirectories(@"0:\");
                    int i = 0;
                    while (i < dirdirs.Length)
                    {

                        Console.WriteLine(dirdirs[i] + "    [DIR]");
                        i++;

                    }
                    i = 0;
                    string[] dirfils = Directory.GetFiles(@"0:\");
                    while (i < dirfils.Length)
                    {

                        if (dirfils[i].EndsWith(".txt"))
                        {

                            Console.WriteLine(dirfils[i] + "    [Text Document]");

                        }
                        else if (dirfils[i].EndsWith(".ivk"))
                        {

                            Console.WriteLine(dirfils[i] + "    [Invokable Program]");

                        }
                        else if (dirfils[i].EndsWith(".pkg"))
                        {

                            Console.WriteLine(dirfils[i] + "    [CommandOS Packaged Program]");

                        }
                        else if (dirfils[i].EndsWith(".xcd"))
                        {

                            Console.WriteLine(dirfils[i] + "    [XCode Source File]");

                        }

                        i++;

                    }

                }

            }
            else if (cmd == "rm")
            {

                Console.Write("Path to File: ");
                input = Console.ReadLine();
                if (input != "" && File.Exists(input) && input != @"0:\os\user.cfg")
                {

                    File.Delete(input);

                }
                else if (input == "")
                {

                    Console.WriteLine("Error: No file specified.");

                }
                else if (!File.Exists(input))
                {

                    Console.WriteLine("Error: File not found.");

                }
                else if (input == @"0:\os\user.cfg")
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Beep();
                    Console.Write("[SysProtect] ");
                    Console.ResetColor();
                    Console.Write("This is a protected system file!");
                    Console.WriteLine("");

                }

            }
            else if (cmd == "rmdir")
            {

                Console.Write("Path to Directory: ");
                input = Console.ReadLine();
                if (input != "" && Directory.Exists(input))
                {

                    Directory.Delete(input);

                }

            }
            else if (cmd == "mkdir")
            {


                Console.Write("Path (Including New Directory):  ");
                input = Console.ReadLine();
                if (input != "")
                {
                    Directory.CreateDirectory(input);
                }

            }
            else if (cmd == "?" || cmd == "help" || cmd == "cmdlist")
            {

                int i = 0;
                while (i < cmds.ToArray().Length)
                {

                    Console.WriteLine(cmds.ToArray()[i]);
                    i++;

                }

            }
            else if (cmd.StartsWith("clr"))
            {

                if (cmd.Contains("-m") || cmd.Contains("--multiclear"))
                {

                    Console.Clear();
                    Console.Clear();
                    Console.Clear();
                    Console.Clear();

                }

                Console.Clear();

            }
            else if (cmd.StartsWith("invoke "))
            {


                string toBeSearched = "invoke ";
                int ix = cmd.IndexOf(toBeSearched);

                if (ix != -1)
                {

                    string prog = cmd.Substring(ix + toBeSearched.Length);
                    int i = 0;
                    if (File.Exists(prog) && prog.EndsWith(".ivk"))
                    {
                        string[] lns = File.ReadAllLines(prog);
                        while (i < lns.Length)
                        {

                            XCode.CodeHandler.exec(lns[i]);
                            i++;

                        }
                    }
                }

                Console.WriteLine();
            }


            else if (cmd == "")
            {




            }
            else
            {

                Console.WriteLine("Unknown command.");

            }





        }

    }

}