using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;

namespace OS1
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("CommandOS Chipmunk booted successfully.");
        }

        protected override void Run()
        {
            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            string cmd;
            string username;
            string input;
            if (!Directory.Exists(@"0:\os"))
            {

                Directory.CreateDirectory(@"0:\os");

            }
            File.WriteAllText(@"0:\os\testfile.txt", "TEST DATA");
            File.ReadAllText(@"0:\os\testfile.txt");

            if (!File.Exists(@"0:\os\user.cfg"))
            {

                Console.WriteLine("CommandOS Setup");
                Console.Write("Username: ");
                string inpstp = Console.ReadLine();
                string[] stp = { inpstp };
                File.WriteAllLines(@"0:\os\user.cfg", stp);
                username = inpstp;

            } else
            {

                username = File.ReadAllLines(@"0:\os\user.cfg")[0];

            }

            Console.Clear();

            Console.WriteLine("Welcome to CommandOS!");

            while (true)
            {

                Console.Write(username + "@CommandOS  $  ");
                cmd = Console.ReadLine();
                if (cmd == "about")
                {

                    Console.WriteLine("CommandOS Chipmunk is an operating system developed");
                    Console.WriteLine("using the Cosmos User Kit.");

                } else if (cmd.StartsWith("shutdown"))
                {

                    if (cmd == "shutdown")
                    {

                        Sys.Power.Shutdown();

                    } else if (cmd == "shutdown -r")
                    {

                        Sys.Power.Reboot();

                    }

                } else if (cmd == "edit") {


                    Console.Write("Path to File: ");
                    input = Console.ReadLine();
                    if (File.Exists(input))
                    {

                        Console.WriteLine("Old Contents: ");
                        int i = 0;
                        while (i < File.ReadAllLines(input).Length)
                        {

                            Console.WriteLine(File.ReadAllLines(input)[i]);
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
                        File.WriteAllLines(input, nconts.ToArray());

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
                        File.WriteAllLines(input, nconts.ToArray());

                    }


                } else if (cmd == "dir")
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

                } else if (cmd == "rm")
                {

                    Console.Write("Path to File: ");
                    input = Console.ReadLine();
                    if (input != "" && File.Exists(input))
                    {

                        File.Delete(input);

                    }

                } else if(cmd == "rmdir")
                {

                    Console.Write("Path to Directory: ");
                    input = Console.ReadLine();
                    if (input != "" && Directory.Exists(input))
                    {

                        Directory.Delete(input);

                    }

                } else if (cmd == "mkdir")
                {


                    Console.Write("Path (Including New Directory):  ");
                    input = Console.ReadLine();
                    if (input != "")
                    {
                        Directory.CreateDirectory(input);
                    }

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
}

