using FileDeduplicator.Logging;
using System;

namespace FileDeduplicator
{
    class Program
    {
        static void Main(string[] args)
        {
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
