using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileDeduplicator.Logging
{
    //YES I KNOW - this is bad
    class ConsoleAndFileLogger : ILogger
    {
        StreamWriter writer;

        public ConsoleAndFileLogger(string filename)
        {
            writer = new StreamWriter(filename);
        }

        public void Dispose()
        {
            writer.Dispose();
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
            writer.WriteLine(text);
        }

        public void WriteLine() => WriteLine("");
    }
}
