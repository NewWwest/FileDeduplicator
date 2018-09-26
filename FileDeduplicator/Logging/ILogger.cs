using System;
using System.Collections.Generic;
using System.Text;

namespace FileDeduplicator.Logging
{
    interface ILogger : IDisposable
    {
        void WriteLine(string text);
        void WriteLine();
    }
}
