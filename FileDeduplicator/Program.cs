using System;

namespace FileDeduplicator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var fw = new FileWalker();
            try
            {
                fw.ListFiles(@"E:\#Zdjęcia");
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
