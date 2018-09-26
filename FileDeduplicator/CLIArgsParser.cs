using System;
using System.Collections.Generic;
using System.Text;

namespace FileDeduplicator
{
    class CLIArgsParser
    {
        
        public CLIArgsParser(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("--"))
                {
                    i++;
                    string value = args[i];
                }
            }
        }

        void SetValue(string key, string value)
        {
            switch (key)
            {
                case ("--directory"):
                    Directory = value;
                    break;
                case ("-v"):
                    LoudConsole = true;
                    break;
                case ("--log"):
                logFile = value;
                    break;
                default:
                    displayHelp();
                    throw new Exception();
            }
        }

        private void displayHelp()
        {
            Console.WriteLine("bitch please");
        }

        string Directory;
        bool LoudConsole;
        string logFile;
    }
}
