using FileDeduplicator.ArgumentParsing;
using FileDeduplicator.Logging;
using System;
using System.Collections.Generic;
using FileDeduplicator.Processing;

namespace FileDeduplicator
{
    class Program
    {


        static void Main(string[] args)
        {
            
            Args arguments = CLIArgsParser.Parse(args);
            arguments.Directory = @"E:/#Zdjęcia";
            arguments.Verbose = true;
            arguments.LogFile = "log";

            Console.WriteLine("Directory:");
            Console.WriteLine(arguments.Directory);
            Console.WriteLine("LogFile");
            Console.WriteLine(arguments.LogFile);
            Console.WriteLine("Verbose");
            Console.WriteLine(arguments.Verbose);
            Console.WriteLine("go?");
            Console.ReadLine();
            
            using (ILogger logger = ArgsToLogger(arguments))
            {
                new FileWalkerWrapper().DoWork(arguments.Directory, logger);


            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        public static ILogger ArgsToLogger(Args args)
        {
            ILogger consoleLogger;
            ILogger fileLogger;

            if (!String.IsNullOrWhiteSpace(args.LogFile))
                fileLogger = new FileLogger(args.LogFile);
            else
                fileLogger = new SilentLogger();

            if (args.Verbose)
                consoleLogger = new ConsoleLogger();
            else
                consoleLogger = new SilentLogger();

            return new MultiLogger(new List<ILogger>() { fileLogger, consoleLogger });
        }
    }
}
