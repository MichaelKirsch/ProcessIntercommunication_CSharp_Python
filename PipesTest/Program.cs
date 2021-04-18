using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new process object
            Process myProcess = new Process();

            //Provide the start information for the process
            myProcess.StartInfo.FileName = "python.exe";
            myProcess.StartInfo.Arguments = "pipeback.py framerate=60";
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardInput = true;
            myProcess.StartInfo.RedirectStandardOutput = true;

            StreamReader myStreamReader;
            StreamWriter myStreamWriter;

            //Invoke the process from current process
            myProcess.Start();

            myStreamReader = myProcess.StandardOutput;
            myStreamWriter = myProcess.StandardInput;

            int TESTFREQUENCY = 100;
            
            while (true)
            {
                
                
                String argument = "GIMME MESSAGE BIATCH";
                myStreamWriter.WriteLine(argument);
                //Read the standard output of the spawned process.
                string myString = myStreamReader.ReadLine();
                Console.WriteLine(myString);
                Thread.Sleep(1000/TESTFREQUENCY);
            }
            
            myProcess.WaitForExit();
            myStreamWriter.Close();
            myStreamReader.Close();
            myProcess.Close();
        }
    }
}