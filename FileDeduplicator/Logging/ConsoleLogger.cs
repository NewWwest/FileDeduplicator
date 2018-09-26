using System;
using System.Collections.Generic;
using System.Text;

namespace FileDeduplicator.Logging
{
    class ConsoleLogger : ILogger
    {
        public void Dispose() { }

        public void WriteLine(string text) => Console.WriteLine(text);
        public void WriteLine() => Console.WriteLine();
    }
}
