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

                Console.Write(username + "@Chipmunk  $  ");
                cmd = Console.ReadLine();
                CommandHandler.exec(cmd);
            }
        }
    }
}

