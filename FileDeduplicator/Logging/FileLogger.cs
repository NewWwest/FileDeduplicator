using System;
using System.IO;

namespace FileDeduplicator.Logging
{
    class FileLogger : ILogger
    {
        StreamWriter writer;

        public FileLogger(string filename)
        {
            writer = new StreamWriter(filename);
        }

        public void Dispose()
        {
            writer.Dispose();
        }

        public void WriteLine(string text)
        {
            writer.WriteLine(text);
        }

        public void WriteLine() => WriteLine("");
    }
}
