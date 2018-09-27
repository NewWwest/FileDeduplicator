using FileDeduplicator.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileDeduplicator.Processing
{
    class FileWalkerWrapper
    {
        public void DoWork(string path, ILogger logger)
        {
            FileWalkerResult res=null; 
            try
            {
                res = FileWalker.Walk(path, logger);
            }
            catch (OperationCanceledException exc)
            {
                Console.WriteLine("Too much files");
            }
            FileWalkerAnalyzer.AnalyzeResult(res,logger);
        }
    }
}
