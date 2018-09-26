using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDeduplicator.ArgumentParsing
{
    class Args
    {
        public string Directory;
        public bool LoudConsole;
        public string LogFile;
        enum LongParameter
        {
            Directory,
            Log
        }
        enum ShortParameter
        {
            v
        }

        public static string[] ShortParams => Enum.GetValues(typeof(ShortParameter)).Cast<ShortParameter>().Select(e => $"-{e.ToString()}").ToArray();
        public static string[] LongParams => Enum.GetValues(typeof(LongParameter)).Cast<LongParameter>().Select(e => $"--{e.ToString()}").ToArray();

        public void SetShortParam(string key, string value)
        {
            Enum.TryParse(key, out ShortParameter enumKey);
            switch (enumKey)
            {
                case (ShortParameter.v):
                    LoudConsole = true;
                    break;
                default:
                    DisplayHelp();
                    throw new Exception();
            }
        }

        public void SetLongParam(string key, string value)
        {
            Enum.TryParse(key, out LongParameter enumKey);
            switch (enumKey)
            {
                case (LongParameter.Directory):
                    Directory = value;
                    break;
                case (LongParameter.Log):
                    LogFile = value;
                    break;
                default:
                    DisplayHelp();
                    throw new Exception();
            }
        }

        public static void DisplayHelp()
        {
            Console.WriteLine("bitch please");
        }

        
    }
}
