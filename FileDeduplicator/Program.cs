using FileDeduplicator.ArgumentParsing;
using FileDeduplicator.Logging;
using System;

namespace FileDeduplicator
{
    class Program
    {


        static void Main(string[] args)
        {
            
            var xd = CLIArgsParser.Parse(args);
            Console.WriteLine("xd.Directory");
            Console.WriteLine(xd.Directory);
            Console.WriteLine("xd.LogFile");
            Console.WriteLine(xd.LogFile);
            Console.WriteLine("xd.LoudConsole");
            Console.WriteLine(xd.LoudConsole);
            Console.WriteLine("go?");




            Console.ReadLine();
            Console.WriteLine("Hello World!");
            using (ILogger logger = new ConsoleAndFileLogger("dupa"))
            {
                var fw = new FileWalker(@"E:\#Zdjęcia", logger);
                try
                {
                    fw.DoWork();
                }
                catch (OperationCanceledException exc)
                {
                    Console.WriteLine("Too much files");
                }
                fw.ProcessResult();
                Console.ReadLine();
            }

            
        }
    }
}
