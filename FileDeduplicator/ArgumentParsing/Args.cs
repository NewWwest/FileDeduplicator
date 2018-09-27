using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDeduplicator.ArgumentParsing
{
    class Args
    {
        public string Directory;
        public bool Verbose;
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

        public bool SetShortParam(string key, string value)
        {
            Enum.TryParse(key, out ShortParameter enumKey);
            switch (enumKey)
            {
                case (ShortParameter.v):
                    Verbose = true;
                    return false;
                default:
                    DisplayHelp();
                    throw new Exception();
            }
        }

        public bool SetLongParam(string key, string value)
        {
            Enum.TryParse(key, out LongParameter enumKey);
            switch (enumKey)
            {
                case (LongParameter.Directory):
                    Directory = value;
                    return true;
                case (LongParameter.Log):
                    LogFile = value;
                    return true;
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
